using System;
using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Official.Chat;

public abstract partial class ChatToolCall : IUtf8JsonWriteable, IJsonModel<ChatToolCall>
{
    ChatToolCall IJsonModel<ChatToolCall>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    ChatToolCall IPersistableModel<ChatToolCall>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    string IPersistableModel<ChatToolCall>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    void IUtf8JsonWriteable.Write(Utf8JsonWriter writer)
    {
        throw new NotImplementedException();
    }

    void IJsonModel<ChatToolCall>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("id"u8, Id);
        WriteDerivedAdditions(writer, options);
        writer.WriteEndObject();
    }

    BinaryData IPersistableModel<ChatToolCall>.Write(ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    internal abstract void WriteDerivedAdditions(Utf8JsonWriter writer, ModelReaderWriterOptions options);
}