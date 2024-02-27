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

        ChatCompletion chatCompletion = client.CompleteChat(messages, options).Value;

        if (chatCompletion.FinishReason == ChatFinishReason.ToolCalls)
        {
            // First, add the assistant message with tool calls to the conversation history.
            messages.Add(new ChatRequestAssistantMessage(chatCompletion));

            // Then, add a new tool message for each tool call that is resolved.
            foreach (ChatToolCall toolCall in chatCompletion.ToolCalls)
            {
                ChatFunctionToolCall functionToolCall = toolCall as ChatFunctionToolCall;
                var result = funtions.Call(functionToolCall);
                messages.Add(new ChatRequestToolMessage(toolCall.Id, result));
            }

            // Finally, make a new request to chat completions to let the assistant summarize the tool results
            // and add the resulting message to the conversation history to keep it organized all in one place.
            ChatCompletion chatCompletionAfterToolMessages = client.CompleteChat(messages, options).Value;
            messages.Add(new ChatRequestAssistantMessage(chatCompletionAfterToolMessages));
        }
    }

    static class MyFunctions
    {
        [Description("Returns the current weather at the specified location")]
        public static string GetCurrentWeather(string location, string unit) => $"31 {unit}";
    }
}


