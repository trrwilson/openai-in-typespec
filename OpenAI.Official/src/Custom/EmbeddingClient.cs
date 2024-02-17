using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI.Official;

/// <summary> The service client for the OpenAI Embeddings endpoint. </summary>
public partial class EmbeddingClient
{
    private OpenAIClientConnector _clientConnector;
    private Internal.Embeddings Shim => _clientConnector.InternalClient.GetEmbeddingsClient();

    public EmbeddingClient(Uri endpoint, string model, KeyCredential credential, EmbeddingClientOptions options = null)
    {
        _clientConnector = new(model, endpoint, credential, options);
    }

    public EmbeddingClient(Uri endpoint, string model, EmbeddingClientOptions options = null)
        : this(endpoint, model, credential: null, options)
    { }

    public EmbeddingClient(string model, KeyCredential credential, EmbeddingClientOptions options = null)
        : this(endpoint: null, model, credential, options)
    { }

    public EmbeddingClient(string model, EmbeddingClientOptions options = null)
        : this(endpoint: null, model, credential: null, options)
    { }

    public virtual Result<Embedding> GenerateEmbedding(string input, EmbeddingOptions options = null, CancellationToken cancellationToken = default)
    {
        Internal.CreateEmbeddingRequest request = new(
            BinaryData.FromObjectAsJson(new string[] { input }),
            new(_clientConnector.Model),
            Internal.CreateEmbeddingRequestEncodingFormat.Base64,
            options?.Dimensions,
            options?.User,
            serializedAdditionalRawData: null);
        Result<Internal.CreateEmbeddingResponse> response = Shim.CreateEmbedding(request, cancellationToken);
        Embedding embeddingResult = new(response.Value, internalDataIndex: 0);
        return Result.FromValue(embeddingResult, response.GetRawResponse());
    }

    public virtual async Task<Result<Embedding>> GenerateEmbeddingAsync(string input, EmbeddingOptions options = null, CancellationToken cancellationToken = default)
    {
        Internal.CreateEmbeddingRequest request = new(
            BinaryData.FromObjectAsJson(new string[] { input }),
            new(_clientConnector.Model),
            Internal.CreateEmbeddingRequestEncodingFormat.Base64,
            options?.Dimensions,
            options?.User,
            serializedAdditionalRawData: null);
        Result<Internal.CreateEmbeddingResponse> response = await Shim.CreateEmbeddingAsync(request, cancellationToken);
        Embedding embeddingResult = new(response.Value, internalDataIndex: 0);
        return Result.FromValue(embeddingResult, response.GetRawResponse());
    }

    public virtual Result<EmbeddingCollection> GenerateEmbeddings(IEnumerable<string> inputs, EmbeddingOptions options = null, CancellationToken cancellationToken = default)
    {
        Internal.CreateEmbeddingRequest request = new(
            BinaryData.FromObjectAsJson(inputs),
            new(_clientConnector.Model),
            Internal.CreateEmbeddingRequestEncodingFormat.Base64,
            options?.Dimensions,
            options?.User,
            serializedAdditionalRawData: null);
        Result<Internal.CreateEmbeddingResponse> response = Shim.CreateEmbedding(request, cancellationToken);
        EmbeddingCollection resultCollection = EmbeddingCollection.CreateFromInternalResponse(response.Value);
        return Result.FromValue(resultCollection, response.GetRawResponse());
    }

    public virtual async Task<Result<EmbeddingCollection>> GenerateEmbeddingsAsync(IEnumerable<string> inputs, EmbeddingOptions options = null, CancellationToken cancellationToken = default)
    {
        Internal.CreateEmbeddingRequest request = new(
            BinaryData.FromObjectAsJson(inputs),
            new(_clientConnector.Model),
            Internal.CreateEmbeddingRequestEncodingFormat.Base64,
            options?.Dimensions,
            options?.User,
            serializedAdditionalRawData: null);
        Result<Internal.CreateEmbeddingResponse> response = await Shim.CreateEmbeddingAsync(request, cancellationToken);
        EmbeddingCollection resultCollection = EmbeddingCollection.CreateFromInternalResponse(response.Value);
        return Result.FromValue(resultCollection, response.GetRawResponse());
    }

    /// <inheritdoc cref="Internal.Embeddings.CreateEmbedding(RequestBody, RequestOptions)"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result GenerateEmbeddings(RequestBody content, RequestOptions context = null)
        => Shim.CreateEmbedding(content, context);

    /// <inheritdoc cref="Internal.Embeddings.CreateEmbeddingAsync(RequestBody, RequestOptions)"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> GenerateEmbeddingsAsync(RequestBody content, RequestOptions context = null)
        => Shim.CreateEmbeddingAsync(content, context);
}
