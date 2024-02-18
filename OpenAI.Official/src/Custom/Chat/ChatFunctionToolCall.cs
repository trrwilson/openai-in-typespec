using System.Diagnostics.CodeAnalysis;

namespace OpenAI.Official.Chat;

/// <summary>
/// Represents a call made by the model to a function tool that was defined in a chat completion request.
/// </summary>
public class ChatFunctionToolCall : ChatToolCall
{
    internal Internal.ChatCompletionMessageToolCallFunction InternalToolCall { get; }

    /// <summary>
    /// Gets the <c>name</c> of the function.
    /// </summary>
    public required string FunctionName
    {
        get => InternalToolCall.Name;
        set => InternalToolCall.Name = value;
    }

    /// <summary>
    /// Gets the <c>arguments</c> to the function.
    /// </summary>
    public required string Arguments
    {
        get => InternalToolCall.Arguments;
        set => InternalToolCall.Arguments = value;

    }
    /// <summary>
    /// Creates a new instance of <see cref="ChatFunctionToolCall"/>.
    /// </summary>
    public ChatFunctionToolCall()
    {
        InternalToolCall = new();
    }

    /// <summary>
    /// Creates a new instance of <see cref="ChatFunctionToolCall"/>.
    /// </summary>
    /// <param name="toolCallId">
    ///     The ID of the tool call, used when resolving the tool call with a future
    ///     <see cref="ChatRequestToolMessage"/>.
    /// </param>
    /// <param name="functionName"> The <c>name</c> of the function. </param>
    /// <param name="arguments"> The <c>arguments</c> to the function. </param>
    [SetsRequiredMembers]
    public ChatFunctionToolCall(string toolCallId, string functionName, string arguments)
        : this()
    {
        Id = toolCallId;
        FunctionName = functionName;
        Arguments = arguments;
    }
}