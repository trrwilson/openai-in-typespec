using System;

namespace OpenAI.Official.Chat;

/// <summary>
/// Represents a requested <c>response_format</c> for the model to use, enabling "JSON mode" for guaranteed valid output.
/// </summary>
/// <remarks>
/// <b>Important</b>: when using JSON mode, the model <b><u>must</u></b> also be instructed to produce JSON via a
/// <c>system</c> or <c>user</c> message.
/// <para>
/// Without this paired, message-based accompaniment, the model may generate an unending stream of whitespace until the
/// generation reaches the token limit, resulting in a long-running and seemingly "stuck" request.
/// </para>
/// <para>
/// Also note that the message content may be partially cut off if <c>finish_reason</c> is <c>length</c>, which
/// indicates that the generation exceeded <c>max_tokens</c> or the conversation exceeded the max context length for
/// the model.
/// </para>
/// </remarks>
public readonly struct ChatResponseFormat : IEquatable<ChatResponseFormat>
{
    private readonly string _value;
    /// <summary>
    /// Specifies that the model should provide plain, textual output.
    /// </summary>
    public static ChatResponseFormat Text { get; } = new("text");
    /// <summary>
    /// Specifies that the model should enable "JSON mode" and better guarantee the emission of valid JSON.
    /// </summary>
    /// <remarks>
    /// <b>Important</b>: when using JSON mode, the model <b><u>must</u></b> also be instructed to produce JSON via a
    /// <c>system</c> or <c>user</c> message.
    /// <para>
    /// Without this paired, message-based accompaniment, the model may generate an unending stream of whitespace until the
    /// generation reaches the token limit, resulting in a long-running and seemingly "stuck" request.
    /// </para>
    /// <para>
    /// Also note that the message content may be partially cut off if <c>finish_reason</c> is <c>length</c>, which
    /// indicates that the generation exceeded <c>max_tokens</c> or the conversation exceeded the max context length for
    /// the model.
    /// </para>
    /// </remarks>
    public static ChatResponseFormat JsonObject { get; } = new("json_object");
    /// <summary>
    /// Creates a new instance of <see cref="ChatResponseFormat"/>.
    /// </summary>
    /// <param name="value"> The <c>type</c> of the <c>response_format</c> to use. </param>
    public ChatResponseFormat(string value)
    {
        _value = value;
    }
    /// <inheritdoc/>
    public static bool operator ==(ChatResponseFormat left, ChatResponseFormat right)
        => left._value == right._value;
    /// <inheritdoc/>
    public static implicit operator ChatResponseFormat(string value) => new(value);
    /// <inheritdoc/>
    public static bool operator !=(ChatResponseFormat left, ChatResponseFormat right)
        => left._value != right._value;
    /// <inheritdoc/>
    public bool Equals(ChatResponseFormat other) => _value == other._value;
    /// <inheritdoc/>
    public override string ToString() => _value;
    /// <inheritdoc/>
    public override bool Equals(object obj)
        => (obj is ChatResponseFormat format && format._value == _value)
        || (obj is string formatString && formatString == _value);
    /// <inheritdoc/>
    public override int GetHashCode() => _value.GetHashCode();
}