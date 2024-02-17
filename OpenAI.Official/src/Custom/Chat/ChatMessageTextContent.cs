namespace OpenAI.Official.Chat;

public class ChatMessageTextContent : ChatMessageContent
{
    public string Text { get; }
    public ChatMessageTextContent(string text)
    {
        Text = text;
    }
    public static implicit operator ChatMessageTextContent(string value) => new(value);
}