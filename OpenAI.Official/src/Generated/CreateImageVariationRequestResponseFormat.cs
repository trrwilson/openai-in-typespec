// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Official.Internal
{
    /// <summary> Enum for response_format in CreateImageVariationRequest. </summary>
    internal readonly partial struct CreateImageVariationRequestResponseFormat : IEquatable<CreateImageVariationRequestResponseFormat>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CreateImageVariationRequestResponseFormat"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public CreateImageVariationRequestResponseFormat(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string UrlValue = "url";
        private const string B64JsonValue = "b64_json";

        /// <summary> url. </summary>
        public static CreateImageVariationRequestResponseFormat Url { get; } = new CreateImageVariationRequestResponseFormat(UrlValue);
        /// <summary> b64_json. </summary>
        public static CreateImageVariationRequestResponseFormat B64Json { get; } = new CreateImageVariationRequestResponseFormat(B64JsonValue);
        /// <summary> Determines if two <see cref="CreateImageVariationRequestResponseFormat"/> values are the same. </summary>
        public static bool operator ==(CreateImageVariationRequestResponseFormat left, CreateImageVariationRequestResponseFormat right) => left.Equals(right);
        /// <summary> Determines if two <see cref="CreateImageVariationRequestResponseFormat"/> values are not the same. </summary>
        public static bool operator !=(CreateImageVariationRequestResponseFormat left, CreateImageVariationRequestResponseFormat right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="CreateImageVariationRequestResponseFormat"/>. </summary>
        public static implicit operator CreateImageVariationRequestResponseFormat(string value) => new CreateImageVariationRequestResponseFormat(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CreateImageVariationRequestResponseFormat other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CreateImageVariationRequestResponseFormat other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
