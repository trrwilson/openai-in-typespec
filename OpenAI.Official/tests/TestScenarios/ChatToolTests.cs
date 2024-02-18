using NUnit.Framework;
using OpenAI.Official.Chat;
using System;
using System.ClientModel;
using System.Collections.Generic;

namespace OpenAI.Official.Tests.Chat;

public partial class ChatToolConstraintTests
{
    [Test]
    public void NoParameterToolWorks()
    {
        ChatClient client = new("gpt-3.5-turbo", new() { ErrorBehavior = ErrorBehavior.NoThrow });
        ChatFunctionToolDefinition getFavoriteColorTool = new()
        {
            Name = "get_favorite_color",
            Description = "gets the favorite color of the caller",
        };
        ChatCompletionOptions options = new()
        {
            Tools = { getFavoriteColorTool },
        };
        Result<ChatCompletion> result = client.CompleteChat("What's my favorite color?", options);
        Assert.That(result.Value.FinishReason, Is.EqualTo(ChatFinishReason.ToolCalls));
        Assert.That(result.Value.ToolCalls.Count, Is.EqualTo(1));
        var functionToolCall = result.Value.ToolCalls[0] as ChatFunctionToolCall;
        var toolCallArguments = BinaryData.FromString(functionToolCall.Arguments).ToObjectFromJson<Dictionary<string, object>>();
        Assert.That(functionToolCall, Is.Not.Null);
        Assert.That(functionToolCall.Name, Is.EqualTo(getFavoriteColorTool.Name));
        Assert.That(functionToolCall.Id, Is.Not.Null.Or.Empty);
        Assert.That(toolCallArguments.Count, Is.EqualTo(0));

        result = client.CompleteChat(
            [
                new ChatRequestUserMessage("What's my favorite color?"),
                new ChatRequestAssistantMessage(result.Value),
                new ChatRequestToolMessage(functionToolCall.Id, "green"),
            ]);
        Assert.That(result.Value.FinishReason, Is.EqualTo(ChatFinishReason.Stopped));
        Assert.That(result.Value.Content.ToString().ToLowerInvariant(), Contains.Substring("green"));
    }
}
