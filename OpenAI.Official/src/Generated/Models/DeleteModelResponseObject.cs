// <auto-generated/>

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    /// <summary> The DeleteModelResponse_object. </summary>
    internal readonly partial struct DeleteModelResponseObject : IEquatable<DeleteModelResponseObject>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DeleteModelResponseObject"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public DeleteModelResponseObject(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ModelValue = "model";

        /// <summary> model. </summary>
        public static DeleteModelResponseObject Model { get; } = new DeleteModelResponseObject(ModelValue);
        /// <summary> Determines if two <see cref="DeleteModelResponseObject"/> values are the same. </summary>
        public static bool operator ==(DeleteModelResponseObject left, DeleteModelResponseObject right) => left.Equals(right);
        /// <summary> Determines if two <see cref="DeleteModelResponseObject"/> values are not the same. </summary>
        public static bool operator !=(DeleteModelResponseObject left, DeleteModelResponseObject right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="DeleteModelResponseObject"/>. </summary>
        public static implicit operator DeleteModelResponseObject(string value) => new DeleteModelResponseObject(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is DeleteModelResponseObject other && Equals(other);
        /// <inheritdoc />
        public bool Equals(DeleteModelResponseObject other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}

