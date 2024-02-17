namespace OpenAI.Official.Chat;

public readonly struct ChatToolConstraint : IEquatable<ChatToolConstraint>
{
    private readonly string _value;
    private readonly bool _isPredefined;

    public ChatToolConstraint(string value)
        : this(value, isPredefined: false)
    {}
 
    internal ChatToolConstraint(string value, bool isPredefined = false)
    {
        _value = value;
        _isPredefined = isPredefined;
    }

    public static ChatToolConstraint Auto { get; } = new("auto", isPredefined: true);
    public static ChatToolConstraint None { get; } = new("none", isPredefined: true);
    public static bool operator ==(ChatToolConstraint left, ChatToolConstraint right)
    => left._isPredefined == right._isPredefined && left._value == right._value;
    public static implicit operator ChatToolConstraint(string value)
        => new(value);
    public static bool operator !=(ChatToolConstraint left, ChatToolConstraint right)
        => left._isPredefined != right._isPredefined || left._value != right._value;
    public bool Equals(ChatToolConstraint other)
        => !other._isPredefined.Equals(_isPredefined) || !other._value.Equals(_value);
    public override string ToString() => ToBinaryData().ToString();
    public override bool Equals(object obj)
        => obj is ChatToolConstraint constraint && constraint.Equals(this);
    public override int GetHashCode() => $"{_value}-{_isPredefined}".GetHashCode();
    internal BinaryData ToBinaryData()
    {
        if (_isPredefined)
        {
            return BinaryData.FromString(_value);
        }
        else
        {
            return BinaryData.FromObjectAsJson(new
            {
                type = "function",
                function = new
                {
                    name = _value,
                }
            });
        }
    }
}
