// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI.Models;

namespace OpenAI.Assistants
{
    /// <summary> References an image URL in the content of a message. </summary>
    internal partial class InternalMessageImageUrlContent : MessageContent
    {
        /// <summary> Initializes a new instance of <see cref="InternalMessageImageUrlContent"/>. </summary>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="type"> The type of the content part. </param>
        /// <param name="imageUrl"></param>
        internal InternalMessageImageUrlContent(IDictionary<string, BinaryData> serializedAdditionalRawData, string type, InternalMessageContentImageUrlObjectImageUrl imageUrl) : base(serializedAdditionalRawData)
        {
            _type = type;
            _imageUrl = imageUrl;
        }

        /// <summary> Initializes a new instance of <see cref="InternalMessageImageUrlContent"/> for deserialization. </summary>
        internal InternalMessageImageUrlContent()
        {
        }
    }
}
