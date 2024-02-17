namespace OpenAI.Official.Chat;

// legacy, deprecated in favor of tool_calls -- as present in assistant history function_call, response message function_call
public class ChatFunctionCall
{
    public required string FunctionName { get; set; }
    public required string Arguments { get; set; }
    public ChatFunctionCall() { }
    public ChatFunctionCall(string functionName, string arguments) { }
}
