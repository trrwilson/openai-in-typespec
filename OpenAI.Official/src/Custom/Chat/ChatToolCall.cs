namespace OpenAI.Official.Chat;

/// <summary>
/// A base representation of an item in an <c>assistant</c> role response's <c>tool_calls</c> that specifies
/// parameterized resolution against a previously defined tool that is needed for the model to continue the logical
/// conversation.
/// </summary>
public abstract class ChatToolCall
{
    /// <summary>
    /// A unique identifier associated with the tool call, used in a subsequent <see cref="ChatRequestToolMessage"/> to
    /// resolve the tool call and continue the logical conversation.
    /// </summary>
    public required string Id { get; set; }
}