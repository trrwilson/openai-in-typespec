using OpenAI.Official.Assistants;
using OpenAI.Official.Chat;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;

namespace OpenAI.Official.Tests;

internal static class TestHelpers
{
    public enum TestScenario
    {
        Assistants,
        TextToSpeech,
        Chat,
        VisionChat,
        Files,
        Embeddings,
        FineTuning,
        Images,
        Transcription,
        Models,
        LegacyCompletions,
        Moderations,
    }

    public static T GetTestClient<T>(TestScenario scenario, string overrideModel = null)
    {
        OpenAIClientOptions options = new();
        options.AddPolicy(GetDumpPolicy(), PipelinePosition.PerTry);
        return scenario switch
        {
            TestScenario.Chat => (T)((object)new ChatClient(overrideModel ?? "gpt-3.5-turbo", options)),
            TestScenario.VisionChat => (T)((object)new ChatClient(overrideModel ?? "gpt-4-vision-preview", options)),
            TestScenario.Assistants => (T)((object)new AssistantClient(options)),
            _ => throw new NotImplementedException(),
        };
    }

    private static PipelinePolicy GetDumpPolicy()
    {
        return new TestPipelinePolicy((message) =>
        {
            if (message.Request?.Uri != null)
            {
                Console.WriteLine($"--- Request URI: ---");
                Console.WriteLine(message.Request.Uri.AbsoluteUri);
            }
            if (message.Request?.Content != null)
            {
                Console.WriteLine($"--- Begin request content ---");
                using MemoryStream stream = new();
                message.Request.Content.WriteTo(stream, default);
                stream.Position = 0;
                using StreamReader reader = new(stream);
                Console.WriteLine(reader.ReadToEnd());
                Console.WriteLine("--- End of request content ---");
            }
            if (message.Response != null)
            {
                Console.WriteLine("--- Begin response content ---");
                Console.WriteLine(message.Response.Content?.ToString());
                Console.WriteLine("--- End of response content ---");
            }
        });
    }
}