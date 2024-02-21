// <auto-generated/>

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    /// <summary> Enum for model in CreateImageEditRequest. </summary>
    public readonly partial struct CreateImageEditRequestModel : IEquatable<CreateImageEditRequestModel>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CreateImageEditRequestModel"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public CreateImageEditRequestModel(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string DallE2Value = "dall-e-2";

        /// <summary> dall-e-2. </summary>
        public static CreateImageEditRequestModel DallE2 { get; } = new CreateImageEditRequestModel(DallE2Value);
        /// <summary> Determines if two <see cref="CreateImageEditRequestModel"/> values are the same. </summary>
        public static bool operator ==(CreateImageEditRequestModel left, CreateImageEditRequestModel right) => left.Equals(right);
        /// <summary> Determines if two <see cref="CreateImageEditRequestModel"/> values are not the same. </summary>
        public static bool operator !=(CreateImageEditRequestModel left, CreateImageEditRequestModel right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="CreateImageEditRequestModel"/>. </summary>
        public static implicit operator CreateImageEditRequestModel(string value) => new CreateImageEditRequestModel(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CreateImageEditRequestModel other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CreateImageEditRequestModel other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}

