// <auto-generated/>

using System;
using OpenAI.ClientShared.Internal;
using System.Collections.Generic;
using System.Linq;

namespace OpenAI.Internal.Models
{
    /// <summary> Represents a chat completion response returned by model, based on the provided input. </summary>
    internal partial class CreateChatCompletionResponse
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="CreateChatCompletionResponse"/>. </summary>
        /// <param name="id"> A unique identifier for the chat completion. </param>
        /// <param name="choices"> A list of chat completion choices. Can be more than one if `n` is greater than 1. </param>
        /// <param name="created"> The Unix timestamp (in seconds) of when the chat completion was created. </param>
        /// <param name="model"> The model used for the chat completion. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="choices"/> or <paramref name="model"/> is null. </exception>
        internal CreateChatCompletionResponse(string id, IEnumerable<CreateChatCompletionResponseChoice> choices, DateTimeOffset created, string model)
        {
            if (id is null) throw new ArgumentNullException(nameof(id));
            if (choices is null) throw new ArgumentNullException(nameof(choices));
            if (model is null) throw new ArgumentNullException(nameof(model));

            Id = id;
            Choices = choices.ToList();
            Created = created;
            Model = model;
        }

        /// <summary> Initializes a new instance of <see cref="CreateChatCompletionResponse"/>. </summary>
        /// <param name="id"> A unique identifier for the chat completion. </param>
        /// <param name="choices"> A list of chat completion choices. Can be more than one if `n` is greater than 1. </param>
        /// <param name="created"> The Unix timestamp (in seconds) of when the chat completion was created. </param>
        /// <param name="model"> The model used for the chat completion. </param>
        /// <param name="systemFingerprint">
        /// This fingerprint represents the backend configuration that the model runs with.
        ///
        /// Can be used in conjunction with the `seed` request parameter to understand when backend changes
        /// have been made that might impact determinism.
        /// </param>
        /// <param name="object"> The object type, which is always `chat.completion`. </param>
        /// <param name="usage"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CreateChatCompletionResponse(string id, IReadOnlyList<CreateChatCompletionResponseChoice> choices, DateTimeOffset created, string model, string systemFingerprint, CreateChatCompletionResponseObject @object, CompletionUsage usage, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            Choices = choices;
            Created = created;
            Model = model;
            SystemFingerprint = systemFingerprint;
            Object = @object;
            Usage = usage;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="CreateChatCompletionResponse"/> for deserialization. </summary>
        internal CreateChatCompletionResponse()
        {
        }

        /// <summary> A unique identifier for the chat completion. </summary>
        public string Id { get; }
        /// <summary> A list of chat completion choices. Can be more than one if `n` is greater than 1. </summary>
        public IReadOnlyList<CreateChatCompletionResponseChoice> Choices { get; }
        /// <summary> The Unix timestamp (in seconds) of when the chat completion was created. </summary>
        public DateTimeOffset Created { get; }
        /// <summary> The model used for the chat completion. </summary>
        public string Model { get; }
        /// <summary>
        /// This fingerprint represents the backend configuration that the model runs with.
        ///
        /// Can be used in conjunction with the `seed` request parameter to understand when backend changes
        /// have been made that might impact determinism.
        /// </summary>
        public string SystemFingerprint { get; }
        /// <summary> The object type, which is always `chat.completion`. </summary>
        public CreateChatCompletionResponseObject Object { get; } = CreateChatCompletionResponseObject.ChatCompletion;

        /// <summary> Gets the usage. </summary>
        public CompletionUsage Usage { get; }
    }
}

