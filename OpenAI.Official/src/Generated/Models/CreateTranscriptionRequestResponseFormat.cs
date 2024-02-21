// <auto-generated/>

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    /// <summary> Enum for response_format in CreateTranscriptionRequest. </summary>
    public readonly partial struct CreateTranscriptionRequestResponseFormat : IEquatable<CreateTranscriptionRequestResponseFormat>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CreateTranscriptionRequestResponseFormat"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public CreateTranscriptionRequestResponseFormat(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string JsonValue = "json";
        private const string TextValue = "text";
        private const string SrtValue = "srt";
        private const string VerboseJsonValue = "verbose_json";
        private const string VttValue = "vtt";

        /// <summary> json. </summary>
        public static CreateTranscriptionRequestResponseFormat Json { get; } = new CreateTranscriptionRequestResponseFormat(JsonValue);
        /// <summary> text. </summary>
        public static CreateTranscriptionRequestResponseFormat Text { get; } = new CreateTranscriptionRequestResponseFormat(TextValue);
        /// <summary> srt. </summary>
        public static CreateTranscriptionRequestResponseFormat Srt { get; } = new CreateTranscriptionRequestResponseFormat(SrtValue);
        /// <summary> verbose_json. </summary>
        public static CreateTranscriptionRequestResponseFormat VerboseJson { get; } = new CreateTranscriptionRequestResponseFormat(VerboseJsonValue);
        /// <summary> vtt. </summary>
        public static CreateTranscriptionRequestResponseFormat Vtt { get; } = new CreateTranscriptionRequestResponseFormat(VttValue);
        /// <summary> Determines if two <see cref="CreateTranscriptionRequestResponseFormat"/> values are the same. </summary>
        public static bool operator ==(CreateTranscriptionRequestResponseFormat left, CreateTranscriptionRequestResponseFormat right) => left.Equals(right);
        /// <summary> Determines if two <see cref="CreateTranscriptionRequestResponseFormat"/> values are not the same. </summary>
        public static bool operator !=(CreateTranscriptionRequestResponseFormat left, CreateTranscriptionRequestResponseFormat right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="CreateTranscriptionRequestResponseFormat"/>. </summary>
        public static implicit operator CreateTranscriptionRequestResponseFormat(string value) => new CreateTranscriptionRequestResponseFormat(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CreateTranscriptionRequestResponseFormat other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CreateTranscriptionRequestResponseFormat other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}

