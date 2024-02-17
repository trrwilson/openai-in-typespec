namespace OpenAI.Official.Chat;


public readonly struct ChatFunctionConstraint : IEquatable<ChatFunctionConstraint>
{
    private readonly string _value;
    private readonly bool _isPredefined;

    public ChatFunctionConstraint(string value)
    : this(value, isPredefined: false)
    {
    }
    internal ChatFunctionConstraint(string value, bool isPredefined)
    {
        _value = value;
        _isPredefined = isPredefined;
    }
    public static ChatToolConstraint Auto { get; } = new("auto", isPredefined: true);
    public static ChatToolConstraint None { get; } = new("none", isPredefined: true);
    public static bool operator ==(ChatFunctionConstraint left, ChatFunctionConstraint right)
        => left._isPredefined == right._isPredefined && left._value == right._value;
    public static implicit operator ChatFunctionConstraint(string value) => new(value);
    public static bool operator !=(ChatFunctionConstraint left, ChatFunctionConstraint right)
        => left._isPredefined != right._isPredefined || left._value != _right._value;
    public bool Equals(ChatFunctionConstraint other)
        => other._isPredefined.Equals(_isPredefined) && other._value.Equals(_value);
    public override string ToString() => ToBinaryData().ToString();
    public override bool Equals(object obj)
        => obj is ChatFunctionConstraint constraint && constraint.Equals(this);
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
                name = _value,
            });
        }
    }

}