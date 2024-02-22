﻿using OpenAI.Assistants;
using OpenAI.Chat;
using OpenAI.Files;
using OpenAI.Images;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;

namespace OpenAI.Tests;

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

    public static T GetTestClient<T>(TestScenario scenario, string overrideModel = null, bool throwOnError = true)
    {
        OpenAIClientOptions options = new();
        options.AddPolicy(GetDumpPolicy(), PipelinePosition.PerTry);
        options.ErrorOptions = throwOnError ? ClientErrorBehaviors.Default : ClientErrorBehaviors.NoThrow;
        object clientObject = scenario switch
        {
            TestScenario.Chat => new ChatClient(overrideModel ?? "gpt-3.5-turbo", options),
            TestScenario.VisionChat => new ChatClient(overrideModel ?? "gpt-4-vision-preview", options),
            TestScenario.Assistants => new AssistantClient(options),
            TestScenario.Images => new ImageClient(overrideModel ?? "dall-e-3", options),
            TestScenario.Files => new FileClient(options),
            _ => throw new NotImplementedException(),
        };
        return (T)clientObject;
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