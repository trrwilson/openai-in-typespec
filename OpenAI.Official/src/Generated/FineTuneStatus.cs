// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Official.Internal
{
    /// <summary> Enum for status in FineTune. </summary>
    internal readonly partial struct FineTuneStatus : IEquatable<FineTuneStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="FineTuneStatus"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public FineTuneStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string CreatedValue = "created";
        private const string RunningValue = "running";
        private const string SucceededValue = "succeeded";
        private const string FailedValue = "failed";
        private const string CancelledValue = "cancelled";

        /// <summary> created. </summary>
        public static FineTuneStatus Created { get; } = new FineTuneStatus(CreatedValue);
        /// <summary> running. </summary>
        public static FineTuneStatus Running { get; } = new FineTuneStatus(RunningValue);
        /// <summary> succeeded. </summary>
        public static FineTuneStatus Succeeded { get; } = new FineTuneStatus(SucceededValue);
        /// <summary> failed. </summary>
        public static FineTuneStatus Failed { get; } = new FineTuneStatus(FailedValue);
        /// <summary> cancelled. </summary>
        public static FineTuneStatus Cancelled { get; } = new FineTuneStatus(CancelledValue);
        /// <summary> Determines if two <see cref="FineTuneStatus"/> values are the same. </summary>
        public static bool operator ==(FineTuneStatus left, FineTuneStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="FineTuneStatus"/> values are not the same. </summary>
        public static bool operator !=(FineTuneStatus left, FineTuneStatus right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="FineTuneStatus"/>. </summary>
        public static implicit operator FineTuneStatus(string value) => new FineTuneStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is FineTuneStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(FineTuneStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
