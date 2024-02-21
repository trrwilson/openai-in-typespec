// <auto-generated/>

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    /// <summary> The RunObject_object. </summary>
    public readonly partial struct RunObjectObject : IEquatable<RunObjectObject>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RunObjectObject"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RunObjectObject(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ThreadRunValue = "thread.run";

        /// <summary> thread.run. </summary>
        public static RunObjectObject ThreadRun { get; } = new RunObjectObject(ThreadRunValue);
        /// <summary> Determines if two <see cref="RunObjectObject"/> values are the same. </summary>
        public static bool operator ==(RunObjectObject left, RunObjectObject right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RunObjectObject"/> values are not the same. </summary>
        public static bool operator !=(RunObjectObject left, RunObjectObject right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RunObjectObject"/>. </summary>
        public static implicit operator RunObjectObject(string value) => new RunObjectObject(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RunObjectObject other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RunObjectObject other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}

