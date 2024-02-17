// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Official.Internal
{
    /// <summary> Enum for model in CreateSpeechRequest. </summary>
    internal readonly partial struct CreateSpeechRequestModel : IEquatable<CreateSpeechRequestModel>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CreateSpeechRequestModel"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public CreateSpeechRequestModel(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Tts1Value = "tts-1";
        private const string Tts1HdValue = "tts-1-hd";

        /// <summary> tts-1. </summary>
        public static CreateSpeechRequestModel Tts1 { get; } = new CreateSpeechRequestModel(Tts1Value);
        /// <summary> tts-1-hd. </summary>
        public static CreateSpeechRequestModel Tts1Hd { get; } = new CreateSpeechRequestModel(Tts1HdValue);
        /// <summary> Determines if two <see cref="CreateSpeechRequestModel"/> values are the same. </summary>
        public static bool operator ==(CreateSpeechRequestModel left, CreateSpeechRequestModel right) => left.Equals(right);
        /// <summary> Determines if two <see cref="CreateSpeechRequestModel"/> values are not the same. </summary>
        public static bool operator !=(CreateSpeechRequestModel left, CreateSpeechRequestModel right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="CreateSpeechRequestModel"/>. </summary>
        public static implicit operator CreateSpeechRequestModel(string value) => new CreateSpeechRequestModel(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CreateSpeechRequestModel other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CreateSpeechRequestModel other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
