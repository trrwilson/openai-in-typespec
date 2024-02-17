namespace OpenAI.Official.Chat;

// legacy, deprecated in favor of tools -- as used in request body "functions"
public class ChatFunctionDefinition
{
    public required string Name { get; set; }
    public string Description { get; set; }
    public BinaryData Parameters { get; set; }
    public ChatFunctionDefinition() { }
    [SetsRequiredMembers]
    public ChatFunctionDefinition(string name, string description = null, BinaryData parameters = null) { }
}