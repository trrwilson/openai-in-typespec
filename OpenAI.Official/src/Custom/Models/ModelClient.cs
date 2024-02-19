using System;
using System.ClientModel;
using System.ClientModel.Internal;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI.Official.Models;

/// <summary>
///     The service client for OpenAI model operations.
/// </summary>
public partial class ModelClient
{
    private OpenAIClientConnector _clientConnector;
    private Internal.ModelsOps Shim => _clientConnector.InternalClient.GetModelsOpsClient();

    /// <summary>
    /// Initializes a new instance of <see cref="ModelClient"/>, used for model operation requests. 
    /// </summary>
    /// <remarks>
    /// <para>
    ///     If an endpoint is not provided, the client will use the <c>OPENAI_ENDPOINT</c> environment variable if it
    ///     defined and otherwise use the default OpenAI v1 endpoint.
    /// </para>
    /// <para>
    ///    If an authentication credential is not defined, the client use the <c>OPENAI_API_KEY</c> environment variable
    ///    if it is defined.
    /// </para>
    /// </remarks>
    /// <param name="endpoint">The connection endpoint to use.</param>
    /// <param name="credential">The API key used to authenticate with the service endpoint.</param>
    /// <param name="options">Additional options to customize the client.</param>
    public ModelClient(Uri endpoint, KeyCredential credential, ModelClientOptions options = null)
    {
        _clientConnector = new("none", endpoint, credential, options);
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ModelClient"/>, used for model operation requests. 
    /// </summary>
    /// <remarks>
    /// <para>
    ///     If an endpoint is not provided, the client will use the <c>OPENAI_ENDPOINT</c> environment variable if it
    ///     defined and otherwise use the default OpenAI v1 endpoint.
    /// </para>
    /// <para>
    ///    If an authentication credential is not defined, the client use the <c>OPENAI_API_KEY</c> environment variable
    ///    if it is defined.
    /// </para>
    /// </remarks>
    /// <param name="endpoint">The connection endpoint to use.</param>
    /// <param name="options">Additional options to customize the client.</param>
    public ModelClient(Uri endpoint, ModelClientOptions options = null)
        : this(endpoint, credential: null, options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="ModelClient"/>, used for model operation requests. 
    /// </summary>
    /// <remarks>
    /// <para>
    ///     If an endpoint is not provided, the client will use the <c>OPENAI_ENDPOINT</c> environment variable if it
    ///     defined and otherwise use the default OpenAI v1 endpoint.
    /// </para>
    /// <para>
    ///    If an authentication credential is not defined, the client use the <c>OPENAI_API_KEY</c> environment variable
    ///    if it is defined.
    /// </para>
    /// </remarks>
    /// <param name="credential">The API key used to authenticate with the service endpoint.</param>
    /// <param name="options">Additional options to customize the client.</param>
    public ModelClient(KeyCredential credential, ModelClientOptions options = null)
        : this(endpoint: null, credential, options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="ModelClient"/>, used for model operation requests. 
    /// </summary>
    /// <remarks>
    /// <para>
    ///     If an endpoint is not provided, the client will use the <c>OPENAI_ENDPOINT</c> environment variable if it
    ///     defined and otherwise use the default OpenAI v1 endpoint.
    /// </para>
    /// <para>
    ///    If an authentication credential is not defined, the client use the <c>OPENAI_API_KEY</c> environment variable
    ///    if it is defined.
    /// </para>
    /// </remarks>
    /// <param name="options">Additional options to customize the client.</param>
    public ModelClient(ModelClientOptions options = null)
        : this(endpoint: null, credential: null, options)
    { }

    public virtual Result<ModelInfo> GetModelInfo(string modelId, CancellationToken cancellationToken = default)
    {
        Result<Internal.Model> internalResult = Shim.Retrieve(modelId, cancellationToken);
        return Result.FromValue(new ModelInfo(internalResult.Value), internalResult.GetRawResponse());
    }

    public virtual async Task<Result<ModelInfo>> GetModelInfoAsync(
        string modelId,
        CancellationToken cancellationToken = default)
    {
        Result<Internal.Model> internalResult = await Shim.RetrieveAsync(modelId, cancellationToken).ConfigureAwait(false);
        return Result.FromValue(new ModelInfo(internalResult.Value), internalResult.GetRawResponse());
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result GetModelInfo(string modelId, RequestOptions context)
    {
        return Shim.Retrieve(modelId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> GetModelInfoAsync(string modelId, RequestOptions context)
    {
        return Shim.RetrieveAsync(modelId, context);
    }

    public virtual Result<ModelInfoCollection> GetModels(CancellationToken cancellationToken = default)
    {
        Result<Internal.ListModelsResponse> internalResult = Shim.GetModels(cancellationToken);
        OptionalList<ModelInfo> modelEntries = [];
        foreach (Internal.Model internalModel in internalResult.Value.Data)
        {
            modelEntries.Add(new(internalModel));
        }
        return Result.FromValue(new ModelInfoCollection(modelEntries), internalResult.GetRawResponse());
    }

    public virtual async Task<Result<ModelInfoCollection>> GetModelsAsync(CancellationToken cancellationToken = default)
    {
        Result<Internal.ListModelsResponse> internalResult
            = await Shim.GetModelsAsync(cancellationToken).ConfigureAwait(false);
        OptionalList<ModelInfo> modelEntries = [];
        foreach (Internal.Model internalModel in internalResult.Value.Data)
        {
            modelEntries.Add(new(internalModel));
        }
        return Result.FromValue(new ModelInfoCollection(modelEntries), internalResult.GetRawResponse());
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result GetModels(RequestOptions context) => Shim.GetModels(context);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> GetModelsAsync(RequestOptions context) => Shim.GetModelsAsync(context);

    public virtual Result<bool> DeleteModel(string modelId, CancellationToken cancellationToken = default)
    {
        Result<Internal.DeleteModelResponse> internalResult = Shim.Delete(modelId, cancellationToken);
        return Result.FromValue(internalResult.Value.Deleted, internalResult.GetRawResponse());
    }

    public virtual async Task<Result<bool>> DeleteModelAsync(string modelId, CancellationToken cancellationToken = default)
    {
        Result<Internal.DeleteModelResponse> internalResult
            = await Shim.DeleteAsync(modelId, cancellationToken).ConfigureAwait(false);
        return Result.FromValue(internalResult.Value.Deleted, internalResult.GetRawResponse());
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result DeleteModel(string modelId, RequestOptions context) => Shim.Delete(modelId, context);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> DeleteModelAsync(string modelId, RequestOptions context) => Shim.DeleteAsync(modelId, context);
}
