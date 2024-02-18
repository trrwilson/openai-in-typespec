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
public class ChatMessageImageUrlContent(string url) : ChatMessageContent
{
    /// <summary>
    /// The URL of the image.
    /// </summary>
    public string ImageUrl { get; } = url;
}