namespace OpenAI.Official;

public class EmbeddingOptions
{
    private Internal.CreateEmbeddingRequest _internalOptions;

    public EmbeddingOptions()
    {
        _internalOptions = new();
    }

    /// <inheritdoc cref="Internal.CreateEmbeddingRequest.User"/>
    public string User => _internalOptions.User;

    /// <inheritdoc cref="Internal.CreateEmbeddingRequest.Dimensions"/>
    public long? Dimensions => _internalOptions.Dimensions;
}