using OpenAI.Official.Chat;
using System;
using System.ClientModel.Primitives;
using System.ClientModel.Primitives.Pipeline;
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
        if (scenario == TestScenario.Chat)
        {
            ChatClientOptions options = new();
            options.PerTryPolicies = AddDumpPolicy(options.PerTryPolicies);
            return (T)((object)new ChatClient(overrideModel ?? "gpt-3.5-turbo", options));
        }
        throw new NotImplementedException();
    }

    private static IPipelinePolicy<PipelineMessage>[]? AddDumpPolicy(IPipelinePolicy<PipelineMessage>[]? original)
    {
        return
        [
            .. original ?? [],
            new TestPipelinePolicy((message) =>
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
                if (message.HasResponse)
                {
                    Console.WriteLine("--- Begin response content ---");
                    Console.WriteLine(message.Response.Content?.ToString());
                    Console.WriteLine("--- End of response content ---");
                }
            })
        ];
    }
}