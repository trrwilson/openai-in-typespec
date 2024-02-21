using System;
using System.ClientModel;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Threading.Tasks;

namespace OpenAI.Official.FineTuning;

/// <summary>
///     The service client for OpenAI operations for model fine-tuning.
/// </summary>
public partial class FineTuningClient
{
    private OpenAIClientConnector _clientConnector;
    private Internal.FineTuning Shim
        => _clientConnector.InternalClient.GetFineTuningClient();

    /// <summary>
    /// Initializes a new instance of <see cref="FineTuningClient"/>, used for fine-tuning requests. 
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
    public FineTuningClient(Uri endpoint, ApiKeyCredential credential, OpenAIClientOptions options = null)
    {
        _clientConnector = new("none", endpoint, credential, options);
    }

    /// <summary>
    /// Initializes a new instance of <see cref="FineTuningClient"/>, used for fine-tuning requests. 
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
    public FineTuningClient(Uri endpoint, OpenAIClientOptions options = null)
        : this(endpoint, credential: null, options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="FineTuningClient"/>, used for fine-tuning requests. 
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
    public FineTuningClient(ApiKeyCredential credential, OpenAIClientOptions options = null)
        : this(endpoint: null, credential, options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="FineTuningClient"/>, used for fine-tuning requests. 
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
    public FineTuningClient(OpenAIClientOptions options = null)
        : this(endpoint: null, credential: null, options)
    { }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ClientResult CreateJob(BinaryContent content, RequestOptions context = null)
        => Shim.CreateFineTuningJob(content, context);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<ClientResult> CreateJobAsync(BinaryContent content, RequestOptions context = null)
        => Shim.CreateFineTuningJobAsync(content, context);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ClientResult GetJob(string jobId, RequestOptions context) => Shim.RetrieveFineTuningJob(jobId, context);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<ClientResult> GetJobAsync(string jobId, RequestOptions context)
        => Shim.RetrieveFineTuningJobAsync(jobId, context);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ClientResult GetJobs(string previousJobId, int? maxResults, RequestOptions context)
        => Shim.GetPaginatedFineTuningJobs(previousJobId, maxResults, context);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<ClientResult> GetJobsAsync(int? maxResults, string previousJobId, RequestOptions context)
        => Shim.GetPaginatedFineTuningJobsAsync(previousJobId, maxResults, context);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ClientResult GetJobEvents(string jobId, int? maxResults, string previousJobId, RequestOptions context)
        => Shim.GetFineTuningEvents(jobId, previousJobId, maxResults, context);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<ClientResult> GetJobEventsAsync(string jobId, int? maxResults, string previousJobId, RequestOptions context)
        => Shim.GetFineTuningEventsAsync(jobId, previousJobId, maxResults, context);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ClientResult CancelJob(string jobId, RequestOptions context) => Shim.CancelFineTuningJob(jobId, context);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<ClientResult> CancelJobAsync(string jobId, RequestOptions context)
        => Shim.CancelFineTuningJobAsync(jobId, context);
}
