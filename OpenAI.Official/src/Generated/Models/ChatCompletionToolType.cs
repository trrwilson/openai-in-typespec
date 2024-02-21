// <auto-generated/>

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    /// <summary> The ChatCompletionTool_type. </summary>
    public readonly partial struct ChatCompletionToolType : IEquatable<ChatCompletionToolType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ChatCompletionToolType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ChatCompletionToolType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string FunctionValue = "function";

        /// <summary> function. </summary>
        public static ChatCompletionToolType Function { get; } = new ChatCompletionToolType(FunctionValue);
        /// <summary> Determines if two <see cref="ChatCompletionToolType"/> values are the same. </summary>
        public static bool operator ==(ChatCompletionToolType left, ChatCompletionToolType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ChatCompletionToolType"/> values are not the same. </summary>
        public static bool operator !=(ChatCompletionToolType left, ChatCompletionToolType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ChatCompletionToolType"/>. </summary>
        public static implicit operator ChatCompletionToolType(string value) => new ChatCompletionToolType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ChatCompletionToolType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ChatCompletionToolType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}

