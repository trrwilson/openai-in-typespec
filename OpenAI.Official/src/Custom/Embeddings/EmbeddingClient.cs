using System;
using System.ClientModel;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI.Embeddings;

/// <summary> The service client for the OpenAI Embeddings endpoint. </summary>
public partial class EmbeddingClient
{
    private OpenAIClientConnector _clientConnector;
    private Internal.Embeddings Shim => _clientConnector.InternalClient.GetEmbeddingsClient();

    public EmbeddingClient(Uri endpoint, string model, ApiKeyCredential credential, OpenAIClientOptions options = null)
    {
        _clientConnector = new(model, endpoint, credential, options);
    }

    public EmbeddingClient(Uri endpoint, string model, OpenAIClientOptions options = null)
        : this(endpoint, model, credential: null, options)
    { }

    public EmbeddingClient(string model, ApiKeyCredential credential, OpenAIClientOptions options = null)
        : this(endpoint: null, model, credential, options)
    { }

    public EmbeddingClient(string model, OpenAIClientOptions options = null)
        : this(endpoint: null, model, credential: null, options)
    { }

     public virtual ClientResult<Embedding> GenerateEmbedding(string input, EmbeddingOptions options = null)
    {
        Internal.Models.GenerateEmbeddingsOptions request = new(
            BinaryData.FromObjectAsJson(new string[] { input }),
            new(_clientConnector.Model),
            Internal.Models.GenerateEmbeddingsOptionsEncodingFormat.Base64,
            options?.Dimensions,
            options?.User,
            serializedAdditionalRawData: null);
        ClientResult<Internal.Models.EmbeddingCollection> response = Shim.CreateEmbedding(request);
        Embedding embeddingResult = new(response.Value, internalDataIndex: 0);
        return ClientResult.FromValue(embeddingResult, response.GetRawResponse());
    }

     public virtual async Task<ClientResult<Embedding>> GenerateEmbeddingAsync(string input, EmbeddingOptions options = null)
    {
        Internal.Models.GenerateEmbeddingsOptions request = new(
            BinaryData.FromObjectAsJson(new string[] { input }),
            new(_clientConnector.Model),
            Internal.Models.GenerateEmbeddingsOptionsEncodingFormat.Base64,
            options?.Dimensions,
            options?.User,
            serializedAdditionalRawData: null);
        ClientResult<Internal.Models.EmbeddingCollection> response = await Shim.CreateEmbeddingAsync(request);
        Embedding embeddingResult = new(response.Value, internalDataIndex: 0);
        return ClientResult.FromValue(embeddingResult, response.GetRawResponse());
    }

     public virtual ClientResult<EmbeddingCollection> GenerateEmbeddings(IEnumerable<string> inputs, EmbeddingOptions options = null)
    {
        Internal.Models.GenerateEmbeddingsOptions request = new(
            BinaryData.FromObjectAsJson(inputs),
            new(_clientConnector.Model),
            Internal.Models.GenerateEmbeddingsOptionsEncodingFormat.Base64,
            options?.Dimensions,
            options?.User,
            serializedAdditionalRawData: null);
        ClientResult<Internal.Models.EmbeddingCollection> response = Shim.CreateEmbedding(request);
        EmbeddingCollection resultCollection = EmbeddingCollection.CreateFromInternalResponse(response.Value);
        return ClientResult.FromValue(resultCollection, response.GetRawResponse());
    }

     public virtual async Task<ClientResult<EmbeddingCollection>> GenerateEmbeddingsAsync(IEnumerable<string> inputs, EmbeddingOptions options = null)
    {
        Internal.Models.GenerateEmbeddingsOptions request = new(
            BinaryData.FromObjectAsJson(inputs),
            new(_clientConnector.Model),
            Internal.Models.GenerateEmbeddingsOptionsEncodingFormat.Base64,
            options?.Dimensions,
            options?.User,
            serializedAdditionalRawData: null);
        ClientResult<Internal.Models.EmbeddingCollection> response = await Shim.CreateEmbeddingAsync(request);
        EmbeddingCollection resultCollection = EmbeddingCollection.CreateFromInternalResponse(response.Value);
        return ClientResult.FromValue(resultCollection, response.GetRawResponse());
    }

    /// <inheritdoc cref="Internal.Models.Embeddings.CreateEmbedding(BinaryContent, RequestOptions)"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ClientResult GenerateEmbeddings(BinaryContent content, RequestOptions context = null)
        => Shim.CreateEmbedding(content, context);

    /// <inheritdoc cref="Internal.Models.Embeddings.CreateEmbeddingAsync(BinaryContent, RequestOptions)"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<ClientResult> GenerateEmbeddingsAsync(BinaryContent content, RequestOptions context = null)
        => Shim.CreateEmbeddingAsync(content, context);
}
