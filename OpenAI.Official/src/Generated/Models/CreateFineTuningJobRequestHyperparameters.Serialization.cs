// <auto-generated/>

using System;
using OpenAI.ClientShared.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Internal.Models
{
    internal partial class CreateFineTuningJobRequestHyperparameters : IJsonModel<CreateFineTuningJobRequestHyperparameters>
    {
        void IJsonModel<CreateFineTuningJobRequestHyperparameters>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateFineTuningJobRequestHyperparameters>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CreateFineTuningJobRequestHyperparameters)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (OptionalProperty.IsDefined(NEpochs))
            {
                writer.WritePropertyName("n_epochs"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(NEpochs);
#else
                using (JsonDocument document = JsonDocument.Parse(NEpochs))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
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

        CreateFineTuningJobRequestHyperparameters IJsonModel<CreateFineTuningJobRequestHyperparameters>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateFineTuningJobRequestHyperparameters>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CreateFineTuningJobRequestHyperparameters)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCreateFineTuningJobRequestHyperparameters(document.RootElement, options);
        }

        internal static CreateFineTuningJobRequestHyperparameters DeserializeCreateFineTuningJobRequestHyperparameters(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            OptionalProperty<BinaryData> nEpochs = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("n_epochs"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    nEpochs = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new CreateFineTuningJobRequestHyperparameters(nEpochs.Value, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<CreateFineTuningJobRequestHyperparameters>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateFineTuningJobRequestHyperparameters>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(CreateFineTuningJobRequestHyperparameters)} does not support '{options.Format}' format.");
            }
        }

        CreateFineTuningJobRequestHyperparameters IPersistableModel<CreateFineTuningJobRequestHyperparameters>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateFineTuningJobRequestHyperparameters>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeCreateFineTuningJobRequestHyperparameters(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(CreateFineTuningJobRequestHyperparameters)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<CreateFineTuningJobRequestHyperparameters>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static CreateFineTuningJobRequestHyperparameters FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeCreateFineTuningJobRequestHyperparameters(document.RootElement);
        }
    }
}

