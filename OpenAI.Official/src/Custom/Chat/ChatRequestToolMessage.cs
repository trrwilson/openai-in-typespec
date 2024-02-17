using System;

namespace OpenAI.Official.Chat;

public class ChatRequestToolMessage : ChatRequestMessage
{
    public string ToolCallId { get; set; }

    public ChatRequestToolMessage(string toolCallId, ChatMessageTextContent content)
        : base(ChatRole.Tool, content)
    {
        ToolCallId = toolCallId;
    }
}
