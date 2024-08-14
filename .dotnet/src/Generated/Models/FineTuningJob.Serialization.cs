// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.FineTuning
{
    public partial class FineTuningJob : IJsonModel<FineTuningJob>
    {
        void IJsonModel<FineTuningJob>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FineTuningJob>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FineTuningJob)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("id") != true)
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (SerializedAdditionalRawData?.ContainsKey("created_at") != true)
            {
                writer.WritePropertyName("created_at"u8);
                writer.WriteNumberValue(CreatedAt, "U");
            }
            if (SerializedAdditionalRawData?.ContainsKey("error") != true)
            {
                if (Error != null)
                {
                    writer.WritePropertyName("error"u8);
                    writer.WriteObjectValue(Error, options);
                }
                else
                {
                    writer.WriteNull("error");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("fine_tuned_model") != true)
            {
                if (FineTunedModel != null)
                {
                    writer.WritePropertyName("fine_tuned_model"u8);
                    writer.WriteStringValue(FineTunedModel);
                }
                else
                {
                    writer.WriteNull("fine_tuned_model");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("finished_at") != true)
            {
                if (FinishedAt != null)
                {
                    writer.WritePropertyName("finished_at"u8);
                    writer.WriteNumberValue(FinishedAt.Value, "U");
                }
                else
                {
                    writer.WriteNull("finished_at");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("hyperparameters") != true)
            {
                writer.WritePropertyName("hyperparameters"u8);
                writer.WriteObjectValue<FineTuningJobHyperparameters>(Hyperparameters, options);
            }
            if (SerializedAdditionalRawData?.ContainsKey("model") != true)
            {
                writer.WritePropertyName("model"u8);
                writer.WriteStringValue(Model);
            }
            if (SerializedAdditionalRawData?.ContainsKey("object") != true)
            {
                writer.WritePropertyName("object"u8);
                writer.WriteStringValue(Object);
            }
            if (SerializedAdditionalRawData?.ContainsKey("organization_id") != true)
            {
                writer.WritePropertyName("organization_id"u8);
                writer.WriteStringValue(OrganizationId);
            }
            if (SerializedAdditionalRawData?.ContainsKey("result_files") != true)
            {
                writer.WritePropertyName("result_files"u8);
                writer.WriteStartArray();
                foreach (var item in ResultFiles)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (SerializedAdditionalRawData?.ContainsKey("status") != true)
            {
                writer.WritePropertyName("status"u8);
                writer.WriteStringValue(Status.ToString());
            }
            if (SerializedAdditionalRawData?.ContainsKey("trained_tokens") != true)
            {
                if (TrainedTokens != null)
                {
                    writer.WritePropertyName("trained_tokens"u8);
                    writer.WriteNumberValue(TrainedTokens.Value);
                }
                else
                {
                    writer.WriteNull("trained_tokens");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("training_file") != true)
            {
                writer.WritePropertyName("training_file"u8);
                writer.WriteStringValue(TrainingFileId);
            }
            if (SerializedAdditionalRawData?.ContainsKey("validation_file") != true)
            {
                if (ValidationFile != null)
                {
                    writer.WritePropertyName("validation_file"u8);
                    writer.WriteStringValue(ValidationFile);
                }
                else
                {
                    writer.WriteNull("validation_file");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("integrations") != true && Optional.IsCollectionDefined(Integrations))
            {
                if (Integrations != null)
                {
                    writer.WritePropertyName("integrations"u8);
                    writer.WriteStartArray();
                    foreach (var item in Integrations)
                    {
                        writer.WriteObjectValue<InternalFineTuningIntegration>(item, options);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("integrations");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("seed") != true)
            {
                writer.WritePropertyName("seed"u8);
                writer.WriteNumberValue(Seed);
            }
            if (SerializedAdditionalRawData?.ContainsKey("estimated_finish") != true && Optional.IsDefined(EstimatedFinishAt))
            {
                if (EstimatedFinishAt != null)
                {
                    writer.WritePropertyName("estimated_finish"u8);
                    writer.WriteNumberValue(EstimatedFinishAt.Value, "U");
                }
                else
                {
                    writer.WriteNull("estimated_finish");
                }
            }
            if (SerializedAdditionalRawData != null)
            {
                foreach (var item in SerializedAdditionalRawData)
                {
                    if (ModelSerializationExtensions.IsSentinelValue(item.Value))
                    {
                        continue;
                    }
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

        FineTuningJob IJsonModel<FineTuningJob>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FineTuningJob>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FineTuningJob)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFineTuningJob(document.RootElement, options);
        }

        internal static FineTuningJob DeserializeFineTuningJob(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            DateTimeOffset createdAt = default;
            FineTuningJobError error = default;
            string fineTunedModel = default;
            DateTimeOffset? finishedAt = default;
            FineTuningJobHyperparameters hyperparameters = default;
            string model = default;
            string @object = default;
            string organizationId = default;
            IReadOnlyList<string> resultFiles = default;
            FineTuningJobStatus status = default;
            int? trainedTokens = default;
            string trainingFile = default;
            string validationFile = default;
            IReadOnlyList<InternalFineTuningIntegration> integrations = default;
            int seed = default;
            DateTimeOffset? estimatedFinish = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("created_at"u8))
                {
                    createdAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                    continue;
                }
                if (property.NameEquals("error"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        error = null;
                        continue;
                    }
                    error = FineTuningJobError.DeserializeFineTuningJobError(property.Value, options);
                    continue;
                }
                if (property.NameEquals("fine_tuned_model"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        fineTunedModel = null;
                        continue;
                    }
                    fineTunedModel = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("finished_at"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        finishedAt = null;
                        continue;
                    }
                    finishedAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                    continue;
                }
                if (property.NameEquals("hyperparameters"u8))
                {
                    hyperparameters = FineTuningJobHyperparameters.DeserializeFineTuningJobHyperparameters(property.Value, options);
                    continue;
                }
                if (property.NameEquals("model"u8))
                {
                    model = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("object"u8))
                {
                    @object = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("organization_id"u8))
                {
                    organizationId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("result_files"u8))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    resultFiles = array;
                    continue;
                }
                if (property.NameEquals("status"u8))
                {
                    status = new FineTuningJobStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("trained_tokens"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        trainedTokens = null;
                        continue;
                    }
                    trainedTokens = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("training_file"u8))
                {
                    trainingFile = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("validation_file"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        validationFile = null;
                        continue;
                    }
                    validationFile = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("integrations"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<InternalFineTuningIntegration> array = new List<InternalFineTuningIntegration>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(InternalFineTuningIntegration.DeserializeInternalFineTuningIntegration(item, options));
                    }
                    integrations = array;
                    continue;
                }
                if (property.NameEquals("seed"u8))
                {
                    seed = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("estimated_finish"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        estimatedFinish = null;
                        continue;
                    }
                    estimatedFinish = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new FineTuningJob(
                id,
                createdAt,
                error,
                fineTunedModel,
                finishedAt,
                hyperparameters,
                model,
                @object,
                organizationId,
                resultFiles,
                status,
                trainedTokens,
                trainingFile,
                validationFile,
                integrations ?? new ChangeTrackingList<InternalFineTuningIntegration>(),
                seed,
                estimatedFinish,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<FineTuningJob>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FineTuningJob>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(FineTuningJob)} does not support writing '{options.Format}' format.");
            }
        }

        FineTuningJob IPersistableModel<FineTuningJob>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FineTuningJob>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeFineTuningJob(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(FineTuningJob)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<FineTuningJob>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
