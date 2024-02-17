namespace OpenAI.Official;

public partial class EmbeddingTokenUsage
{
    private Internal.CreateEmbeddingResponseUsage _internalUsage;

    /// <inheritdoc cref="Internal.CreateEmbeddingResponseUsage.PromptTokens"/>
    public long InputTokens => _internalUsage.PromptTokens;
    /// <inheritdoc cref="Internal.CreateEmbeddingResponseUsage.TotalTokens"/>
    public long TotalTokens => _internalUsage.TotalTokens;

    internal EmbeddingTokenUsage(Internal.CreateEmbeddingResponseUsage internalUsage)
    {
        _internalUsage = internalUsage;
    }
}