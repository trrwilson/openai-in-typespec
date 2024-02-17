namespace OpenAI.Official.Embeddings;

public class EmbeddingOptions
{
    private Internal.CreateEmbeddingRequest _internalOptions;

    public EmbeddingOptions()
    {
        _internalOptions = new();
    }

    /// <inheritdoc cref="Internal.CreateEmbeddingRequest.User"/>
    public string User
    {
        get => _internalOptions.User;
        set => _internalOptions.User = value;
    }

    /// <inheritdoc cref="Internal.CreateEmbeddingRequest.Dimensions"/>
    public long? Dimensions
    {
        get => _internalOptions.Dimensions;
        set => _internalOptions.Dimensions = value;
    }
}