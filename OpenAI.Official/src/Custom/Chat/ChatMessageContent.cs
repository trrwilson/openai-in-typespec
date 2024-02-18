namespace OpenAI.Official.Chat;

/// <summary>
/// Represents the common base type for a piece of message content used for chat completions.
/// </summary>
public abstract partial class ChatMessageContent
{
    /// <summary>
    /// The implicit conversion operator that infers an equivalent <see cref="ChatMessageTextContent"/> instance from
    /// a plain <see cref="string"/>.
    /// </summary>
    /// <param name="value"> The text for the message content. </param>
    public static implicit operator ChatMessageContent(string value) => new ChatMessageTextContent(value);

}
