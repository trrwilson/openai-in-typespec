using System.Collections;
using System.Collections.Generic;
using OpenAI.Official.Internal;

namespace OpenAI.Official.Chat;

public class ChatMessageContentCollection : ChatMessageContent, IEnumerable<ChatMessageContent>
{
    public IEnumerable<ChatMessageContent> Items { get; }
    public ChatMessageContentCollection(IEnumerable<ChatMessageContent> contentItems)
    {
        Items = contentItems;
    }

    public IEnumerator<ChatMessageContent> GetEnumerator() => Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();
}