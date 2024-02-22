using OpenAI.ClientShared.Internal;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Threading.Tasks;

namespace OpenAI.ModelManagement;

/// <summary>
///     The service client for OpenAI model operations.
/// </summary>
public partial class ModelManagementClient
{
    private OpenAIClientConnector _clientConnector;
    private Internal.ModelsOps Shim => _clientConnector.InternalClient.GetModelsOpsClient();
    private Internal.FineTuning FineTuningShim
        => _clientConnector.InternalClient.GetFineTuningClient();

    /// <summary>
    /// Initializes a new instance of <see cref="ModelManagementClient"/>, used for model operation requests. 
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
    public ModelManagementClient(Uri endpoint, ApiKeyCredential credential, OpenAIClientOptions options = null)
    {
        _clientConnector = new("none", endpoint, credential, options);
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ModelManagementClient"/>, used for model operation requests. 
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
    public ModelManagementClient(Uri endpoint, OpenAIClientOptions options = null)
        : this(endpoint, credential: null, options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="ModelManagementClient"/>, used for model operation requests. 
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
    public ModelManagementClient(ApiKeyCredential credential, OpenAIClientOptions options = null)
        : this(endpoint: null, credential, options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="ModelManagementClient"/>, used for model operation requests. 
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
    public ModelManagementClient(OpenAIClientOptions options = null)
        : this(endpoint: null, credential: null, options)
    { }

     public virtual ClientResult<ModelDetails> GetModelInfo(string modelId)
    {
        ClientResult<Internal.Models.Model> internalResult = Shim.Retrieve(modelId);
        return ClientResult.FromValue(new ModelDetails(internalResult.Value), internalResult.GetRawResponse());
    }

    public virtual async Task<ClientResult<ModelDetails>> GetModelInfoAsync(
        string modelId)
    {
        ClientResult<Internal.Models.Model> internalResult = await Shim.RetrieveAsync(modelId).ConfigureAwait(false);
        return ClientResult.FromValue(new ModelDetails(internalResult.Value), internalResult.GetRawResponse());
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ClientResult GetModelInfo(string modelId, RequestOptions context)
    {
        return Shim.Retrieve(modelId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<ClientResult> GetModelInfoAsync(string modelId, RequestOptions context)
    {
        return Shim.RetrieveAsync(modelId, context);
    }

    public virtual ClientResult<ModelDetailCollection> GetModels()
    {
        ClientResult<Internal.Models.ListModelsResponse> internalResult = Shim.GetModels();
        OptionalList<ModelDetails> modelEntries = [];
        foreach (Internal.Models.Model internalModel in internalResult.Value.Data)
        {
            modelEntries.Add(new(internalModel));
        }
        return ClientResult.FromValue(new ModelDetailCollection(modelEntries), internalResult.GetRawResponse());
    }

    public virtual async Task<ClientResult<ModelDetailCollection>> GetModelsAsync()
    {
        ClientResult<Internal.Models.ListModelsResponse> internalResult
            = await Shim.GetModelsAsync().ConfigureAwait(false);
        OptionalList<ModelDetails> modelEntries = [];
        foreach (Internal.Models.Model internalModel in internalResult.Value.Data)
        {
            modelEntries.Add(new(internalModel));
        }
        return ClientResult.FromValue(new ModelDetailCollection(modelEntries), internalResult.GetRawResponse());
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ClientResult GetModels(RequestOptions context) => Shim.GetModels(context);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<ClientResult> GetModelsAsync(RequestOptions context) => Shim.GetModelsAsync(context);

     public virtual ClientResult<bool> DeleteModel(string modelId)
    {
        ClientResult<Internal.Models.DeleteModelResponse> internalResult = Shim.Delete(modelId);
        return ClientResult.FromValue(internalResult.Value.Deleted, internalResult.GetRawResponse());
    }

     public virtual async Task<ClientResult<bool>> DeleteModelAsync(string modelId)
    {
        ClientResult<Internal.Models.DeleteModelResponse> internalResult
            = await Shim.DeleteAsync(modelId).ConfigureAwait(false);
        return ClientResult.FromValue(internalResult.Value.Deleted, internalResult.GetRawResponse());
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ClientResult DeleteModel(string modelId, RequestOptions context) => Shim.Delete(modelId, context);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<ClientResult> DeleteModelAsync(string modelId, RequestOptions context) => Shim.DeleteAsync(modelId, context);

    public virtual ClientResult CreateFineTuningJob(BinaryContent content, RequestOptions context = null)
        => FineTuningShim.CreateFineTuningJob(content, context);

    public virtual Task<ClientResult> CreateFineTuningJobAsync(BinaryContent content, RequestOptions context = null)
        => FineTuningShim.CreateFineTuningJobAsync(content, context);

    public virtual ClientResult GetFineTuningJob(string jobId, RequestOptions context) => FineTuningShim.RetrieveFineTuningJob(jobId, context);

    public virtual Task<ClientResult> GetFineTuningJobAsync(string jobId, RequestOptions context)
        => FineTuningShim.RetrieveFineTuningJobAsync(jobId, context);

    public virtual ClientResult GetFineTuningJobs(string previousJobId, int? maxResults, RequestOptions context)
        => FineTuningShim.GetPaginatedFineTuningJobs(previousJobId, maxResults, context);

    public virtual Task<ClientResult> GetFineTuningJobsAsync(int? maxResults, string previousJobId, RequestOptions context)
        => FineTuningShim.GetPaginatedFineTuningJobsAsync(previousJobId, maxResults, context);

    public virtual ClientResult GetFineTuningJobEvents(string jobId, int? maxResults, string previousJobId, RequestOptions context)
        => FineTuningShim.GetFineTuningEvents(jobId, previousJobId, maxResults, context);

    public virtual Task<ClientResult> GetFineTuningJobEventsAsync(string jobId, int? maxResults, string previousJobId, RequestOptions context)
        => FineTuningShim.GetFineTuningEventsAsync(jobId, previousJobId, maxResults, context);

    public virtual ClientResult CancelFineTuningJob(string jobId, RequestOptions context) => FineTuningShim.CancelFineTuningJob(jobId, context);

    public virtual Task<ClientResult> CancelFineTuningJobAsync(string jobId, RequestOptions context)
        => FineTuningShim.CancelFineTuningJobAsync(jobId, context);
}
