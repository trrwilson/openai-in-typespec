using System;
using System.ClientModel;
using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.ClientModel.Primitives.Pipeline;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI.Official.Assistants;

/// <summary>
///     The service client for OpenAI assistants.
/// </summary>
public partial class AssistantClient
{
    private OpenAIClientConnector _clientConnector;
    private Internal.Assistants Shim => _clientConnector.InternalClient.GetAssistantsClient();
    private Internal.Threads ThreadShim => _clientConnector.InternalClient.GetThreadsClient();
    private Internal.Messages MessageShim => _clientConnector.InternalClient.GetMessagesClient();
    private Internal.Runs RunShim => _clientConnector.InternalClient.GetRunsClient();

    /// <summary>
    /// Initializes a new instance of <see cref="AssistantClient"/>, used for assistant requests. 
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
    public AssistantClient(Uri endpoint, KeyCredential credential, AssistantClientOptions options = null)
    {
        options ??= new();
        options.PerTryPolicies =
        [
            .. options.PerTryPolicies ?? [],
            new GenericActionPipelinePolicy((m) => m.Request?.SetHeaderValue("OpenAI-Beta", "assistants=v1")),
        ];
        _clientConnector = new("none", endpoint, credential, options);
    }

    /// <summary>
    /// Initializes a new instance of <see cref="AssistantClient"/>, used for assistant requests. 
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
    public AssistantClient(Uri endpoint, AssistantClientOptions options = null)
        : this(endpoint, credential: null, options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="AssistantClient"/>, used for assistant requests. 
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
    public AssistantClient(KeyCredential credential, AssistantClientOptions options = null)
        : this(endpoint: null, credential, options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="AssistantClient"/>, used for assistant requests. 
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
    public AssistantClient(AssistantClientOptions options = null)
        : this(endpoint: null, credential: null, options)
    { }

    public virtual Result<Assistant> CreateAssistant(string modelName, AssistantCreationOptions options = null, CancellationToken cancellationToken = default)
    {
        Internal.CreateAssistantRequest request = CreateInternalCreateAssistantRequest(modelName, options);
        Result<Internal.AssistantObject> internalResult = Shim.CreateAssistant(request, cancellationToken);
        return Result.FromValue(new Assistant(internalResult.Value), internalResult.GetRawResponse());
    }

    public virtual async Task<Result<Assistant>> CreateAssistantAsync(string modelName, AssistantCreationOptions options = null, CancellationToken cancellationToken = default)
    {
        Internal.CreateAssistantRequest request = CreateInternalCreateAssistantRequest(modelName, options);
        Result<Internal.AssistantObject> internalResult
            = await Shim.CreateAssistantAsync(request, cancellationToken).ConfigureAwait(false);
        return Result.FromValue(new Assistant(internalResult.Value), internalResult.GetRawResponse());
    }

    public virtual Result<Assistant> GetAssistant(string assistantId, CancellationToken cancellationToken = default)
    {
        Result<Internal.AssistantObject> internalResult = Shim.GetAssistant(assistantId, cancellationToken);
        return Result.FromValue(new Assistant(internalResult.Value), internalResult.GetRawResponse());
    }

    public virtual async Task<Result<Assistant>> GetAssistantAsync(
        string assistantId,
        CancellationToken cancellationToken = default)
    {
        Result<Internal.AssistantObject> internalResult
            = await Shim.GetAssistantAsync(assistantId, cancellationToken).ConfigureAwait(false);
        return Result.FromValue(new Assistant(internalResult.Value), internalResult.GetRawResponse());
    }

    public virtual Result<ListQueryPage<Assistant>> GetAssistants(
        int? maxResults = null,
        CreatedAtSortOrder? createdSortOrder = null,
        string previousAssistantId = null,
        string subsequentAssistantId = null,
        CancellationToken cancellationToken = default)
    {
        Result<Internal.ListAssistantsResponse> internalFunc() => Shim.GetAssistants(
            maxResults,
            ToInternalListOrder(createdSortOrder),
            previousAssistantId,
            subsequentAssistantId,
            cancellationToken);
        return GetListQueryPage<Assistant, Internal.ListAssistantsResponse>(internalFunc);
    }

    public virtual Task<Result<ListQueryPage<Assistant>>> GetAssistantsAsync(
        int? maxResults = null,
        CreatedAtSortOrder? createdSortOrder = null,
        string previousAssistantId = null,
        string subsequentAssistantId = null,
        CancellationToken cancellationToken = default)
    {
        Task<Result<Internal.ListAssistantsResponse>> internalAsyncFunc() => Shim.GetAssistantsAsync(
            maxResults,
            ToInternalListOrder(createdSortOrder),
            previousAssistantId,
            subsequentAssistantId,
            cancellationToken);
        return GetListQueryPageAsync<Assistant, Internal.ListAssistantsResponse>(internalAsyncFunc);
    }

    public virtual Result<Assistant> ModifyAssistant(
        string assistantId,
        AssistantModificationOptions options,
        CancellationToken cancellationToken = default)
    {
        Result<Internal.AssistantObject> internalResult
            = Shim.ModifyAssistant(assistantId, CreateInternalModifyAssistantRequest(options), cancellationToken);
        return Result.FromValue(new Assistant(internalResult.Value), internalResult.GetRawResponse());
    }

    public virtual async Task<Result<Assistant>> ModifyAssistantAsync(
        string assistantId,
        AssistantModificationOptions options,
        CancellationToken cancellationToken = default)
    {
        Internal.ModifyAssistantRequest request = CreateInternalModifyAssistantRequest(options);
        Result<Internal.AssistantObject> internalResult
            = await Shim.ModifyAssistantAsync(assistantId, request, cancellationToken).ConfigureAwait(false);
        return Result.FromValue(new Assistant(internalResult.Value), internalResult.GetRawResponse());
    }

    public virtual Result<bool> DeleteAssistant(string assistantId, CancellationToken cancellationToken = default)
    {
        Result<Internal.DeleteAssistantResponse> internalResponse = Shim.DeleteAssistant(assistantId, cancellationToken);
        return Result.FromValue(internalResponse.Value.Deleted, internalResponse.GetRawResponse());
    }

    public virtual async Task<Result<bool>> DeleteAssistantAsync(
        string assistantId,
        CancellationToken cancellationToken = default)
    {
        Result<Internal.DeleteAssistantResponse> internalResponse
            = await Shim.DeleteAssistantAsync(assistantId, cancellationToken).ConfigureAwait(false);
        return Result.FromValue(internalResponse.Value.Deleted, internalResponse.GetRawResponse());
    }

    public virtual Result<AssistantFileAssociation> CreateAssistantFileAssociation(
        string assistantId,
        string fileId,
        CancellationToken cancellationToken = default)
    {
        Result<Internal.AssistantFileObject> internalResult
            = Shim.CreateAssistantFile(assistantId, new(fileId), cancellationToken);
        return Result.FromValue(new AssistantFileAssociation(internalResult.Value), internalResult.GetRawResponse());
    }

    public virtual async Task<Result<AssistantFileAssociation>> CreateAssistantFileAssociationAsync(
        string assistantId,
        string fileId,
    CancellationToken cancellationToken = default)
    {
        Result<Internal.AssistantFileObject> internalResult
            = await Shim.CreateAssistantFileAsync(assistantId, new(fileId), cancellationToken).ConfigureAwait(false);
        return Result.FromValue(new AssistantFileAssociation(internalResult.Value), internalResult.GetRawResponse());
    }

    public virtual Result<AssistantFileAssociation> GetAssistantFileAssociation(
        string assistantId,
        string fileId,
        CancellationToken cancellationToken = default)
    {
        Result<Internal.AssistantFileObject> internalResult = Shim.GetAssistantFile(assistantId, fileId, cancellationToken);
        return Result.FromValue(new AssistantFileAssociation(internalResult.Value), internalResult.GetRawResponse());
    }

    public virtual async Task<Result<AssistantFileAssociation>> GetAssistantFileAssociationAsync(
        string assistantId,
        string fileId,
        CancellationToken cancellationToken = default)
    {
        Result<Internal.AssistantFileObject> internalResult
            = await Shim.GetAssistantFileAsync(assistantId, fileId, cancellationToken).ConfigureAwait(false);
        return Result.FromValue(new AssistantFileAssociation(internalResult.Value), internalResult.GetRawResponse());
    }

    public virtual Result<ListQueryPage<AssistantFileAssociation>> GetAssistantFileAssociations(
        string assistantId,
        int? maxResults = null,
        CreatedAtSortOrder? createdSortOrder = null,
        string previousAssistantId = null,
        string subsequentAssistantId = null,
        CancellationToken cancellationToken = default)
    {
        Result<Internal.ListAssistantFilesResponse> internalFunc() => Shim.GetAssistantFiles(
            assistantId,
            maxResults,
            ToInternalListOrder(createdSortOrder),
            previousAssistantId,
            subsequentAssistantId,
            cancellationToken);
        return GetListQueryPage<AssistantFileAssociation, Internal.ListAssistantFilesResponse>(internalFunc);
    }

    public virtual Task<Result<ListQueryPage<AssistantFileAssociation>>> GetAssistantFileAssociationsAsync(
        string assistantId,
        int? maxResults = null,
        CreatedAtSortOrder? createdSortOrder = null,
        string previousAssistantId = null,
        string subsequentAssistantId = null,
        CancellationToken cancellationToken = default)
    {
        Func<Task<Result<Internal.ListAssistantFilesResponse>>> internalFunc
            = () => Shim.GetAssistantFilesAsync(
                assistantId,
                maxResults,
                ToInternalListOrder(createdSortOrder),
                previousAssistantId,
                subsequentAssistantId,
                cancellationToken);
        return GetListQueryPageAsync<AssistantFileAssociation, Internal.ListAssistantFilesResponse>(internalFunc);
    }

    public virtual Result<bool> RemoveAssistantFileAssociation(
        string assistantId,
        string fileId,
        CancellationToken cancellationToken = default)
    {
        Result<Internal.DeleteAssistantFileResponse> internalResult
            = Shim.DeleteAssistantFile(assistantId, fileId, cancellationToken);
        return Result.FromValue(internalResult.Value.Deleted, internalResult.GetRawResponse());
    }

    public virtual async Task<Result<bool>> RemoveAssistantFileAssociationAsync(
        string assistantId,
        string fileId,
        CancellationToken cancellationToken = default)
    {
        Result<Internal.DeleteAssistantFileResponse> internalResult
            = await Shim.DeleteAssistantFileAsync(assistantId, fileId, cancellationToken).ConfigureAwait(false);
        return Result.FromValue(internalResult.Value.Deleted, internalResult.GetRawResponse());
    }

    public virtual Result<AssistantThread> CreateThread(
        ThreadCreationOptions options = null,
        CancellationToken cancellationToken = default)
    {
        options ??= new();
        Internal.CreateThreadRequest request = new Internal.CreateThreadRequest(
            ToInternalCreateMessageRequestList(options.Messages),
            options.Metadata,
            serializedAdditionalRawData: null);
        Result<Internal.ThreadObject> internalResult = ThreadShim.CreateThread(request, cancellationToken);
        return Result.FromValue(new AssistantThread(internalResult.Value), internalResult.GetRawResponse());
    }

    public virtual async Task<Result<AssistantThread>> CreateThreadAsync(
        ThreadCreationOptions options = null,
        CancellationToken cancellationToken = default)
    {
        options ??= new();
        Internal.CreateThreadRequest request = new Internal.CreateThreadRequest(
            ToInternalCreateMessageRequestList(options.Messages),
            options.Metadata,
            serializedAdditionalRawData: null);
        Result<Internal.ThreadObject> internalResult
            = await ThreadShim.CreateThreadAsync(request, cancellationToken).ConfigureAwait(false);
        return Result.FromValue(new AssistantThread(internalResult.Value), internalResult.GetRawResponse());
    }

    public virtual Result<AssistantThread> GetThread(string threadId, CancellationToken cancellationToken = default)
    {
        Result<Internal.ThreadObject> internalResult = ThreadShim.GetThread(threadId, cancellationToken);
        return Result.FromValue(new AssistantThread(internalResult.Value), internalResult.GetRawResponse());
    }

    public virtual async Task<Result<AssistantThread>> GetThreadAsync(
        string threadId,
        CancellationToken cancellationToken = default)
    {
        Result<Internal.ThreadObject> internalResult
            = await ThreadShim.GetThreadAsync(threadId, cancellationToken).ConfigureAwait(false);
        return Result.FromValue(new AssistantThread(internalResult.Value), internalResult.GetRawResponse());
    }

    public virtual Result<AssistantThread> ModifyThread(
        string threadId,
        ThreadModificationOptions options,
        CancellationToken cancellationToken = default)
    {
        Internal.ModifyThreadRequest request = new(
            options.Metadata,
            serializedAdditionalRawData: null);
        Result<Internal.ThreadObject> internalResult = ThreadShim.ModifyThread(threadId, request, cancellationToken);
        return Result.FromValue(new AssistantThread(internalResult.Value), internalResult.GetRawResponse());
    }

    public virtual async Task<Result<AssistantThread>> ModifyThreadAsync(
        string threadId,
        ThreadModificationOptions options,
        CancellationToken cancellationToken = default)
    {
        Internal.ModifyThreadRequest request = new(
            options.Metadata,
            serializedAdditionalRawData: null);
        Result<Internal.ThreadObject> internalResult
            = await ThreadShim.ModifyThreadAsync(threadId, request, cancellationToken);
        return Result.FromValue(new AssistantThread(internalResult.Value), internalResult.GetRawResponse());
    }

    public virtual Result<bool> DeleteThread(string threadId, CancellationToken cancellationToken = default)
    {
        Result<Internal.DeleteThreadResponse> internalResult = ThreadShim.DeleteThread(threadId, cancellationToken);
        return Result.FromValue(internalResult.Value.Deleted, internalResult.GetRawResponse());
    }

    public virtual async Task<Result<bool>> DeleteThreadAsync(string threadId, CancellationToken cancellationToken = default)
    {
        Result<Internal.DeleteThreadResponse> internalResult
            = await ThreadShim.DeleteThreadAsync(threadId, cancellationToken).ConfigureAwait(false);
        return Result.FromValue(internalResult.Value.Deleted, internalResult.GetRawResponse());
    }

    public virtual Result<ThreadMessage> CreateMessage(
        string threadId,
        MessageRole role,
        string content,
        MessageCreationOptions options = null,
        CancellationToken cancellationToken = default)
    {
        Internal.CreateMessageRequest request = new(
            ToInternalRequestRole(role),
            content,
            options.FileIds,
            options.Metadata,
            serializedAdditionalRawData: null);
        Result<Internal.MessageObject> internalResult = MessageShim.CreateMessage(threadId, request, cancellationToken);
        return Result.FromValue(new ThreadMessage(internalResult.Value), internalResult.GetRawResponse());
    }

    public virtual async Task<Result<ThreadMessage>> CreateMessageAsync(
        string threadId,
        MessageRole role,
        string content,
        MessageCreationOptions options = null,
        CancellationToken cancellationToken = default)
    {
        Internal.CreateMessageRequest request = new(
            ToInternalRequestRole(role),
            content,
            options.FileIds,
            options.Metadata,
            serializedAdditionalRawData: null);
        Result<Internal.MessageObject> internalResult
            = await MessageShim.CreateMessageAsync(threadId, request, cancellationToken).ConfigureAwait(false);
        return Result.FromValue(new ThreadMessage(internalResult.Value), internalResult.GetRawResponse());
    }

    public virtual Result<ThreadMessage> GetMessage(
        string threadId,
        string messageId,
        CancellationToken cancellationToken = default)
    {
        Result<Internal.MessageObject> internalResult = MessageShim.GetMessage(threadId, messageId, cancellationToken);
        return Result.FromValue(new ThreadMessage(internalResult.Value), internalResult.GetRawResponse());
    }

    public virtual async Task<Result<ThreadMessage>> GetMessageAsync(
        string threadId,
        string messageId,
        CancellationToken cancellationToken = default)
    {
        Result<Internal.MessageObject> internalResult
            = await MessageShim.GetMessageAsync(threadId, messageId, cancellationToken).ConfigureAwait(false);
        return Result.FromValue(new ThreadMessage(internalResult.Value), internalResult.GetRawResponse());
    }

    public virtual Result<ListQueryPage<ThreadMessage>> GetMessages(
        string threadId,
        int? maxResults = null,
        CreatedAtSortOrder? createdSortOrder = null,
        string previousAssistantId = null,
        string subsequentAssistantId = null,
        CancellationToken cancellationToken = default)
    {
        Result<Internal.ListMessagesResponse> internalFunc() => MessageShim.GetMessages(
            threadId,
            maxResults,
            ToInternalListOrder(createdSortOrder),
            previousAssistantId,
            subsequentAssistantId,
            cancellationToken);
        return GetListQueryPage<ThreadMessage, Internal.ListMessagesResponse>(internalFunc);
    }

    public virtual Task<Result<ListQueryPage<ThreadMessage>>> GetMessagesAsync(
        string threadId,
        int? maxResults = null,
        CreatedAtSortOrder? createdSortOrder = null,
        string previousAssistantId = null,
        string subsequentAssistantId = null,
        CancellationToken cancellationToken = default)
    {
        Func<Task<Result<Internal.ListMessagesResponse>>> internalFunc = () => MessageShim.GetMessagesAsync(
                threadId,
                maxResults,
                ToInternalListOrder(createdSortOrder),
                previousAssistantId,
                subsequentAssistantId,
                cancellationToken);
        return GetListQueryPageAsync<ThreadMessage, Internal.ListMessagesResponse>(internalFunc);
    }

    public virtual Result<ThreadRun> CreateRun(
        string threadId,
        string assistantId,
        RunCreationOptions options = null,
        CancellationToken cancellationToken = default)
    {
        Internal.CreateRunRequest request = CreateInternalCreateRunRequest(assistantId, options);
        Result<Internal.RunObject> internalResult = RunShim.CreateRun(threadId, request, cancellationToken);
        return Result.FromValue(new ThreadRun(internalResult.Value), internalResult.GetRawResponse());
    }

    public virtual async Task<Result<ThreadRun>> CreateRunAsync(
        string threadId,
        string assistantId,
        RunCreationOptions options = null,
        CancellationToken cancellationToken = default)
    {
        Internal.CreateRunRequest request = CreateInternalCreateRunRequest(assistantId, options);
        Result<Internal.RunObject> internalResult
            = await RunShim.CreateRunAsync(threadId, request, cancellationToken).ConfigureAwait(false);
        return Result.FromValue(new ThreadRun(internalResult.Value), internalResult.GetRawResponse());
    }

    public virtual Result<ThreadRun> GetRun(string threadId, string runId, CancellationToken cancellationToken = default)
    {
        Result<Internal.RunObject> internalResult = RunShim.GetRun(threadId, runId, cancellationToken);
        return Result.FromValue(new ThreadRun(internalResult.Value), internalResult.GetRawResponse());
    }

    public virtual async Task<Result<ThreadRun>> GetRunAsync(string threadId, string runId, CancellationToken cancellationToken = default)
    {
        Result<Internal.RunObject> internalResult
            = await RunShim.GetRunAsync(threadId, runId, cancellationToken).ConfigureAwait(false);
        return Result.FromValue(new ThreadRun(internalResult.Value), internalResult.GetRawResponse());
    }

    public virtual Result<ListQueryPage<ThreadRun>> GetRuns(
        string threadId,
        int? maxResults = null,
        CreatedAtSortOrder? createdSortOrder = null,
        string previousAssistantId = null,
        string subsequentAssistantId = null,
        CancellationToken cancellationToken = default)
    {
        Result<Internal.ListRunsResponse> internalFunc() => RunShim.GetRuns(
            threadId,
            maxResults,
            ToInternalListOrder(createdSortOrder),
            previousAssistantId,
            subsequentAssistantId,
            cancellationToken);
        return GetListQueryPage<ThreadRun, Internal.ListRunsResponse>(internalFunc);
    }

    public virtual Task<Result<ListQueryPage<ThreadRun>>> GetRunsAsync(
        string threadId,
        int? maxResults = null,
        CreatedAtSortOrder? createdSortOrder = null,
        string previousAssistantId = null,
        string subsequentAssistantId = null,
        CancellationToken cancellationToken = default)
    {
        Func<Task<Result<Internal.ListRunsResponse>>> internalFunc = () => RunShim.GetRunsAsync(
            threadId,
            maxResults,
            ToInternalListOrder(createdSortOrder),
            previousAssistantId,
            subsequentAssistantId,
            cancellationToken);
        return GetListQueryPageAsync<ThreadRun, Internal.ListRunsResponse>(internalFunc);
    }

    public virtual Result<ThreadRun> ModifyRun(string threadId, string runId, RunModificationOptions options, CancellationToken cancellationToken = default)
    {
        Internal.ModifyRunRequest request = new(options.Metadata, serializedAdditionalRawData: null);
        Result<Internal.RunObject> internalResult = RunShim.ModifyRun(threadId, runId, request, cancellationToken);
        return Result.FromValue(new ThreadRun(internalResult.Value), internalResult.GetRawResponse());
    }

    public virtual async Task<Result<ThreadRun>> ModifyRunAsync(string threadId, string runId, RunModificationOptions options, CancellationToken cancellationToken = default)
    {
        Internal.ModifyRunRequest request = new(options.Metadata, serializedAdditionalRawData: null);
        Result<Internal.RunObject> internalResult
            = await RunShim.ModifyRunAsync(threadId, runId, request, cancellationToken).ConfigureAwait(false);
        return Result.FromValue(new ThreadRun(internalResult.Value), internalResult.GetRawResponse());
    }

    public virtual Result<bool> CancelRun(string threadId, string runId, CancellationToken cancellationToken = default)
    {
        Result<Internal.RunObject> internalResult = RunShim.CancelRun(threadId, runId, cancellationToken);
        return Result.FromValue(true, internalResult.GetRawResponse());
    }

    public virtual async Task<Result<bool>> CancelRunAsync(string threadId, string runId, CancellationToken cancellationToken = default)
    {
        Result<Internal.RunObject> internalResult
            = await RunShim.CancelRunAsync(threadId, runId, cancellationToken);
        return Result.FromValue(true, internalResult.GetRawResponse());
    }

    public virtual Result<bool> SubmitToolOutputs(string threadId, string runId, IEnumerable<ToolOutput> toolOutputs, CancellationToken cancellationToken = default)
    {
        RequestBody content = CreateManualSubmitToolOutputsBody(toolOutputs);
        RequestOptions context = new() { CancellationToken = cancellationToken };
        Result internalResult = RunShim.SubmitToolOuputsToRun(threadId, runId, content, context);
        return Result.FromValue(true, internalResult.GetRawResponse());
    }

    public virtual async Task<Result<bool>> SubmitToolOutputsAsync(string threadId, string runId, IEnumerable<ToolOutput> toolOutputs, CancellationToken cancellationToken = default)
    {
        RequestBody content = CreateManualSubmitToolOutputsBody(toolOutputs);
        RequestOptions context = new() { CancellationToken = cancellationToken };
        Result internalResult
            = await RunShim.SubmitToolOuputsToRunAsync(threadId, runId, content, context).ConfigureAwait(false);
        return Result.FromValue(true, internalResult.GetRawResponse());
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result SubmitToolOutputs(string threadId, string runId, RequestBody content, RequestOptions context = null)
    {
        return RunShim.SubmitToolOuputsToRun(threadId, runId, content, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> SubmitToolOutputsAsync(string threadId, string runId, RequestBody content, RequestOptions context = null)
    {
        return RunShim.SubmitToolOuputsToRunAsync(threadId, runId, content, context);
    }

    internal static Internal.CreateAssistantRequest CreateInternalCreateAssistantRequest(
        string modelName,
        AssistantCreationOptions options)
    {
        options ??= new();
        return new Internal.CreateAssistantRequest(
            modelName,
            options.Name,
            options.Description,
            options.Instructions,
            ToInternalBinaryDataList(options.Tools),
            options.FileIds,
            options.Metadata,
            serializedAdditionalRawData: null);
    }

    internal static Internal.ModifyAssistantRequest CreateInternalModifyAssistantRequest(AssistantModificationOptions options)
    {
        return new Internal.ModifyAssistantRequest(
            options.Model,
            options.Name,
            options.Description,
            options.Instructions,
            ToInternalBinaryDataList(options.Tools),
            options.FileIds,
            options.Metadata,
            serializedAdditionalRawData: null);
    }

    internal static Internal.CreateRunRequest CreateInternalCreateRunRequest(
        string assistantId,
        RunCreationOptions options = null)

    {
        options ??= new();
        return new(
            assistantId,
            options.OverrideModel,
            options.OverrideInstructions,
            options.AdditionalInstructions,
            ToInternalBinaryDataList(options.OverrideTools),
            options.Metadata,
            serializedAdditionalRawData: null);
    }

    internal static RequestBody CreateManualSubmitToolOutputsBody(IEnumerable<ToolOutput> outputs)
    {
        Utf8JsonRequestBody body = new();
        body.JsonWriter.WriteStartObject();
        body.JsonWriter.WritePropertyName("tool_outputs"u8);
        body.JsonWriter.WriteStartArray();
        foreach (ToolOutput output in outputs ?? [])
        {
            body.JsonWriter.WriteObjectValue(output);
        }
        body.JsonWriter.WriteEndArray();
        body.JsonWriter.WriteEndObject();
        return body;
    }

    internal static OptionalList<BinaryData> ToInternalBinaryDataList<T>(IEnumerable<T> values)
        where T : IPersistableModel<T>
    {
        OptionalList<BinaryData> internalList = [];
        foreach (T value in values)
        {
            internalList.Add(ModelReaderWriter.Write(value));
        }
        return internalList;
    }

    internal static Internal.ListOrder? ToInternalListOrder(CreatedAtSortOrder? order)
    {
        if (order == null)
        {
            return null;
        }
        return order switch
        {
            CreatedAtSortOrder.OldestFirst => Internal.ListOrder.Asc,
            CreatedAtSortOrder.NewestFirst => Internal.ListOrder.Desc,
            _ => throw new ArgumentException(nameof(order)),
        };
    }

    internal static Internal.CreateMessageRequestRole ToInternalRequestRole(MessageRole role)
    => role switch
    {
        MessageRole.User => Internal.CreateMessageRequestRole.User,
        _ => throw new ArgumentException(nameof(role)),
    };

    internal static OptionalList<Internal.CreateMessageRequest> ToInternalCreateMessageRequestList(
        IEnumerable<ThreadInitializationMessage> messages)
    {
        OptionalList<Internal.CreateMessageRequest> internalList = [];
        foreach (ThreadInitializationMessage message in messages)
        {
            internalList.Add(new Internal.CreateMessageRequest(
                ToInternalRequestRole(message.Role),
                message.Content,
                message.FileIds,
                message.Metadata,
                serializedAdditionalRawData: null));
        }
        return internalList;
    }

    internal virtual Result<ListQueryPage<T>> GetListQueryPage<T, U>(Func<Result<U>> internalFunc)
        where T : class
        where U : class
    {
        Result<U> internalResult = internalFunc.Invoke();
        ListQueryPage<T> convertedValue = ListQueryPage.Create(internalResult.Value) as ListQueryPage<T>;
        return Result.FromValue(convertedValue, internalResult.GetRawResponse());
    }

    internal virtual async Task<Result<ListQueryPage<T>>> GetListQueryPageAsync<T, U>(Func<Task<Result<U>>> internalAsyncFunc)
        where T : class
        where U : class
    {
        Result<U> internalResult = await internalAsyncFunc.Invoke();
        ListQueryPage<T> convertedValue = ListQueryPage.Create(internalResult.Value) as ListQueryPage<T>;
        return Result.FromValue(convertedValue, internalResult.GetRawResponse());
    }
}
