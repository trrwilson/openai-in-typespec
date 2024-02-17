// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Official.Internal
{
    /// <summary> The RunToolCallObject_type. </summary>
    internal readonly partial struct RunToolCallObjectType : IEquatable<RunToolCallObjectType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RunToolCallObjectType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RunToolCallObjectType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string FunctionValue = "function";

        /// <summary> function. </summary>
        public static RunToolCallObjectType Function { get; } = new RunToolCallObjectType(FunctionValue);
        /// <summary> Determines if two <see cref="RunToolCallObjectType"/> values are the same. </summary>
        public static bool operator ==(RunToolCallObjectType left, RunToolCallObjectType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RunToolCallObjectType"/> values are not the same. </summary>
        public static bool operator !=(RunToolCallObjectType left, RunToolCallObjectType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RunToolCallObjectType"/>. </summary>
        public static implicit operator RunToolCallObjectType(string value) => new RunToolCallObjectType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RunToolCallObjectType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RunToolCallObjectType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
