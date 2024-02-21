using System;

namespace OpenAI.Images;

/// <summary>
/// Represents the available output methods for generated images.
/// <list type="bullet">
/// <item>
///     <c>url</c> - <see cref="ImageResponseFormat.Url"/> - Default, provides a temporary internet location that
///     the generated image can be retrieved from.
/// </item>
/// <item>
///     <c>b64_json</c> - <see cref="ImageResponseFormat.Base64"/> - Provides the full image data on the response,
///     encoded in the result as a base64 string. This offers the fastest round trip time but can drastically
///     increase the size of response payloads.
/// </item>
/// </list>
/// </summary>
public readonly struct ImageResponseFormat : IEquatable<ImageResponseFormat>
{
    private readonly Internal.Models.CreateImageRequestResponseFormat _internalFormat;

    /// <summary>
    /// Creates a new instance of <see cref="ImageResponseFormat"/>.
    /// </summary>
    /// <param name="value"> The text representation of a <c>response_format</c> value. </param>
    public ImageResponseFormat(string value)
        : this(new Internal.Models.CreateImageRequestResponseFormat(value))
    { }

    internal ImageResponseFormat(Internal.Models.CreateImageRequestResponseFormat internalFormat)
    {
        _internalFormat = internalFormat;
    }

    /// <summary>
    /// Instructs the request to return image data directly on the response, encoded as a base64 string in the response
    /// JSON. This minimizes availability time but drastically increases the size of responses, required bandwidth, and
    /// immediate memory needs.
    /// </summary>
    public static ImageResponseFormat Base64 { get; } = new ImageResponseFormat(Internal.Models.CreateImageRequestResponseFormat.B64Json);
    /// <summary>
    /// The default setting that instructs the request to return a temporary internet location from which the image can
    /// be retrieved.
    /// </summary>
    public static ImageResponseFormat Url { get; } = new ImageResponseFormat(Internal.Models.CreateImageRequestResponseFormat.Url);
    /// <inheritdoc/>
    public static bool operator ==(ImageResponseFormat left, ImageResponseFormat right)
        => left._internalFormat == right._internalFormat;
    /// <inheritdoc/>
    public static implicit operator ImageResponseFormat(string value) => new(value);
    /// <inheritdoc/>
    public static bool operator !=(ImageResponseFormat left, ImageResponseFormat right)
        => left._internalFormat != right._internalFormat;
    /// <inheritdoc/>
    public bool Equals(ImageResponseFormat other) => _internalFormat.Equals(other._internalFormat);
    /// <inheritdoc/>
    public override string ToString() => _internalFormat.ToString();
    /// <inheritdoc/>
    public override bool Equals(object obj) => (obj is ImageResponseFormat format && Equals(format)) || _internalFormat.Equals(obj);
    /// <inheritdoc/>
    public override int GetHashCode() => _internalFormat.GetHashCode();
}