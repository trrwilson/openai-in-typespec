using System;
using System.ComponentModel;

namespace OpenAI.Assistants;

public readonly struct RunStatus : IEquatable<RunStatus>
{
    private readonly string _value;

    public static RunStatus Queued { get; } = new(Internal.Models.RunObjectStatus.Queued.ToString());
    public static RunStatus InProgress { get; } = new(Internal.Models.RunObjectStatus.InProgress.ToString());
    public static RunStatus RequiresAction { get; } = new(Internal.Models.RunObjectStatus.RequiresAction.ToString());
    public static RunStatus Cancelling { get; } = new(Internal.Models.RunObjectStatus.Cancelling.ToString());
    public static RunStatus CompletedSuccessfully { get; } = new(Internal.Models.RunObjectStatus.Completed.ToString());
    public static RunStatus Cancelled { get; } = new(Internal.Models.RunObjectStatus.Cancelled.ToString());
    public static RunStatus Failed { get; } = new(Internal.Models.RunObjectStatus.Failed.ToString());
    public static RunStatus Expired { get; } = new(Internal.Models.RunObjectStatus.Expired.ToString());

    public RunStatus(string status)
    {
        _value = status;
    }

    /// <summary> Determines if two <see cref="RunStatus"/> values are the same. </summary>
    public static bool operator ==(RunStatus left, RunStatus right) => left.Equals(right);
    /// <summary> Determines if two <see cref="RunStatus"/> values are not the same. </summary>
    public static bool operator !=(RunStatus left, RunStatus right) => !left.Equals(right);
    /// <summary> Converts a string to a <see cref="RunStatus"/>. </summary>
    public static implicit operator RunStatus(string value) => new RunStatus(value);

    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object obj) => obj is RunStatus other && Equals(other);
    /// <inheritdoc />
    public bool Equals(RunStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => _value?.GetHashCode() ?? 0;
    /// <inheritdoc />
    public override string ToString() => _value;
}