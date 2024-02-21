using System;

namespace OpenAI.Official.Images;

/// <summary>
/// The style of the generated images. Must be one of vivid or natural. Vivid causes the model to lean towards
/// generating hyper-real and dramatic images. Natural causes the model to produce more natural, less hyper-real
/// looking images. This param is only supported for <c>dall-e-3</c>.
/// </summary>
public readonly partial struct ImageStyle : IEquatable<ImageStyle>
{
    private readonly Internal.Models.CreateImageRequestStyle _internalStyle;

    /// <summary>
    /// Creates a new instance of <see cref="ImageStyle"/>.
    /// </summary>
    /// <param name="value"> The textual value for the style. </param>
    public ImageStyle(string value)
        : this(new Internal.Models.CreateImageRequestStyle(value))
    { }

    internal ImageStyle(Internal.Models.CreateImageRequestStyle internalStyle)
    {
        _internalStyle = internalStyle;
    }

    /// <summary>
    /// The <c>natural</c> style, with which the model will not tend towards hyper-realistic, dramatic imagery.
    /// </summary>
    public static ImageStyle Natural { get; } = new(Internal.Models.CreateImageRequestStyle.Natural);
    /// <summary>
    /// The <c>vivid</c> style, with which the model will tend towards hyper-realistic, dramatic imagery.
    /// </summary>
    public static ImageStyle Vivid { get; } = new(Internal.Models.CreateImageRequestStyle.Vivid);
    /// <inheritdoc/>
    public static bool operator ==(ImageStyle left, ImageStyle right) => left._internalStyle == right._internalStyle;
    /// <inheritdoc/>
    public static implicit operator ImageStyle(string value) => new(value);
    /// <inheritdoc/>
    public static bool operator !=(ImageStyle left, ImageStyle right) => left._internalStyle != right._internalStyle;
    /// <inheritdoc/>
    public bool Equals(ImageStyle other) => _internalStyle.Equals(other._internalStyle);
    /// <inheritdoc/>
    public override string ToString() => _internalStyle.ToString();
    /// <inheritdoc/>
    public override bool Equals(object obj) =>
        (obj is ImageStyle style && Equals(style)) || _internalStyle.Equals(obj);
    /// <inheritdoc/>
    public override int GetHashCode() => _internalStyle.GetHashCode();
}