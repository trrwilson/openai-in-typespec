using System;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace OpenAI.Official.Chat;

/// <summary>
/// Represents an item of <c>image_url</c> content, as used in the array-based <c>content</c> definition with
/// <see cref="ChatMessageContentCollection"/> that is currently only supported for use with
/// <c>gpt-4-vision-preview</c>.
/// </summary>
/// <remarks>
/// Creates a new instance of <see cref="ChatMessageImageUrlContent"/>
/// </remarks>
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

    internal override void WriteTopLevel(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        throw new InvalidOperationException(
            "Image URL content items are not valid as top-level content, only within a content collection.");
    }

    internal override void WriteInCollection(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("type"u8, "image_url"u8);
        writer.WritePropertyName("image_url"u8);
        writer.WriteStartObject();
        writer.WriteString("url"u8, ImageUrl);
        writer.WriteEndObject();
        writer.WriteEndObject();
    }
}