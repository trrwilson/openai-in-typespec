using OpenAI.Official.Chat;
using System;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.Official.Assistants;

public partial class ToolOutput
{
    public required string Id { get; set; }
    public string Output { get; set; }

    public ToolOutput()
    { }

    [SetsRequiredMembers]
    public ToolOutput(string toolCallId, string output = null)
    {
        Id = toolCallId;
        Output = output;
    }

    [SetsRequiredMembers]
    public ToolOutput(RequiredToolCall toolCall, string output = null)
        : this(toolCall.Id, output)
    { }
}
