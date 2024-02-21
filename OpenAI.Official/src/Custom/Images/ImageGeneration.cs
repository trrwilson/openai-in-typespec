using System;

namespace OpenAI.Images;

/// <summary>
/// Represents the result data for an image generation request.
/// </summary>
public class ImageGeneration
{
    /// <summary>
    /// The binary image data received from the response, provided when
    /// <see cref="ImageGenerationOptions.ResponseFormat"/> is set to <see cref="ImageResponseFormat.Base64"/>.
    /// </summary>
    /// <remarks>
    /// This property is mutually exclusive with <see cref="ImageBlobUri"/> and will be <c>null</c> when the other
    /// is present.
    /// </remarks>
    public BinaryData ImageBytes { get; }
    /// <summary>
    /// A temporary internet location for an image, provided by default or when
    /// <see cref="ImageGenerationOptions.ResponseFormat"/> is set to <see cref="ImageResponseFormat.Url"/>.
    /// </summary>
    /// <remarks>
    /// This property is mutually exclusive with <see cref="ImageBytes"/> and will be <c>null</c> when the other
    /// is present.
    /// </remarks>
    public Uri ImageBlobUri { get; }
    /// <summary>
    /// The final, revised prompt that was used to generate the result image, populated if the model performed any
    /// such revisions to the prompt.
    /// </summary>
    /// <remarks>
    /// Revisions are automatically performed to enrich image prompts and improve output quality and consistency.
    /// </remarks>
    public string RevisedPrompt { get; }
    /// <summary>
    /// The timestamp at which the result image was generated.
    /// </summary>
    public DateTimeOffset CreatedAt { get; }

    internal ImageGeneration(Internal.Models.ImagesResponse internalResponse, long internalDataIndex)
    {
        CreatedAt = internalResponse.Created;
        ImageBytes = internalResponse.Data[(int)internalDataIndex].B64Json;
        RevisedPrompt = internalResponse.Data[(int)internalDataIndex].RevisedPrompt;
        ImageBlobUri = internalResponse.Data[(int)internalDataIndex].Url;
    }
}
