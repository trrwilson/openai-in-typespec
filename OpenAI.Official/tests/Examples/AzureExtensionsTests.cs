﻿using NUnit.Framework;
using OpenAI.Chat;
using System;
using System.ClientModel;
using System.Collections.Generic;

namespace OpenAI.Tests.Chat;

public class AzureExtensionsTests
{
    static readonly string endpoint = Environment.GetEnvironmentVariable("AZ_OPENAI_ENDPOINT")!;
    static readonly Uri uri = new(endpoint);
    static readonly string key = Environment.GetEnvironmentVariable("AZ_OPENAI_KEY")!;
    static readonly ApiKeyCredential credential = new(key);
    static readonly string chatDeployment = "gpt35turbo";

    [Test]
    public void HelloChat()
    {
        var clientOptions = new AzureOpenAIClientOptions(new Uri(endpoint), credential, chatDeployment);
        ChatClient client = new ChatClient(model: "", credential, clientOptions);

        Assert.That(client, Is.InstanceOf<ChatClient>());
        ClientResult<ChatCompletion> result = client.CompleteChat("Hello, world!");
        Assert.That(result, Is.InstanceOf<ClientResult<ChatCompletion>>());
        Assert.That(result.Value.Content?.ContentKind, Is.EqualTo(ChatMessageContentKind.Text));
        Assert.That(result.Value.Content.ToText().Length, Is.GreaterThan(0));
    }

    [Test]
    public void ChatWithFunctionCalling()
    {
        var clientOptions = new AzureOpenAIClientOptions(new Uri(endpoint), credential, chatDeployment);
        ChatClient client = new ChatClient(model: "", credential, clientOptions);

        ChatFunctions funtions = new(typeof(MyFunctions));

        List<ChatRequestMessage> prompt = [
            new ChatRequestUserMessage("What's the weather like in today?")
        ];

        ChatCompletionOptions completionOptions = new() {
            Tools = funtions.Definitions
        };

        while(true)
        {
            CALL_SERVICE:
            ChatCompletion chatCompletion = client.CompleteChat(prompt, completionOptions);

            switch (chatCompletion.FinishReason)
            {
                case ChatFinishReason.Stopped:
                    prompt.Add(new ChatRequestAssistantMessage(chatCompletion));
                    Console.WriteLine(chatCompletion.Content);
                    return;
                case ChatFinishReason.ToolCalls:
                    prompt.Add(new ChatRequestAssistantMessage(chatCompletion));
                    IEnumerable<ChatRequestToolMessage> callResults = funtions.CallAll(chatCompletion.ToolCalls);
                    prompt.AddRange(callResults);
                    goto CALL_SERVICE;
                case ChatFinishReason.Length:
                    throw new NotImplementedException("trim prompt");
                default:
                    throw new NotImplementedException(chatCompletion.FinishReason.ToString());
            }
        }
    }

    static class MyFunctions
    {
        [Description("Returns the current weather at the specified location")]
        public static string GetCurrentWeather(string location, string unit) => $"31 {unit}";
        public static string GetCurrentLocation() => "San Francisco";
        public static string GetCurrentTime() => DateTimeOffset.Now.ToString("t");
    }

    [Test]
    public void ChatRag()
    {
        string[] testMessages = [
            "How is your day?",
            "What time is it?",
            "What's the weather in Seattle?"
        ];

        var clientOptions = new AzureOpenAIClientOptions(new Uri(endpoint), credential, chatDeployment);
        ChatClient client = new ChatClient(model: "", credential, clientOptions);

        ChatFunctions funtions = new(typeof(MyFunctions));

        ChatCompletionOptions completionOptions = new() { Tools = funtions.Definitions };
        List<ChatRequestMessage> prompt = new();

        foreach(var testMessage in testMessages)
        {
            prompt.Add(ChatRequestMessage.CreateUserMessage(testMessage));

            CALL_SERVICE:
            ChatCompletion chatCompletion = client.CompleteChat(prompt, completionOptions);

            switch(chatCompletion.FinishReason)
            {
                case ChatFinishReason.Stopped:
                    prompt.Add(new ChatRequestAssistantMessage(chatCompletion));
                    Console.WriteLine(chatCompletion.Content);
                    break;
                case ChatFinishReason.ToolCalls:
                    prompt.Add(new ChatRequestAssistantMessage(chatCompletion));
                    IEnumerable<ChatRequestToolMessage> callResults = funtions.CallAll(chatCompletion.ToolCalls);
                    prompt.AddRange(callResults);
                    goto CALL_SERVICE;
                case ChatFinishReason.Length:
                    throw new NotImplementedException("trim prompt");
                break;

                default:
                    throw new NotImplementedException(chatCompletion.FinishReason.ToString());
            }
        }
    }
}


