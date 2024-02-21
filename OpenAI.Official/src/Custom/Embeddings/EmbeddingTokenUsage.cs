namespace OpenAI.Embeddings;

public partial class EmbeddingTokenUsage
{
    private Internal.Models.EmbeddingTokenUsage _internalUsage;

    /// <inheritdoc cref="Internal.Models.EmbeddingCollectionUsage.PromptTokens"/>
    public long InputTokens => _internalUsage.PromptTokens;
    /// <inheritdoc cref="Internal.Models.EmbeddingCollectionUsage.TotalTokens"/>
    public long TotalTokens => _internalUsage.TotalTokens;

    internal EmbeddingTokenUsage(Internal.Models.EmbeddingTokenUsage internalUsage)
    {
        _internalUsage = internalUsage;
    }
}