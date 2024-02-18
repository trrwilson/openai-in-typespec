using System;
using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace OpenAI.Official.Chat;

public partial class ChatFunctionCall : IUtf8JsonWriteable, IJsonModel<ChatFunctionCall>
{
    void IUtf8JsonWriteable.Write(Utf8JsonWriter writer)
    {
        throw new System.NotImplementedException();
    }

    void IJsonModel<ChatFunctionCall>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("name"u8, Name);
        writer.WriteString("arguments"u8, Arguments);
        writer.WriteEndObject();
    }

    ChatFunctionCall IJsonModel<ChatFunctionCall>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    BinaryData IPersistableModel<ChatFunctionCall>.Write(ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    ChatFunctionCall IPersistableModel<ChatFunctionCall>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    string IPersistableModel<ChatFunctionCall>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
}
