// <auto-generated/>

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    /// <summary> Enum for purpose in CreateFileRequest. </summary>
    internal readonly partial struct CreateFileRequestPurpose : IEquatable<CreateFileRequestPurpose>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CreateFileRequestPurpose"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public CreateFileRequestPurpose(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string FineTuneValue = "fine-tune";
        private const string AssistantsValue = "assistants";

        /// <summary> fine-tune. </summary>
        public static CreateFileRequestPurpose FineTune { get; } = new CreateFileRequestPurpose(FineTuneValue);
        /// <summary> assistants. </summary>
        public static CreateFileRequestPurpose Assistants { get; } = new CreateFileRequestPurpose(AssistantsValue);
        /// <summary> Determines if two <see cref="CreateFileRequestPurpose"/> values are the same. </summary>
        public static bool operator ==(CreateFileRequestPurpose left, CreateFileRequestPurpose right) => left.Equals(right);
        /// <summary> Determines if two <see cref="CreateFileRequestPurpose"/> values are not the same. </summary>
        public static bool operator !=(CreateFileRequestPurpose left, CreateFileRequestPurpose right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="CreateFileRequestPurpose"/>. </summary>
        public static implicit operator CreateFileRequestPurpose(string value) => new CreateFileRequestPurpose(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CreateFileRequestPurpose other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CreateFileRequestPurpose other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}

