namespace OpenAI.Official.Chat;

/// <summary>
/// A common, base representation of a message provided as input into a chat completion request.
/// </summary>
/// <remarks>
/// <list type="table">
/// <listheader>
///     <type>Type -</type>
///     <role>Role -</role>
///     <note>Description</note>
/// </listheader>
/// <item>
///     <type><see cref="ChatRequestSystemMessage"/> -</type>
///     <role><c>system</c> -</role>
///     <note>Instructions to the model that guide the behavior of future <c>assistant</c> messages.</note>
/// </item>
/// <item>
///     <type><see cref="ChatRequestUserMessage"/> -</type>
///     <role><c>user</c> -</role>
///     <note>Input messages from the caller, typically paired with <c>assistant</c> messages in a conversation.</note>
/// </item>
/// <item>
///     <type><see cref="ChatRequestAssistantMessage"/> -</type>
///     <role><c>assistant</c> -</role>
///     <note>
///         Output messages from the model with responses to the <c>user</c> or calls to tools or functions that are
///         needed to continue the logical conversation.
///     </note>
/// </item>
/// <item>
///     <type><see cref="ChatRequestToolMessage"/> -</type>
///     <role><c>tool</c> -</role>
///     <note>
///         Resolution information for a <see cref="ChatToolCall"/> in an earlier
///         <see cref="ChatRequestAssistantMessage"/> that was made against a supplied
///         <see cref="ChatToolDefinition"/>.
///     </note>
/// </item>
/// <item>
///     <type><see cref="ChatRequestFunctionMessage"/> -</type>
///     <role><c>function</c> -</role>
///     <note>
///         Resolution information for a <see cref="ChatFunctionCall"/> in an earlier
///         <see cref="ChatRequestAssistantMessage"/> that was made against a supplied
///         <see cref="ChatFunctionDefinition"/>. Note that <c>functions</c> are deprecated in favor of
///         <c>tool_calls</c>.
///     </note>
/// </item>
/// </list>
/// </remarks>
public abstract partial class ChatRequestMessage
{
    /// <summary>
    /// The content associated with the message. The interpretation of this content will vary depending on the message type.
    /// </summary>
    public ChatMessageContent Content { get; }

    /// <summary>
    /// The <c>role</c> associated with the message.
    /// </summary>
    public ChatRole Role { get; }

    /// <summary>
    /// Initializes base instance data for <see cref="ChatRequestMessage"/>.
    /// </summary>
    /// <param name="role"> The <c>role</c> associated with the message. </param>
    /// <param name="content"> The <c>content</c> associated with the message. </param>
    protected ChatRequestMessage(ChatRole role, ChatMessageContent content)
    {
        Role = role;
        Content = content;
    }
}
