﻿using NUnit.Framework;
using OpenAI.Official.Chat;
using System;
using System.ClientModel;

namespace OpenAI.Official.Tests.Chat;

public partial class ChatWithVision
{
    [Test]
    public void DescribeAnImage()
    {
        ChatClient client = new("gpt-4-vision-preview");
        Result<ChatCompletion> result = client.CompleteChat(
            [
                new ChatRequestUserMessage(
                    "Describe this image for me",
                    new ChatMessageImageUrlContent(s_stopSignDataUrl)),
            ], new ChatCompletionOptions()
            {
                MaxTokens = 2048,
            });
        Console.WriteLine(result.Value.Content);
        Assert.That(result.Value.Content.ToString().ToLowerInvariant(), Contains.Substring("stop"));
    }

    private static string s_stopSignDataUrl = "data:image/png;base64,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";
}
