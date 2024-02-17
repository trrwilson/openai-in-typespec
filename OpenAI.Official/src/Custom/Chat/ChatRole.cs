using System;

namespace OpenAI.Official.Chat;

public readonly struct ChatRole : IEquatable<ChatRole>
{
    private readonly string _value;

    public ChatRole(string value)
    {
        _value = value;
    }

    public static ChatRole System { get; } = new("system");
    public static ChatRole Assistant { get; } = new("assistant");
    public static ChatRole User { get; } = new("user");
    public static ChatRole Tool { get; } = new("tool");
    public static ChatRole Function { get; } = new("function");
    public static bool operator ==(ChatRole left, ChatRole right)
        => left._value == right._value;
    public static implicit operator ChatRole(string value) => new(value);
    public static bool operator !=(ChatRole left, ChatRole right)
        => left._value != right._value;
    public bool Equals(ChatRole other) => other._value.Equals(_value);
    public override string ToString() => _value;
    public override bool Equals(object obj)
        => (obj is ChatRole role && role._value == _value)
        || (obj is string roleString && roleString == _value);
    public override int GetHashCode() => _value.GetHashCode();
}