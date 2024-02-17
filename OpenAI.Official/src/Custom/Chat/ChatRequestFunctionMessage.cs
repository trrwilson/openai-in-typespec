using System;

namespace OpenAI.Official.Chat;

public class ChatRequestFunctionMessage : ChatRequestMessage
{
    public string FunctionName { get; set; } // JSON "name"

    public ChatRequestFunctionMessage(string functionName, ChatMessageTextContent content)
        : base(ChatRole.Function, content)
    {
        FunctionName = functionName;
    }
}
