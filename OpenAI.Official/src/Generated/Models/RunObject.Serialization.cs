// <auto-generated/>

using System;
using OpenAI.ClientShared.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Internal.Models
{
    internal partial class RunObject : IJsonModel<RunObject>
    {
        void IJsonModel<RunObject>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RunObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RunObject)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("id"u8);
            writer.WriteStringValue(Id);
            writer.WritePropertyName("object"u8);
            writer.WriteStringValue(Object.ToString());
            writer.WritePropertyName("created_at"u8);
            writer.WriteNumberValue(CreatedAt, "U");
            writer.WritePropertyName("thread_id"u8);
            writer.WriteStringValue(ThreadId);
            writer.WritePropertyName("assistant_id"u8);
            writer.WriteStringValue(AssistantId);
            writer.WritePropertyName("status"u8);
            writer.WriteStringValue(Status.ToString());
            if (RequiredAction != null)
            {
                writer.WritePropertyName("required_action"u8);
                writer.WriteObjectValue(RequiredAction);
            }
            else
            {
                writer.WriteNull("required_action");
            }
            if (LastError != null)
            {
                writer.WritePropertyName("last_error"u8);
                writer.WriteObjectValue(LastError);
            }
            else
            {
                writer.WriteNull("last_error");
            }
            writer.WritePropertyName("expires_at"u8);
            writer.WriteNumberValue(ExpiresAt, "U");
            if (StartedAt != null)
            {
                writer.WritePropertyName("started_at"u8);
                writer.WriteStringValue(StartedAt.Value, "O");
            }
            else
            {
                writer.WriteNull("started_at");
            }
            if (CancelledAt != null)
            {
                writer.WritePropertyName("cancelled_at"u8);
                writer.WriteStringValue(CancelledAt.Value, "O");
            }
            else
            {
                writer.WriteNull("cancelled_at");
            }
            if (FailedAt != null)
            {
                writer.WritePropertyName("failed_at"u8);
                writer.WriteStringValue(FailedAt.Value, "O");
            }
            else
            {
                writer.WriteNull("failed_at");
            }
            if (CompletedAt != null)
            {
                writer.WritePropertyName("completed_at"u8);
                writer.WriteStringValue(CompletedAt.Value, "O");
            }
            else
            {
                writer.WriteNull("completed_at");
            }
            writer.WritePropertyName("model"u8);
            writer.WriteStringValue(Model);
            writer.WritePropertyName("instructions"u8);
            writer.WriteStringValue(Instructions);
            writer.WritePropertyName("tools"u8);
            writer.WriteStartArray();
            foreach (var item in Tools)
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
            writer.WritePropertyName("file_ids"u8);
            writer.WriteStartArray();
            foreach (var item in FileIds)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            if (Metadata != null && OptionalProperty.IsCollectionDefined(Metadata))
            {
                writer.WritePropertyName("metadata"u8);
                writer.WriteStartObject();
                foreach (var item in Metadata)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            else
            {
                writer.WriteNull("metadata");
            }
            if (Usage != null)
            {
                writer.WritePropertyName("usage"u8);
                writer.WriteObjectValue(Usage);
            }
            else
            {
                writer.WriteNull("usage");
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

        RunObject IJsonModel<RunObject>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RunObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RunObject)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRunObject(document.RootElement, options);
        }

        internal static RunObject DeserializeRunObject(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            RunObjectObject @object = default;
            DateTimeOffset createdAt = default;
            string threadId = default;
            string assistantId = default;
            RunObjectStatus status = default;
            RunObjectRequiredAction requiredAction = default;
            RunObjectLastError lastError = default;
            DateTimeOffset expiresAt = default;
            DateTimeOffset? startedAt = default;
            DateTimeOffset? cancelledAt = default;
            DateTimeOffset? failedAt = default;
            DateTimeOffset? completedAt = default;
            string model = default;
            string instructions = default;
            IReadOnlyList<BinaryData> tools = default;
            IReadOnlyList<string> fileIds = default;
            IReadOnlyDictionary<string, string> metadata = default;
            RunCompletionUsage usage = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("object"u8))
                {
                    @object = new RunObjectObject(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("created_at"u8))
                {
                    createdAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                    continue;
                }
                if (property.NameEquals("thread_id"u8))
                {
                    threadId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("assistant_id"u8))
                {
                    assistantId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("status"u8))
                {
                    status = new RunObjectStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("required_action"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        requiredAction = null;
                        continue;
                    }
                    requiredAction = RunObjectRequiredAction.DeserializeRunObjectRequiredAction(property.Value);
                    continue;
                }
                if (property.NameEquals("last_error"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        lastError = null;
                        continue;
                    }
                    lastError = RunObjectLastError.DeserializeRunObjectLastError(property.Value);
                    continue;
                }
                if (property.NameEquals("expires_at"u8))
                {
                    expiresAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                    continue;
                }
                if (property.NameEquals("started_at"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        startedAt = null;
                        continue;
                    }
                    startedAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());  // property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("cancelled_at"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        cancelledAt = null;
                        continue;
                    }
                    cancelledAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64()); // property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("failed_at"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        failedAt = null;
                        continue;
                    }
                    failedAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());  // property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("completed_at"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        completedAt = null;
                        continue;
                    }
                    completedAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());  //property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("model"u8))
                {
                    model = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("instructions"u8))
                {
                    instructions = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("tools"u8))
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
                    tools = array;
                    continue;
                }
                if (property.NameEquals("file_ids"u8))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    fileIds = array;
                    continue;
                }
                if (property.NameEquals("metadata"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        metadata = new OptionalDictionary<string, string>();
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    metadata = dictionary;
                    continue;
                }
                if (property.NameEquals("usage"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        usage = null;
                        continue;
                    }
                    usage = RunCompletionUsage.DeserializeRunCompletionUsage(property.Value);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new RunObject(id, @object, createdAt, threadId, assistantId, status, requiredAction, lastError, expiresAt, startedAt, cancelledAt, failedAt, completedAt, model, instructions, tools, fileIds, metadata, usage, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<RunObject>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RunObject>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(RunObject)} does not support '{options.Format}' format.");
            }
        }

        RunObject IPersistableModel<RunObject>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RunObject>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeRunObject(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(RunObject)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<RunObject>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static RunObject FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeRunObject(document.RootElement);
        }
    }
}

