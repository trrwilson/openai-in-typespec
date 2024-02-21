// <auto-generated/>

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    /// <summary> Enum for style in CreateImageRequest. </summary>
    internal readonly partial struct CreateImageRequestStyle : IEquatable<CreateImageRequestStyle>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CreateImageRequestStyle"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public CreateImageRequestStyle(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string VividValue = "vivid";
        private const string NaturalValue = "natural";

        /// <summary> vivid. </summary>
        public static CreateImageRequestStyle Vivid { get; } = new CreateImageRequestStyle(VividValue);
        /// <summary> natural. </summary>
        public static CreateImageRequestStyle Natural { get; } = new CreateImageRequestStyle(NaturalValue);
        /// <summary> Determines if two <see cref="CreateImageRequestStyle"/> values are the same. </summary>
        public static bool operator ==(CreateImageRequestStyle left, CreateImageRequestStyle right) => left.Equals(right);
        /// <summary> Determines if two <see cref="CreateImageRequestStyle"/> values are not the same. </summary>
        public static bool operator !=(CreateImageRequestStyle left, CreateImageRequestStyle right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="CreateImageRequestStyle"/>. </summary>
        public static implicit operator CreateImageRequestStyle(string value) => new CreateImageRequestStyle(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CreateImageRequestStyle other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CreateImageRequestStyle other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}

