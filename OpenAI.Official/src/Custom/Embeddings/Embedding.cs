using System;

namespace OpenAI.Official.Embeddings;

/// <summary>
/// Represents an embedding vector returned by embedding endpoint.
/// </summary>
public partial class Embedding
{
    /// <summary>
    /// The embedding vector, which is a list of floats.
    /// </summary>
    public ReadOnlyMemory<float> Vector { get; }
    /// <inheritdoc cref="Internal.Embedding.Index"/>
    public long Index { get; }
    /// <inheritdoc cref="Internal.CreateEmbeddingResponse.Usage"/>
    public EmbeddingTokenUsage Usage { get; }

    internal Embedding(ReadOnlyMemory<float> vector, long index, EmbeddingTokenUsage usage)
    {
        Vector = vector;
        Index = index;
        Usage = usage;
    }

    internal Embedding(
        Internal.CreateEmbeddingResponse internalResponse,
        long internalDataIndex,
        EmbeddingTokenUsage usage = null)
    {
        Internal.Embedding dataItem = internalResponse.Data[(int)internalDataIndex];
        string dataItemBase64 = dataItem.EmbeddingProperty.ToString();
        dataItemBase64 = dataItemBase64.Substring(1, dataItemBase64.Length - 2);
        byte[] bytes = Convert.FromBase64String(dataItemBase64);
        float[] vector = new float[bytes.Length / sizeof(float)];
        Buffer.BlockCopy(bytes, 0, vector, 0, bytes.Length);
        Vector = new ReadOnlyMemory<float>(vector);
        Index = dataItem.Index;
        Usage = usage ?? new(internalResponse.Usage);
    }
}