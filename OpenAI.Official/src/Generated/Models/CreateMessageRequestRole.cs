// <auto-generated/>

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    /// <summary> The CreateMessageRequest_role. </summary>
    internal readonly partial struct CreateMessageRequestRole : IEquatable<CreateMessageRequestRole>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CreateMessageRequestRole"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public CreateMessageRequestRole(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string UserValue = "user";

        /// <summary> user. </summary>
        public static CreateMessageRequestRole User { get; } = new CreateMessageRequestRole(UserValue);
        /// <summary> Determines if two <see cref="CreateMessageRequestRole"/> values are the same. </summary>
        public static bool operator ==(CreateMessageRequestRole left, CreateMessageRequestRole right) => left.Equals(right);
        /// <summary> Determines if two <see cref="CreateMessageRequestRole"/> values are not the same. </summary>
        public static bool operator !=(CreateMessageRequestRole left, CreateMessageRequestRole right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="CreateMessageRequestRole"/>. </summary>
        public static implicit operator CreateMessageRequestRole(string value) => new CreateMessageRequestRole(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CreateMessageRequestRole other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CreateMessageRequestRole other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}

