// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Official.Internal
{
    internal partial class ListRunStepsResponse : IUtf8JsonWriteable, IJsonModel<ListRunStepsResponse>
    {
        void IUtf8JsonWriteable.Write(Utf8JsonWriter writer) => ((IJsonModel<ListRunStepsResponse>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<ListRunStepsResponse>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ListRunStepsResponse>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ListRunStepsResponse)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("object"u8);
            writer.WriteStringValue(Object.ToString());
            writer.WritePropertyName("data"u8);
            writer.WriteStartArray();
            foreach (var item in Data)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("first_id"u8);
            writer.WriteStringValue(FirstId);
            writer.WritePropertyName("last_id"u8);
            writer.WriteStringValue(LastId);
            writer.WritePropertyName("has_more"u8);
            writer.WriteBooleanValue(HasMore);
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

        ListRunStepsResponse IJsonModel<ListRunStepsResponse>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ListRunStepsResponse>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ListRunStepsResponse)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeListRunStepsResponse(document.RootElement, options);
        }

        internal static ListRunStepsResponse DeserializeListRunStepsResponse(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ListRunStepsResponseObject @object = default;
            IReadOnlyList<RunStepObject> data = default;
            string firstId = default;
            string lastId = default;
            bool hasMore = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("object"u8))
                {
                    @object = new ListRunStepsResponseObject(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("data"u8))
                {
                    List<RunStepObject> array = new List<RunStepObject>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(RunStepObject.DeserializeRunStepObject(item));
                    }
                    data = array;
                    continue;
                }
                if (property.NameEquals("first_id"u8))
                {
                    firstId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("last_id"u8))
                {
                    lastId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("has_more"u8))
                {
                    hasMore = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ListRunStepsResponse(@object, data, firstId, lastId, hasMore, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ListRunStepsResponse>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ListRunStepsResponse>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ListRunStepsResponse)} does not support '{options.Format}' format.");
            }
        }

        ListRunStepsResponse IPersistableModel<ListRunStepsResponse>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ListRunStepsResponse>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeListRunStepsResponse(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ListRunStepsResponse)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<ListRunStepsResponse>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static ListRunStepsResponse FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeListRunStepsResponse(document.RootElement);
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
