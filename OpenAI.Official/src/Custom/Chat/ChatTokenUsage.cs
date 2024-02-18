namespace OpenAI.Official.Chat;

/// <summary>
/// Represents computed token consumption statistics for a chat completion request.
/// </summary>
public class ChatTokenUsage
{
    /// <inheritdoc cref="Internal.CompletionUsage.PromptTokens"/>
    public long InputTokens { get; }
    /// <inheritdoc cref="Internal.CompletionUsage.CompletionTokens"/>
    public long OutputTokens { get; }
    /// <inheritdoc cref="Internal.CompletionUsage.TotalTokens"/>
    public long TotalTokens { get; }

    internal ChatTokenUsage(Internal.CompletionUsage internalUsage)
    {
        InputTokens = internalUsage.PromptTokens;
        OutputTokens = internalUsage.CompletionTokens;
        TotalTokens = internalUsage.TotalTokens;
    }
}