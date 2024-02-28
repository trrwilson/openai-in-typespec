using NUnit.Framework;
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

        List<ChatRequestMessage> messages =
        [
            new ChatRequestSystemMessage(
               "Don't make assumptions about what values to plug into functions."
               + " Ask for clarification if a user request is ambiguous."),
            new ChatRequestUserMessage("What's the weather like in San Francisco?"),
        ];

        ChatCompletionOptions options = new()
        {
            Tools = funtions.Definitions
        };

        ChatCompletion chatCompletion = client.CompleteChat(messages, options);

        if (chatCompletion.FinishReason == ChatFinishReason.ToolCalls)
        {
            // First, add the assistant message with tool calls to the conversation history.
            messages.Add(new ChatRequestAssistantMessage(chatCompletion));

            IEnumerable<ChatRequestToolMessage> callResults = funtions.CallAll(chatCompletion.ToolCalls);
            // Then, add a new tool message for each tool call that is resolved.
            messages.AddRange(callResults);

            // Finally, make a new request to chat completions to let the assistant summarize the tool results
            // and add the resulting message to the conversation history to keep it organized all in one place.
            ChatCompletion chatCompletionAfterToolMessages = client.CompleteChat(messages, options);
            messages.Add(new ChatRequestAssistantMessage(chatCompletionAfterToolMessages));
        }
    }

    static class MyFunctions
    {
        [Description("Returns the current weather at the specified location")]
        public static string GetCurrentWeather(string location, string unit) => $"31 {unit}";

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


