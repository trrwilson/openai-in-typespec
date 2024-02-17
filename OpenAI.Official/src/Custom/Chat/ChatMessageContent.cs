using System.Collections;
using System.Collections.Generic;
using OpenAI.Official.Internal;

namespace OpenAI.Official.Chat;

public abstract class ChatMessageContent
{
    public static implicit operator ChatMessageContent(string value) => new ChatMessageTextContent(value);
}
