using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Official.Chat;

/// <summary>
/// Represents an item of <c>text</c> content in chat completion messages.
/// </summary>
public class ChatMessageTextContent : ChatMessageContent
{
    /// <summary>
    /// The content text. The interpretation of this value will depend on which kind of chat message the content is
    /// associated with.
    /// </summary>
    public string Text { get; }
    /// <summary>
    /// Creates a new instance of <see cref="ChatMessageTextContent"/>.
    /// </summary>
    /// <param name="text"> The text for the new content item. </param>
    public ChatMessageTextContent(string text)
    {
        Text = text;
    }
    /// <summary>
    /// An implicit conversion from a plain <see cref="string"/> into a new <see cref="ChatMessageTextContent"/>
    /// instance.
    /// </summary>
    /// <param name="value"> The text for the new content item. </param>
    public static implicit operator ChatMessageTextContent(string value) => new(value);
    /// <inheritdoc/>
    public override string ToString() => Text;

    internal override void WriteTopLevel(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStringValue(Text);
    }

    internal override void WriteInCollection(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("type"u8, "text"u8);
        writer.WriteString("text"u8, Text);
        writer.WriteEndObject();
    }
}