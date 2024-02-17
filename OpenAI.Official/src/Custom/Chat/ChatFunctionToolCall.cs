namespace OpenAI.Official.Chat;

public class ChatFunctionToolCall : ChatToolCall
{
    internal Internal.ChatCompletionMessageToolCallFunction InternalToolCall { get; };

    public required string FunctionName
    {
        get => InternalToolCall.Name;
        set => InternalToolCall.Name = value;
    }

    public required string Arguments
    {
        get => InternalToolCall.Arguments;
        set => InternalToolCall.Arguments = value;

    }
    public ChatFunctionToolCall()
    {
        InternalToolCall = new();
    }

    [SetsRequiredMembers]
    public ChatFunctionToolCall(string toolCallId, string functionName, string arguments)
        : this()
    {
        Id = toolCallId;
        FunctionName = functionName;
        Arguments = arguments;
    }
}