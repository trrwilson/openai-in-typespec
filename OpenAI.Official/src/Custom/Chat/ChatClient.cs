using System;
using System.ClientModel;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI.Official.Chat;

/// <summary> The service client for the OpenAI Chat Completions endpoint. </summary>
public partial class ChatClient
{
    private OpenAIClientConnector _clientConnector;
    private Internal.Chat Shim => _clientConnector.InternalClient.GetChatClient();

    /// <summary>
    /// Initializes a new instance of <see cref="ChatClient"/>, used for Chat Completion requests. 
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
    /// <param name="model">The model name for chat completions that the client should use.</param>
    /// <param name="credential">The API key used to authenticate with the service endpoint.</param>
    /// <param name="options">Additional options to customize the client.</param>
    public ChatClient(Uri endpoint, string model, ApiKeyCredential credential, ChatClientOptions options = null)
    {
        _clientConnector = new(model, endpoint, credential, options);
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ChatClient"/>, used for Chat Completion requests. 
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
    /// <param name="model">The model name for chat completions that the client should use.</param>
    /// <param name="options">Additional options to customize the client.</param>
    public ChatClient(Uri endpoint, string model, ChatClientOptions options = null)
        : this(endpoint, model, credential: null, options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="ChatClient"/>, used for Chat Completion requests. 
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
    /// <param name="model">The model name for chat completions that the client should use.</param>
    /// <param name="credential">The API key used to authenticate with the service endpoint.</param>
    /// <param name="options">Additional options to customize the client.</param>
    public ChatClient(string model, ApiKeyCredential credential, ChatClientOptions options = null)
        : this(endpoint: null, model, credential, options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="ChatClient"/>, used for Chat Completion requests. 
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
    /// <param name="model">The model name for chat completions that the client should use.</param>
    /// <param name="options">Additional options to customize the client.</param>
    public ChatClient(string model, ChatClientOptions options = null)
        : this(endpoint: null, model, credential: null, options)
    { }

    /// <summary>
    /// Generates a single chat completion result for a single, simple user message.
    /// </summary>
    /// <param name="message"> The user message to provide as a prompt for chat completion. </param>
    /// <param name="options"> Additional options for the chat completion request. </param>
    /// <param name="cancellationToken"> The cancellation token for the operation. </param>
    /// <returns> A result for a single chat completion. </returns>
     public virtual ClientResult<ChatCompletion> CompleteChat(string message, ChatCompletionOptions options = null)
         => CompleteChat(new List<ChatRequestMessage>() { new ChatRequestUserMessage(message) }, options);

    /// <summary>
    /// Generates a single chat completion result for a single, simple user message.
    /// </summary>
    /// <param name="message"> The user message to provide as a prompt for chat completion. </param>
    /// <param name="options"> Additional options for the chat completion request. </param>
    /// <param name="cancellationToken"> The cancellation token for the operation. </param>
    /// <returns> A result for a single chat completion. </returns>
     public virtual Task<ClientResult<ChatCompletion>> CompleteChatAsync(string message, ChatCompletionOptions options = null)
        => CompleteChatAsync(
             new List<ChatRequestMessage>() { new ChatRequestUserMessage(message) }, options);

    /// <summary>
    /// Generates a single chat completion result for a provided set of input chat messages.
    /// </summary>
    /// <param name="messages"> The messages to provide as input and history for chat completion. </param>
    /// <param name="options"> Additional options for the chat completion request. </param>
    /// <param name="cancellationToken"> The cancellation token for the operation. </param>
    /// <returns> A result for a single chat completion. </returns>
    public virtual ClientResult<ChatCompletion> CompleteChat(
        IEnumerable<ChatRequestMessage> messages,
        ChatCompletionOptions options = null)
    {
        Internal.Models.CreateChatCompletionRequest request = CreateInternalRequest(messages, options); 
        ClientResult<Internal.Models.CreateChatCompletionResponse> response = Shim.CreateChatCompletion(request);
        ChatCompletion chatCompletion = new(response.Value, internalChoiceIndex: 0);
        return ClientResult.FromValue(chatCompletion, response.GetRawResponse());
    }

    /// <summary>
    /// Generates a single chat completion result for a provided set of input chat messages.
    /// </summary>
    /// <param name="messages"> The messages to provide as input and history for chat completion. </param>
    /// <param name="options"> Additional options for the chat completion request. </param>
    /// <param name="cancellationToken"> The cancellation token for the operation. </param>
    /// <returns> A result for a single chat completion. </returns>
    public virtual async Task<ClientResult<ChatCompletion>> CompleteChatAsync(
        IEnumerable<ChatRequestMessage> messages,
        ChatCompletionOptions options = null)
    {
        Internal.Models.CreateChatCompletionRequest request = CreateInternalRequest(messages, options);
        ClientResult<Internal.Models.CreateChatCompletionResponse> response = await Shim.CreateChatCompletionAsync(request).ConfigureAwait(false);
        ChatCompletion chatCompletion = new(response.Value, internalChoiceIndex: 0);
        return ClientResult.FromValue(chatCompletion, response.GetRawResponse());
    }

    /// <summary>
    /// Generates a collection of chat completion results for a provided set of input chat messages.
    /// </summary>
    /// <param name="messages"> The messages to provide as input and history for chat completion. </param>
    /// <param name="choiceCount">
    ///     The number of independent, alternative response choices that should be generated.
    /// </param>
    /// <param name="options"> Additional options for the chat completion request. </param>
    /// <param name="cancellationToken"> The cancellation token for the operation. </param>
    /// <returns> A result for a single chat completion. </returns>
    public virtual ClientResult<ChatCompletionCollection> CompleteChat(
        IEnumerable<ChatRequestMessage> messages,
        int choiceCount,
        ChatCompletionOptions options = null)
    {
        Internal.Models.CreateChatCompletionRequest request = CreateInternalRequest(messages, options, choiceCount);
        ClientResult<Internal.Models.CreateChatCompletionResponse> response = Shim.CreateChatCompletion(request);
        List<ChatCompletion> chatCompletions = [];
        for (int i = 0; i < response.Value.Choices.Count; i++)
        {
            chatCompletions.Add(new(response.Value, response.Value.Choices[i].Index));
        }
        return ClientResult.FromValue(new ChatCompletionCollection(chatCompletions), response.GetRawResponse());
    }

    /// <summary>
    /// Generates a collection of chat completion results for a provided set of input chat messages.
    /// </summary>
    /// <param name="messages"> The messages to provide as input and history for chat completion. </param>
    /// <param name="choiceCount">
    ///     The number of independent, alternative response choices that should be generated.
    /// </param>
    /// <param name="options"> Additional options for the chat completion request. </param>
    /// <param name="cancellationToken"> The cancellation token for the operation. </param>
    /// <returns> A result for a single chat completion. </returns>
    public virtual async Task<ClientResult<ChatCompletionCollection>> CompleteChatAsync(
        IEnumerable<ChatRequestMessage> messages,
        int choiceCount,
        ChatCompletionOptions options = null)
    {
        Internal.Models.CreateChatCompletionRequest request = CreateInternalRequest(messages, options, choiceCount);
        ClientResult<Internal.Models.CreateChatCompletionResponse> response = await Shim.CreateChatCompletionAsync(request).ConfigureAwait(false);
        List<ChatCompletion> chatCompletions = [];
        for (int i = 0; i < response.Value.Choices.Count; i++)
        {
            chatCompletions.Add(new(response.Value, response.Value.Choices[i].Index));
        }
        return ClientResult.FromValue(new ChatCompletionCollection(chatCompletions), response.GetRawResponse());
    }

    /// <summary>
    /// Begins a streaming response for a chat completion request using a single, simple user message as input.
    /// </summary>
    /// <remarks>
    /// <see cref="StreamingResult{T}"/> can be enumerated over using the <c>await foreach</c> pattern using the
    /// <see cref="IAsyncEnumerable{T}"/> interface. 
    /// </remarks>
    /// <param name="message"> The user message to provide as a prompt for chat completion. </param>
    /// <param name="choiceCount">
    ///     The number of independent, alternative choices that the chat completion request should generate.
    /// </param>
    /// <param name="options"> Additional options for the chat completion request. </param>
    /// <param name="cancellationToken"> The cancellation token for the operation. </param>
    /// <returns> A streaming result with incremental chat completion updates. </returns>
   public virtual StreamingClientResult<StreamingChatUpdate> CompleteChatStreaming(
        string message,
        int? choiceCount = null,
        ChatCompletionOptions options = null)
        => CompleteChatStreaming(
            new List<ChatRequestMessage> { new ChatRequestUserMessage(message) },
            choiceCount,
            options);

    /// <summary>
    /// Begins a streaming response for a chat completion request using a single, simple user message as input.
    /// </summary>
    /// <remarks>
    /// <see cref="StreamingResult{T}"/> can be enumerated over using the <c>await foreach</c> pattern using the
    /// <see cref="IAsyncEnumerable{T}"/> interface. 
    /// </remarks>
    /// <param name="message"> The user message to provide as a prompt for chat completion. </param>
    /// <param name="choiceCount">
    ///     The number of independent, alternative choices that the chat completion request should generate.
    /// </param>
    /// <param name="options"> Additional options for the chat completion request. </param>
    /// <param name="cancellationToken"> The cancellation token for the operation. </param>
    /// <returns> A streaming result with incremental chat completion updates. </returns>
    public virtual Task<StreamingClientResult<StreamingChatUpdate>> CompleteChatStreamingAsync(
        string message,
        int? choiceCount = null,
        ChatCompletionOptions options = null)
    => CompleteChatStreamingAsync(
        new List<ChatRequestMessage> { new ChatRequestUserMessage(message) },
        choiceCount,
        options);

    /// <summary>
    /// Begins a streaming response for a chat completion request using the provided chat messages as input and
    /// history.
    /// </summary>
    /// <remarks>
    /// <see cref="StreamingResult{T}"/> can be enumerated over using the <c>await foreach</c> pattern using the
    /// <see cref="IAsyncEnumerable{T}"/> interface. 
    /// </remarks>
    /// <param name="messages"> The messages to provide as input for chat completion. </param>
    /// <param name="choiceCount">
    ///     The number of independent, alternative choices that the chat completion request should generate.
    /// </param>
    /// <param name="options"> Additional options for the chat completion request. </param>
    /// <param name="cancellationToken"> The cancellation token for the operation. </param>
    /// <returns> A streaming result with incremental chat completion updates. </returns>
    public virtual StreamingClientResult<StreamingChatUpdate> CompleteChatStreaming(
        IEnumerable<ChatRequestMessage> messages,
        int? choiceCount = null,
        ChatCompletionOptions options = null)
    {
        Internal.Models.CreateChatCompletionRequest request = CreateInternalRequest(messages, options, choiceCount, stream: true);
        BinaryContent content = BinaryContent.Create(request);
        RequestOptions context = new();
        context.AddPolicy(StreamingBufferPolicy, PipelinePosition.BeforeTransport);
        ClientResult genericResult = Shim.CreateChatCompletion(content, context);
        return StreamingClientResult<StreamingChatUpdate>.CreateFromResponse(
            genericResult,
            (responseForEnumeration) => SseAsyncEnumerator<StreamingChatUpdate>.EnumerateFromSseStream(
                responseForEnumeration.GetRawResponse().ContentStream,
                e => StreamingChatUpdate.DeserializeStreamingChatUpdates(e)));            
    }

    /// <summary>
    /// Begins a streaming response for a chat completion request using the provided chat messages as input and
    /// history.
    /// </summary>
    /// <remarks>
    /// <see cref="StreamingResult{T}"/> can be enumerated over using the <c>await foreach</c> pattern using the
    /// <see cref="IAsyncEnumerable{T}"/> interface. 
    /// </remarks>
    /// <param name="messages"> The messages to provide as input for chat completion. </param>
    /// <param name="choiceCount">
    ///     The number of independent, alternative choices that the chat completion request should generate.
    /// </param>
    /// <param name="options"> Additional options for the chat completion request. </param>
    /// <param name="cancellationToken"> The cancellation token for the operation. </param>
    /// <returns> A streaming result with incremental chat completion updates. </returns>
    public virtual async Task<StreamingClientResult<StreamingChatUpdate>> CompleteChatStreamingAsync(
        IEnumerable<ChatRequestMessage> messages,
        int? choiceCount = null,
        ChatCompletionOptions options = null)
    {
        Internal.Models.CreateChatCompletionRequest request = CreateInternalRequest(messages, options, choiceCount, stream: true);
        BinaryContent content = BinaryContent.Create(request);
        RequestOptions context = new();
        context.AddPolicy(StreamingBufferPolicy, PipelinePosition.BeforeTransport);
        ClientResult genericResult = await Shim.CreateChatCompletionAsync(content, context).ConfigureAwait(false);
        return StreamingClientResult<StreamingChatUpdate>.CreateFromResponse(
            genericResult,
            (responseForEnumeration) => SseAsyncEnumerator<StreamingChatUpdate>.EnumerateFromSseStream(
                responseForEnumeration.GetRawResponse().ContentStream,
                e => StreamingChatUpdate.DeserializeStreamingChatUpdates(e)));   
    }

    /// <inheritdoc cref="Internal.Models.Chat.CreateChatCompletion(BinaryContent, RequestOptions)"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ClientResult CompleteChat(BinaryContent content, RequestOptions context = null)
        => Shim.CreateChatCompletion(content, context);

    /// <inheritdoc cref="Internal.Models.Chat.CreateChatCompletionAsync(BinaryContent, RequestOptions)"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<ClientResult> CompleteChatAsync(BinaryContent content, RequestOptions context = null)
        => Shim.CreateChatCompletionAsync(content, context);

    private Internal.Models.CreateChatCompletionRequest CreateInternalRequest(
        IEnumerable<ChatRequestMessage> messages,
        ChatCompletionOptions options = null,
        int? choiceCount = null,
        bool? stream = null)
    {
        options ??= new();
        List<BinaryData> messageDataItems = [];
        foreach (ChatRequestMessage message in messages)
        {
            messageDataItems.Add(ModelReaderWriter.Write(message));
        }
        Dictionary<string, BinaryData> additionalData = [];
        return new Internal.Models.CreateChatCompletionRequest(
            messageDataItems,
            _clientConnector.Model,
            options?.FrequencyPenalty,
            options?.GetInternalLogitBias(),
            options?.IncludeLogProbabilities,
            options?.LogProbabilityCount,
            options?.MaxTokens,
            choiceCount,
            options?.PresencePenalty,
            options?.GetInternalFormat(),
            options?.Seed,
            options?.GetInternalStopSequences(),
            stream,
            options?.Temperature,
            options?.NucleusSamplingFactor,
            options?.GetInternalTools(),
            options?.ToolConstraint?.GetBinaryData(),
            options?.User,
            options?.FunctionConstraint?.ToBinaryData(),
            options?.GetInternalFunctions(),
            additionalData
        );
    }

    private static PipelinePolicy _streamingBufferPolicy;
    private static PipelinePolicy StreamingBufferPolicy = _streamingBufferPolicy ?? new GenericActionPipelinePolicy((message) =>
    {
        if (message.Request != null)
        {
            // message.BufferResponse = false;
        }
    });
}
