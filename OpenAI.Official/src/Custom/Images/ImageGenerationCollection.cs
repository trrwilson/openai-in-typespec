using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OpenAI.Official.Images;

/// <summary>
/// Represents an image generation response payload that contains information for multiple generated images.
/// </summary>
public class ImageGenerationCollection : ReadOnlyCollection<ImageGeneration>
{
    internal ImageGenerationCollection(IList<ImageGeneration> list) : base(list) { }
}