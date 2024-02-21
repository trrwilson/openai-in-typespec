using System;

namespace OpenAI.Images;

/// <summary>
/// A representation of the quality setting for image operations that controls the level of work that the model will
/// perform.
/// </summary>
public readonly struct ImageQuality : IEquatable<ImageQuality>
{
    private readonly Internal.Models.CreateImageRequestQuality _internalQuality;

    /// <summary>
    /// Creates a new instance of <see cref="ImageQuality"/>.
    /// </summary>
    /// <param name="value"> The textual representation of the value to use. </param>
    public ImageQuality(string value)
        : this(new Internal.Models.CreateImageRequestQuality(value))
    { }

    internal ImageQuality(Internal.Models.CreateImageRequestQuality internalQuality)
    {
        _internalQuality = internalQuality;
    }

    /// <summary>
    /// The <c>hd</c> image quality that provides finer details and greater consistency but may be slower.
    /// </summary>
    public static ImageQuality High { get; } = new(Internal.Models.CreateImageRequestQuality.Hd);
    /// <summary>
    /// The <c>standard</c> image quality that provides a balanced mix of detailing, consistency, and speed.
    /// </summary>
    public static ImageQuality Balanced { get; } = new(Internal.Models.CreateImageRequestQuality.Standard);
    /// <inheritdoc/>
    public static bool operator ==(ImageQuality left, ImageQuality right)
        => left._internalQuality == right._internalQuality;
    /// <inheritdoc/>
    public static implicit operator ImageQuality(string value)
        => new ImageQuality(new Internal.Models.CreateImageRequestQuality(value));
    /// <inheritdoc/>
    public static bool operator !=(ImageQuality left, ImageQuality right)
        => left._internalQuality != right._internalQuality;
    /// <inheritdoc/>
    public bool Equals(ImageQuality other) => _internalQuality.Equals(other._internalQuality);
    /// <inheritdoc/>
    public override string ToString() => _internalQuality.ToString();
    /// <inheritdoc/>
    public override bool Equals(object obj) =>
        (obj is ImageQuality quality && this.Equals(quality)) || _internalQuality.Equals(obj);
    /// <inheritdoc/>
    public override int GetHashCode() => _internalQuality.GetHashCode();
}