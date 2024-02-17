// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Official.Internal
{
    /// <summary> Enum for type in RunStepObject. </summary>
    internal readonly partial struct RunStepObjectType : IEquatable<RunStepObjectType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RunStepObjectType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RunStepObjectType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string MessageCreationValue = "message_creation";
        private const string ToolCallsValue = "tool_calls";

        /// <summary> message_creation. </summary>
        public static RunStepObjectType MessageCreation { get; } = new RunStepObjectType(MessageCreationValue);
        /// <summary> tool_calls. </summary>
        public static RunStepObjectType ToolCalls { get; } = new RunStepObjectType(ToolCallsValue);
        /// <summary> Determines if two <see cref="RunStepObjectType"/> values are the same. </summary>
        public static bool operator ==(RunStepObjectType left, RunStepObjectType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RunStepObjectType"/> values are not the same. </summary>
        public static bool operator !=(RunStepObjectType left, RunStepObjectType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RunStepObjectType"/>. </summary>
        public static implicit operator RunStepObjectType(string value) => new RunStepObjectType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RunStepObjectType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RunStepObjectType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
