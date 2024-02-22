namespace OpenAI.Images;

/// <summary>
/// A representation of the quality setting for image operations that controls the level of work that the model will
/// perform.
/// </summary>
public enum ImageQuality
{
    /// <summary>
    /// The <c>hd</c> image quality that provides finer details and greater consistency but may be slower.
    /// </summary>
    High,
    /// <summary>
    /// The <c>standard</c> image quality that provides a balanced mix of detailing, consistency, and speed.
    /// </summary>
    Balanced,
}