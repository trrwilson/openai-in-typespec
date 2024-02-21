// <auto-generated/>

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    /// <summary> The RunObjectRequiredAction_type. </summary>
    internal readonly partial struct RunObjectRequiredActionType : IEquatable<RunObjectRequiredActionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RunObjectRequiredActionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RunObjectRequiredActionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string SubmitToolOutputsValue = "submit_tool_outputs";

        /// <summary> submit_tool_outputs. </summary>
        public static RunObjectRequiredActionType SubmitToolOutputs { get; } = new RunObjectRequiredActionType(SubmitToolOutputsValue);
        /// <summary> Determines if two <see cref="RunObjectRequiredActionType"/> values are the same. </summary>
        public static bool operator ==(RunObjectRequiredActionType left, RunObjectRequiredActionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RunObjectRequiredActionType"/> values are not the same. </summary>
        public static bool operator !=(RunObjectRequiredActionType left, RunObjectRequiredActionType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RunObjectRequiredActionType"/>. </summary>
        public static implicit operator RunObjectRequiredActionType(string value) => new RunObjectRequiredActionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RunObjectRequiredActionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RunObjectRequiredActionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}

