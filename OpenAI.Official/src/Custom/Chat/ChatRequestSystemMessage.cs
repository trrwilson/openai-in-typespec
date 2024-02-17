using System;

namespace OpenAI.Official.Chat;

public class ChatRequestSystemMessage : ChatRequestMessage
{
    public string ParticipantName { get; set; } // JSON "name"

    // Note: we can constrain this to text content for now and open it up if/when later expanded
    public ChatRequestSystemMessage(ChatMessageTextContent content) : base(ChatRole.System, content) { }
}