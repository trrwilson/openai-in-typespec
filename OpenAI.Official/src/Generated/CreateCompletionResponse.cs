// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Linq;

namespace OpenAI.Official.Internal
{
    /// <summary>
    /// Represents a completion response from the API. Note: both the streamed and non-streamed response
    /// objects share the same shape (unlike the chat endpoint).
    /// </summary>
    internal partial class CreateCompletionResponse
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

        /// <summary> Initializes a new instance of <see cref="CreateCompletionResponse"/>. </summary>
        /// <param name="id"> A unique identifier for the completion. </param>
        /// <param name="choices"> The list of completion choices the model generated for the input. </param>
        /// <param name="created"> The Unix timestamp (in seconds) of when the completion was created. </param>
        /// <param name="model"> The model used for the completion. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="choices"/> or <paramref name="model"/> is null. </exception>
        internal CreateCompletionResponse(string id, IEnumerable<CreateCompletionResponseChoice> choices, DateTimeOffset created, string model)
        {
            ClientUtilities.AssertNotNull(id, nameof(id));
            ClientUtilities.AssertNotNull(choices, nameof(choices));
            ClientUtilities.AssertNotNull(model, nameof(model));

            Id = id;
            Choices = choices.ToList();
            Created = created;
            Model = model;
        }

        /// <summary> Initializes a new instance of <see cref="CreateCompletionResponse"/>. </summary>
        /// <param name="id"> A unique identifier for the completion. </param>
        /// <param name="choices"> The list of completion choices the model generated for the input. </param>
        /// <param name="created"> The Unix timestamp (in seconds) of when the completion was created. </param>
        /// <param name="model"> The model used for the completion. </param>
        /// <param name="systemFingerprint">
        /// This fingerprint represents the backend configuration that the model runs with.
        ///
        /// Can be used in conjunction with the `seed` request parameter to understand when backend changes
        /// have been made that might impact determinism.
        /// </param>
        /// <param name="object"> The object type, which is always `text_completion`. </param>
        /// <param name="usage"> Usage statistics for the completion request. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CreateCompletionResponse(string id, IReadOnlyList<CreateCompletionResponseChoice> choices, DateTimeOffset created, string model, string systemFingerprint, CreateCompletionResponseObject @object, CompletionUsage usage, IDictionary<string, BinaryData> serializedAdditionalRawData)
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

        /// <summary> Initializes a new instance of <see cref="CreateCompletionResponse"/> for deserialization. </summary>
        internal CreateCompletionResponse()
        {
        }

        /// <summary> A unique identifier for the completion. </summary>
        public string Id { get; }
        /// <summary> The list of completion choices the model generated for the input. </summary>
        public IReadOnlyList<CreateCompletionResponseChoice> Choices { get; }
        /// <summary> The Unix timestamp (in seconds) of when the completion was created. </summary>
        public DateTimeOffset Created { get; }
        /// <summary> The model used for the completion. </summary>
        public string Model { get; }
        /// <summary>
        /// This fingerprint represents the backend configuration that the model runs with.
        ///
        /// Can be used in conjunction with the `seed` request parameter to understand when backend changes
        /// have been made that might impact determinism.
        /// </summary>
        public string SystemFingerprint { get; }
        /// <summary> The object type, which is always `text_completion`. </summary>
        public CreateCompletionResponseObject Object { get; } = CreateCompletionResponseObject.TextCompletion;

        /// <summary> Usage statistics for the completion request. </summary>
        public CompletionUsage Usage { get; }
    }
}
