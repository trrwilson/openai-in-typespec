using System;

namespace OpenAI.Official.Images;

/// <summary>
/// Represents the available output dimensions for generated images.
/// </summary>
public readonly struct ImageSize : IEquatable<ImageSize>
{
    private readonly Internal.CreateImageRequestSize _internalSize;

    /// <summary>
    /// Creates a new instance of <see cref="ImageSize"/>.
    /// </summary>
    /// <param name="value"> The textual representation for the <c>size</c> value. </param>
    public ImageSize(string value)
        : this(new Internal.CreateImageRequestSize(value))
    { }

    internal ImageSize(Internal.CreateImageRequestSize internalSize)
    {
        _internalSize = internalSize;
    }

    /// <summary>
    /// A square image with 1024 pixels of both width and height.
    /// <para>
    /// <b>Supported</b> and <b>default</b> for both <c>dall-e-2</c> and <c>dall-e-3</c> models.
    /// </para>
    /// </summary>
    public static ImageSize Size1024x1024 { get; } = new ImageSize(Internal.CreateImageRequestSize._1024x1024);
    /// <summary>
    /// An extra tall image, 1024 pixels wide by 1792 pixels high.
    /// <para>
    /// Supported <b>only</b> for the <c>dall-e-3</c> model.
    /// </para>
    /// </summary>
    public static ImageSize Size1024x1792 { get; } = new ImageSize(Internal.CreateImageRequestSize._1024x1792);
    /// <summary>
    /// An extra wide image, 1792 pixels wide by 1024 pixels high.
    /// <para>
    /// Supported <b>only</b> for the <c>dall-e-3</c> model.
    /// </para>
    /// </summary>
    public static ImageSize Size1792x1024 { get; } = new ImageSize(Internal.CreateImageRequestSize._1792x1024);
    /// <summary>
    /// A small, square image with 256 pixels of both width and height.
    /// <para>
    /// Supported <b>only</b> for the older <c>dall-e-2</c> model.
    /// </para>
    /// </summary>
    public static ImageSize Size256x256 { get; } = new ImageSize(Internal.CreateImageRequestSize._256x256);
    /// <summary>
    /// A medium-small, square image with 512 pixels of both width and height.
    /// <para>
    /// Supported <b>only</b> for the older <c>dall-e-2</c> model.
    /// </para>
    /// </summary>
    public static ImageSize Size512x512 { get; } = new ImageSize(Internal.CreateImageRequestSize._512x512);
    /// <inheritdoc/>
    public static bool operator ==(ImageSize left, ImageSize right) => left._internalSize == right._internalSize;
    /// <inheritdoc/>
    public static implicit operator ImageSize(string value) => new(value);
    /// <inheritdoc/>
    public static bool operator !=(ImageSize left, ImageSize right) => left._internalSize != right._internalSize;
    /// <inheritdoc/>
    public bool Equals(ImageSize other) => _internalSize.Equals(other._internalSize);
    /// <inheritdoc/>
    public override string ToString() => _internalSize.ToString();
    /// <inheritdoc/>
    public override bool Equals(object obj) => (obj is ImageSize size && Equals(size)) || _internalSize.Equals(obj);
    /// <inheritdoc/>
    public override int GetHashCode() => _internalSize.GetHashCode();
}