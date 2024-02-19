using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace OpenAI.Official.Assistants;

public partial class RunTokenUsage
{
    public long InputTokens { get; }
    public long OutputTokens { get; }
    public long TotalTokens { get; }

    internal RunTokenUsage(long inputTokens, long outputTokens, long totalTokens)
    {
        InputTokens = inputTokens;
        OutputTokens = outputTokens;
        TotalTokens = totalTokens;
    }

    internal RunTokenUsage(Internal.RunCompletionUsage internalUsage)
        : this(internalUsage.PromptTokens, internalUsage.CompletionTokens, internalUsage.TotalTokens)
    {
    }
}