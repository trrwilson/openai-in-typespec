using System;

namespace OpenAI.Official.Chat;

public class ChatFunctionToolDefinition : ChatToolDefinition
{
    public required string Name { get; set; }
    public string Description { get; set; }
    public BinaryData Parameters { get; set; }
    public ChatFunctionToolDefinition() { }
    [SetsRequiredMembers]
    public ChatFunctionToolDefinition(string name, string description = null, BinaryData parameters = null)
    {
        Name = name;
        Description = description;
        Parameters = parameters;
    }
}