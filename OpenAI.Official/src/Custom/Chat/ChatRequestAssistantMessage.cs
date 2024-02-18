using System.Collections.Generic;

namespace OpenAI.Official.Chat;

/// <summary>
/// Represents a chat message of the <c>assistant</c> role as supplied to a chat completion request. As assistant
/// messages are originated by the model on responses, <see cref="ChatRequestAssistantMessage"/> instances typically
/// represent chat history or example interactions to guide model behavior.
/// </summary>
public class ChatRequestAssistantMessage : ChatRequestMessage
{
    /// <summary>
    /// An optional <c>name</c> associated with the assistant message. This is typically defined with a <c>system</c>
    /// message and is used to differentiate between multiple participants of the same role.
    /// </summary>
    public string ParticipantName { get; set; }
    /// <summary>
    /// The <c>tool_calls</c> furnished by the model that are needed to continue the logical conversation across chat
    /// completion requests. A <see cref="ChatToolCall"/> instance corresponds to a supplied
    /// <see cref="ChatToolDefinition"/> instance and is resolved by providing a <see cref="ChatRequestToolMessage"/>
    /// that correlates via <c>id</c> to the item in <c>tool_calls</c>.
    /// </summary>
    public IReadOnlyList<ChatToolCall> ToolCalls { get; }
    /// <summary>
    /// <c>Deprecated in favor of tool_calls.</c>
    /// <para>
    /// The <c>function_call</c> furnished by the model that is needed to continue the logical conversation
    /// across chat completion requests. A <see cref="ChatFunctionCall"/> instance corresponds to a supplied
    /// <see cref="ChatFunctionDefinition"/> instance and is resolved by providing a
    /// <see cref="ChatRequestFunctionMessage"/> that correlates via <c>name</c> to the <c>function_call</c>.
    /// </para>
    /// </summary>
    public ChatFunctionCall FunctionCall { get; }

    // Assistant messages may present ONE OF:
    //	- Ordinary text content without tools or a function, in which case the content is required;
    //	- A list of tool calls, together with optional text content
    //	- A function call, together with optional text content

    /// <summary>
    /// Creates a new instance of <see cref="ChatRequestAssistantMessage"/> that represents ordinary text content and
    /// does not feature tool or function calls.
    /// </summary>
    /// <param name="content"> The text content of the message. </param>
    public ChatRequestAssistantMessage(ChatMessageTextContent content)
        : base(ChatRole.Assistant, content)
    { }

    /// <summary>
    /// Creates a new instance of <see cref="ChatRequestAssistantMessage"/> that represents <c>tool_calls</c> that
    /// were provided by the model.
    /// </summary>
    /// <param name="toolCalls"> The <c>tool_calls</c> made by the model. </param>
    /// <param name="content"> Optional text content associated with the message. </param>
    public ChatRequestAssistantMessage(IEnumerable<ChatToolCall> toolCalls, ChatMessageTextContent content = null)
        : base(ChatRole.Assistant, content)
    {
        ToolCalls = new List<ChatToolCall>(toolCalls);
    }

    /// <summary>
    /// Creates a new instance of <see cref="ChatRequestAssistantMessage"/> that represents a <c>function_call</c>
    /// (deprecated in favor of <c>tool_calls</c>) that was made by the model.
    /// </summary>
    /// <param name="functionCall"> The <c>function_call</c> made by the model. </param>
    /// <param name="content"> Optional text content associated with the message. </param>
    public ChatRequestAssistantMessage(ChatFunctionCall functionCall, ChatMessageTextContent content = null)
        : base(ChatRole.Assistant, content)
    {
        FunctionCall = functionCall;
    }
}