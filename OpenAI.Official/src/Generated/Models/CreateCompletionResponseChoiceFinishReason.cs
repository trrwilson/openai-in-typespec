// <auto-generated/>

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    /// <summary> Enum for finish_reason in CreateCompletionResponseChoice. </summary>
    public readonly partial struct CreateCompletionResponseChoiceFinishReason : IEquatable<CreateCompletionResponseChoiceFinishReason>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CreateCompletionResponseChoiceFinishReason"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public CreateCompletionResponseChoiceFinishReason(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string StopValue = "stop";
        private const string LengthValue = "length";
        private const string ContentFilterValue = "content_filter";

        /// <summary> stop. </summary>
        public static CreateCompletionResponseChoiceFinishReason Stop { get; } = new CreateCompletionResponseChoiceFinishReason(StopValue);
        /// <summary> length. </summary>
        public static CreateCompletionResponseChoiceFinishReason Length { get; } = new CreateCompletionResponseChoiceFinishReason(LengthValue);
        /// <summary> content_filter. </summary>
        public static CreateCompletionResponseChoiceFinishReason ContentFilter { get; } = new CreateCompletionResponseChoiceFinishReason(ContentFilterValue);
        /// <summary> Determines if two <see cref="CreateCompletionResponseChoiceFinishReason"/> values are the same. </summary>
        public static bool operator ==(CreateCompletionResponseChoiceFinishReason left, CreateCompletionResponseChoiceFinishReason right) => left.Equals(right);
        /// <summary> Determines if two <see cref="CreateCompletionResponseChoiceFinishReason"/> values are not the same. </summary>
        public static bool operator !=(CreateCompletionResponseChoiceFinishReason left, CreateCompletionResponseChoiceFinishReason right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="CreateCompletionResponseChoiceFinishReason"/>. </summary>
        public static implicit operator CreateCompletionResponseChoiceFinishReason(string value) => new CreateCompletionResponseChoiceFinishReason(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CreateCompletionResponseChoiceFinishReason other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CreateCompletionResponseChoiceFinishReason other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}

