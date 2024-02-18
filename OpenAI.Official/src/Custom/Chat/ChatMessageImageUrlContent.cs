using System.Diagnostics.CodeAnalysis;

namespace OpenAI.Official.Chat;

/// <summary>
/// Represents an item of <c>image_url</c> content, as used in the array-based <c>content</c> definition with
/// <see cref="ChatMessageContentCollection"/> that is currently only supported for use with
/// <c>gpt-4-vision-preview</c>.
/// </summary>
/// <remarks>
/// Creates a new instance of <see cref="ChatMessageImageUrlContent"/>
/// </remarks>
/// <param name="url"> The URL of the image. </param>
public class ChatMessageImageUrlContent : ChatMessageContent
{
    /// <summary>
    /// The URL of the image. This can be either an internet location accessible to the model or an embedded data URI
    /// representing a base64-encoded image.
    /// </summary>
    public required string ImageUrl { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="ChatMessageImageUrlContent"/>.
    /// </summary>
    public ChatMessageImageUrlContent()
    {
    }

    /// <summary>
    /// Creates a new instance of <see cref="ChatMessageImageUrlContent"/>.
    /// </summary>
    /// <param name="imageUrl">
    ///     The image URL, which can be an internet location accessible to the model or an embedded data URI.
    /// </param>
    [SetsRequiredMembers]
    public ChatMessageImageUrlContent(string imageUrl)
    {
        ImageUrl = imageUrl;
    }
}