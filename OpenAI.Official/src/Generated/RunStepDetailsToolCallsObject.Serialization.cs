// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Official.Internal
{
    internal partial class RunStepDetailsToolCallsObject : IUtf8JsonWriteable, IJsonModel<RunStepDetailsToolCallsObject>
    {
        void IUtf8JsonWriteable.Write(Utf8JsonWriter writer) => ((IJsonModel<RunStepDetailsToolCallsObject>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<RunStepDetailsToolCallsObject>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RunStepDetailsToolCallsObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RunStepDetailsToolCallsObject)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(Type.ToString());
            writer.WritePropertyName("tool_calls"u8);
            writer.WriteStartArray();
            foreach (var item in ToolCalls)
            {
                if (item == null)
                {
                    writer.WriteNullValue();
                    continue;
                }
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item);
#else
                using (JsonDocument document = JsonDocument.Parse(item))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
            writer.WriteEndArray();
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

        RunStepDetailsToolCallsObject IJsonModel<RunStepDetailsToolCallsObject>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RunStepDetailsToolCallsObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RunStepDetailsToolCallsObject)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRunStepDetailsToolCallsObject(document.RootElement, options);
        }

        internal static RunStepDetailsToolCallsObject DeserializeRunStepDetailsToolCallsObject(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            RunStepDetailsToolCallsObjectType type = default;
            IReadOnlyList<BinaryData> toolCalls = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"u8))
                {
                    type = new RunStepDetailsToolCallsObjectType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("tool_calls"u8))
                {
                    List<BinaryData> array = new List<BinaryData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(BinaryData.FromString(item.GetRawText()));
                        }
                    }
                    toolCalls = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new RunStepDetailsToolCallsObject(type, toolCalls, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<RunStepDetailsToolCallsObject>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RunStepDetailsToolCallsObject>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(RunStepDetailsToolCallsObject)} does not support '{options.Format}' format.");
            }
        }

        RunStepDetailsToolCallsObject IPersistableModel<RunStepDetailsToolCallsObject>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RunStepDetailsToolCallsObject>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeRunStepDetailsToolCallsObject(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(RunStepDetailsToolCallsObject)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<RunStepDetailsToolCallsObject>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static RunStepDetailsToolCallsObject FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeRunStepDetailsToolCallsObject(document.RootElement);
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
