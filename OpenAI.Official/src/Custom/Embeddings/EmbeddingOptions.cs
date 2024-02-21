namespace OpenAI.Embeddings;

public class EmbeddingOptions
{
    private Internal.Models.GenerateEmbeddingsOptions _internalOptions;

    public EmbeddingOptions()
    {
        _internalOptions = new();
    }

    /// <inheritdoc cref="Internal.Models.GenerateEmbeddingsOptions.User"/>
    public string User
    {
        get => _internalOptions.User;
        set => _internalOptions.User = value;
    }

    /// <inheritdoc cref="Internal.Models.GenerateEmbeddingsOptions.Dimensions"/>
    public long? Dimensions
    {
        get => _internalOptions.Dimensions;
        set => _internalOptions.Dimensions = value;
    }
}