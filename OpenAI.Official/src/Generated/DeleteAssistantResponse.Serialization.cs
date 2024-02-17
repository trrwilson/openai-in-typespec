// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Official.Internal
{
    internal partial class DeleteAssistantResponse : IUtf8JsonWriteable, IJsonModel<DeleteAssistantResponse>
    {
        void IUtf8JsonWriteable.Write(Utf8JsonWriter writer) => ((IJsonModel<DeleteAssistantResponse>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<DeleteAssistantResponse>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeleteAssistantResponse>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DeleteAssistantResponse)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("id"u8);
            writer.WriteStringValue(Id);
            writer.WritePropertyName("deleted"u8);
            writer.WriteBooleanValue(Deleted);
            writer.WritePropertyName("object"u8);
            writer.WriteStringValue(Object.ToString());
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        DeleteAssistantResponse IJsonModel<DeleteAssistantResponse>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeleteAssistantResponse>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DeleteAssistantResponse)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDeleteAssistantResponse(document.RootElement, options);
        }

        internal static DeleteAssistantResponse DeserializeDeleteAssistantResponse(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            bool deleted = default;
            DeleteAssistantResponseObject @object = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("deleted"u8))
                {
                    deleted = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("object"u8))
                {
                    @object = new DeleteAssistantResponseObject(property.Value.GetString());
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new DeleteAssistantResponse(id, deleted, @object, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<DeleteAssistantResponse>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeleteAssistantResponse>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(DeleteAssistantResponse)} does not support '{options.Format}' format.");
            }
        }

        DeleteAssistantResponse IPersistableModel<DeleteAssistantResponse>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeleteAssistantResponse>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeDeleteAssistantResponse(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(DeleteAssistantResponse)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<DeleteAssistantResponse>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static DeleteAssistantResponse FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeDeleteAssistantResponse(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestBody. </summary>
        internal virtual RequestBody ToRequestBody()
        {
            var content = new Utf8JsonRequestBody();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
