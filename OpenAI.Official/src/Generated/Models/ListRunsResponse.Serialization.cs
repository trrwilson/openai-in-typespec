// <auto-generated/>

using System;
using OpenAI.ClientShared.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Internal.Models
{
    internal partial class ListRunsResponse : IJsonModel<ListRunsResponse>
    {
        void IJsonModel<ListRunsResponse>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ListRunsResponse>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ListRunsResponse)} does not support '{format}' format.");
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

        ListRunsResponse IJsonModel<ListRunsResponse>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ListRunsResponse>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ListRunsResponse)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeListRunsResponse(document.RootElement, options);
        }

        internal static ListRunsResponse DeserializeListRunsResponse(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ListRunsResponseObject @object = default;
            IReadOnlyList<RunObject> data = default;
            string firstId = default;
            string lastId = default;
            bool hasMore = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("object"u8))
                {
                    @object = new ListRunsResponseObject(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("data"u8))
                {
                    List<RunObject> array = new List<RunObject>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(RunObject.DeserializeRunObject(item));
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
            return new ListRunsResponse(@object, data, firstId, lastId, hasMore, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ListRunsResponse>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ListRunsResponse>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ListRunsResponse)} does not support '{options.Format}' format.");
            }
        }

        ListRunsResponse IPersistableModel<ListRunsResponse>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ListRunsResponse>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeListRunsResponse(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ListRunsResponse)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<ListRunsResponse>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static ListRunsResponse FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeListRunsResponse(document.RootElement);
        }
    }
}

