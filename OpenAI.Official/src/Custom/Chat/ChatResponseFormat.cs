using System;

namespace OpenAI.Official.Chat;

public readonly struct ChatResponseFormat : IEquatable<ChatResponseFormat>
{
    private readonly string _value;
    public ChatResponseFormat(string value)
    {
        _value = value;
    }
    public static ChatResponseFormat Text { get; } = new("text");
    public static ChatResponseFormat JsonObject { get; } = new("json_object");
    public static bool operator ==(ChatResponseFormat left, ChatResponseFormat right)
        => left._value == right._value;
    public static implicit operator ChatResponseFormat(string value) => new(value); 
    public static bool operator !=(ChatResponseFormat left, ChatResponseFormat right)
        => left._value != right._value;
    public bool Equals(ChatResponseFormat other) => _value == other._value;
    public override string ToString() => _value;
    public override bool Equals(object obj)
        => (obj is ChatResponseFormat format && format._value == _value)
        || (obj is string formatString && formatString == _value);
    public override int GetHashCode() => _value.GetHashCode();
}