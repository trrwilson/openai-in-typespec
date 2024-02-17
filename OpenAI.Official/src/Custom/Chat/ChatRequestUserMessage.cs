using System;

namespace OpenAI.Official.Chat;

public class ChatRequestUserMessage : ChatRequestMessage
{
    public string ParticipantName { get; set; } // JSON "name"

    public ChatRequestUserMessage(ChatMessageTextContent content)
        : base(ChatRole.User, content)
    { }
    public ChatRequestUserMessage(IEnumerable<ChatMessageContent> contentItems)
        : base(ChatRole.User, new ChatMessageContentCollection(contentItems))
    { }
}
