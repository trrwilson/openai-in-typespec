// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Linq;

namespace OpenAI.Official.Internal
{
    /// <summary> The ListModelsResponse. </summary>
    internal partial class ListModelsResponse
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

        /// <summary> Initializes a new instance of <see cref="ListModelsResponse"/>. </summary>
        /// <param name="data"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        internal ListModelsResponse(IEnumerable<Model> data)
        {
            ClientUtilities.AssertNotNull(data, nameof(data));

            Data = data.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="ListModelsResponse"/>. </summary>
        /// <param name="object"></param>
        /// <param name="data"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ListModelsResponse(ListModelsResponseObject @object, IReadOnlyList<Model> data, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Object = @object;
            Data = data;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ListModelsResponse"/> for deserialization. </summary>
        internal ListModelsResponse()
        {
        }

        /// <summary> Gets the object. </summary>
        public ListModelsResponseObject Object { get; } = ListModelsResponseObject.List;

        /// <summary> Gets the data. </summary>
        public IReadOnlyList<Model> Data { get; }
    }
}
