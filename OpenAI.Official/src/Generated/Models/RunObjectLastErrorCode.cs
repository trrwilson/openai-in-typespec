// <auto-generated/>

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    /// <summary> Enum for code in RunObjectLastError. </summary>
    public readonly partial struct RunObjectLastErrorCode : IEquatable<RunObjectLastErrorCode>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RunObjectLastErrorCode"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RunObjectLastErrorCode(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ServerErrorValue = "server_error";
        private const string RateLimitExceededValue = "rate_limit_exceeded";

        /// <summary> server_error. </summary>
        public static RunObjectLastErrorCode ServerError { get; } = new RunObjectLastErrorCode(ServerErrorValue);
        /// <summary> rate_limit_exceeded. </summary>
        public static RunObjectLastErrorCode RateLimitExceeded { get; } = new RunObjectLastErrorCode(RateLimitExceededValue);
        /// <summary> Determines if two <see cref="RunObjectLastErrorCode"/> values are the same. </summary>
        public static bool operator ==(RunObjectLastErrorCode left, RunObjectLastErrorCode right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RunObjectLastErrorCode"/> values are not the same. </summary>
        public static bool operator !=(RunObjectLastErrorCode left, RunObjectLastErrorCode right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RunObjectLastErrorCode"/>. </summary>
        public static implicit operator RunObjectLastErrorCode(string value) => new RunObjectLastErrorCode(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RunObjectLastErrorCode other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RunObjectLastErrorCode other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}

