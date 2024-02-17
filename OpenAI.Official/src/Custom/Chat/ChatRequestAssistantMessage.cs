using System;

namespace OpenAI.Official.Chat;


public class ChatRequestAssistantMessage : ChatRequestMessage
{
    public string ParticipantName { get; set; } // JSON "name"
    public IReadOnlyList<ChatToolCall> ToolCalls { get; }
    public ChatFunctionCall FunctionCall { get; }

    // Assistant messages may present ONE OF:
    //	- Ordinary text content without tools or a function, in which case the content is required;
    //	- A list of tool calls, together with optional text content
    //	- A function call, together with optional text content
    public ChatRequestAssistantMessage(ChatMessageTextContent content)
        : base(ChatRole.Assistant, content)
    { }
    public ChatRequestAssistantMessage(IEnumerable<ChatToolCall> toolCalls, ChatMessageTextContent content = null)
        : base(ChatRole.Assistant, content)
    {
        ToolCalls = new List<ChatToolCall>(toolCalls);
    }

    public ChatRequestAssistantMessage(ChatFunctionCall functionCall, ChatMessageTextContent content = null)
        : base(ChatRole.Assistant, content)
    {
        FunctionCall = functionCall;
    }
}