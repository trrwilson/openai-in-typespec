using System;
using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Official.Chat;

/// <summary>
/// Represents the common base type for a piece of message content used for chat completions.
/// </summary>
public abstract partial class ChatMessageContent : IUtf8JsonWriteable, IJsonModel<ChatMessageContent>
{
    ChatMessageContent IJsonModel<ChatMessageContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    ChatMessageContent IPersistableModel<ChatMessageContent>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    string IPersistableModel<ChatMessageContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    void IUtf8JsonWriteable.Write(Utf8JsonWriter writer)
    {
        throw new NotImplementedException();
    }

    void IJsonModel<ChatMessageContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => WriteTopLevel(writer, options);

    BinaryData IPersistableModel<ChatMessageContent>.Write(ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    internal abstract void WriteTopLevel(Utf8JsonWriter writer, ModelReaderWriterOptions options);
    internal abstract void WriteInCollection(Utf8JsonWriter writer, ModelReaderWriterOptions options);
}
