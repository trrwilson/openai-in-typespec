using System.Collections;
using System.Collections.Generic;
using OpenAI.Official.Internal;

namespace OpenAI.Official.Chat;

public class ChatMessageImageUrlContent : ChatMessageContent
{
    public string ImageUrl { get; }
    public ChatMessageImageUrlContent(string url)
    {
        ImageUrl = url;
    }
}