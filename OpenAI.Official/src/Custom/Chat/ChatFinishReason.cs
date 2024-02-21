namespace OpenAI.Chat;

using System;

/// <summary>
/// The reason the model stopped generating tokens. This will be:
/// <list type="table">
/// <listheader>
///     <member>Property</member>
///     <rest>REST</rest>
///     <cond>Condition</cond>
/// </listheader>
/// <item>
///     <member><see cref="Stopped"/></member>
///     <rest><c>stop</c></rest>
///     <cond>The model encountered a natural stop point or provided stop sequence.</cond>
/// </item>
/// <item>
///     <member><see cref="Length"/></member>
///     <rest><c>length</c></rest>
///     <cond>The maximum number of tokens specified in the request was reached.</cond>
/// </item>
/// <item>
///     <member><see cref="ContentFilter"/></member>
///     <rest><c>content_filter</c></rest>
///     <cond>Content was omitted due to a triggered content filter rule.</cond>
/// </item>
/// <item>
///     <member><see cref="ToolCalls"/></member>
///     <rest><c>tool_calls</c></rest>
///     <cond>
///         With no explicit <c>tool_choice</c>, the model called one or more tools that were defined in the request.
///     </cond>
/// </item>
/// <item>
///     <member><see cref="FunctionCall"/></member>
///     <rest><c>function_call</c></rest>
///     <cond>(Deprecated) The model called a function that was defined in the request.</cond>
/// </item>
/// </list>
/// </summary>
public readonly struct ChatFinishReason : IEquatable<ChatFinishReason>
{
    private readonly string _value;
    /// <summary>
    /// Creates a new instance of <see cref="ChatFinishReason"/>.
    /// </summary>
    /// <param name="value"></param>
    public ChatFinishReason(string value)
    {
        _value = value;
    }
    /// <summary>
    /// Indicates that the model encountered a natural stop point or provided stop sequence.
    /// </summary>
    public static ChatFinishReason Stopped { get; } = "stop";
    /// <summary>
    /// Indicates that the model reached the maximum number of tokens allowed for the request.
    /// </summary>
    public static ChatFinishReason Length { get; } = "length";
    /// <summary>
    /// Indicates that content was omitted due to a triggered content filter rule.
    /// </summary>
    public static ChatFinishReason ContentFilter { get; } = "content_filter";
    /// <summary>
    /// Indicates that the model called a function that was defined in the request.
    /// </summary>
    /// <remarks>
    /// To resolve a function call, append the message associated with the function call followed by a
    /// <see cref="ChatRequestFunctionMessage"/> with the appropriate name and arguments, then perform another chat
    /// completion with the combined set of messages.
    /// </remarks>
    public static ChatFinishReason FunctionCall { get; } = "function_call";
    /// <summary>
    /// Indicates that the model called a function that was defined in the request.
    /// </summary>
    /// <remarks>
    /// To resolve tool calls, append the message associated with the tool calls followed by matching instances of
    /// <see cref="ChatRequestToolMessage"/> for each tool call, then perform another chat completion with the combined
    /// set of messages.
    /// <para>
    /// <b>Note</b>: <see cref="ToolCalls"/> is <i>not</i> provided as the <c>finish_reason</c> if the model calls a
    /// tool in response to an explicit <c>tool_choice</c> via <see cref="ChatCompletionOptions.ToolConstraint"/>.
    /// In that case, calling the specified tool is assumed and the expected reason is <see cref="Stopped"/>.
    /// </para>
    /// </remarks>
    public static ChatFinishReason ToolCalls { get; } = "tool_calls";
    /// <inheritdoc/>
    public static bool operator ==(ChatFinishReason left, ChatFinishReason right)
        => left._value == right._value;
    /// <inheritdoc/>
    public static implicit operator ChatFinishReason(string value) => new(value); 
    /// <inheritdoc/>
    public static bool operator !=(ChatFinishReason left, ChatFinishReason right)
        => left._value != right._value;
    /// <inheritdoc/>
    public bool Equals(ChatFinishReason other) => _value.Equals(other._value);
    /// <inheritdoc/>
    public override string ToString() => _value;
    /// <inheritdoc/>
    public override bool Equals(object obj)
        => (obj is ChatFinishReason reason && reason._value.Equals(_value))
            || (obj is string reasonText && reasonText.Equals(_value));
    /// <inheritdoc/>
    public override int GetHashCode() => _value.GetHashCode();
}
