using System;
using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Official.Chat;

public abstract partial class ChatRequestMessage : IUtf8JsonWriteable, IJsonModel<ChatRequestMessage>
{
    void IUtf8JsonWriteable.Write(Utf8JsonWriter writer)
    {
        throw new NotImplementedException();
    }

    void IJsonModel<ChatRequestMessage>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("role"u8, Role.ToString());
        if (OptionalProperty.IsDefined(Content))
        {
            writer.WritePropertyName("content"u8);
            (Content as IJsonModel<ChatMessageContent>).Write(writer, options);
        }
        WriteDerivedAdditions(writer, options);
        writer.WriteEndObject();
    }

    ChatRequestMessage IJsonModel<ChatRequestMessage>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    BinaryData IPersistableModel<ChatRequestMessage>.Write(ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    ChatRequestMessage IPersistableModel<ChatRequestMessage>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    string IPersistableModel<ChatRequestMessage>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    internal abstract void WriteDerivedAdditions(Utf8JsonWriter writer, ModelReaderWriterOptions options);
}
