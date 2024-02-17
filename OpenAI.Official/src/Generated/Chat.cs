// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.ClientModel.Primitives.Pipeline;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI.Official.Internal
{
    // Data plane generated sub-client.
    /// <summary> The Chat sub-client. </summary>
    internal partial class Chat
    {
        private const string AuthorizationHeader = "Authorization";
        private readonly KeyCredential _keyCredential;
        private const string AuthorizationApiKeyPrefix = "Bearer";
        private readonly MessagePipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal TelemetrySource ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual MessagePipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of Chat for mocking. </summary>
        protected Chat()
        {
        }

        /// <summary> Initializes a new instance of Chat. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="endpoint"> OpenAI Endpoint. </param>
        internal Chat(TelemetrySource clientDiagnostics, MessagePipeline pipeline, KeyCredential keyCredential, Uri endpoint)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _keyCredential = keyCredential;
            _endpoint = endpoint;
        }

        /// <summary> Creates a model response for the given chat conversation. </summary>
        /// <param name="createChatCompletionRequest"> The <see cref="CreateChatCompletionRequest"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="createChatCompletionRequest"/> is null. </exception>
        public virtual async Task<Result<CreateChatCompletionResponse>> CreateChatCompletionAsync(CreateChatCompletionRequest createChatCompletionRequest, CancellationToken cancellationToken = default)
        {
            ClientUtilities.AssertNotNull(createChatCompletionRequest, nameof(createChatCompletionRequest));

            RequestOptions context = FromCancellationToken(cancellationToken);
            using RequestBody content = createChatCompletionRequest.ToRequestBody();
            Result result = await CreateChatCompletionAsync(content, context).ConfigureAwait(false);
            return Result.FromValue(CreateChatCompletionResponse.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary> Creates a model response for the given chat conversation. </summary>
        /// <param name="createChatCompletionRequest"> The <see cref="CreateChatCompletionRequest"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="createChatCompletionRequest"/> is null. </exception>
        public virtual Result<CreateChatCompletionResponse> CreateChatCompletion(CreateChatCompletionRequest createChatCompletionRequest, CancellationToken cancellationToken = default)
        {
            ClientUtilities.AssertNotNull(createChatCompletionRequest, nameof(createChatCompletionRequest));

            RequestOptions context = FromCancellationToken(cancellationToken);
            using RequestBody content = createChatCompletionRequest.ToRequestBody();
            Result result = CreateChatCompletion(content, context);
            return Result.FromValue(CreateChatCompletionResponse.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary>
        /// [Protocol Method] Creates a model response for the given chat conversation.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CreateChatCompletionAsync(CreateChatCompletionRequest,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="MessageFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Result> CreateChatCompletionAsync(RequestBody content, RequestOptions context = null)
        {
            ClientUtilities.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateSpan("Chat.CreateChatCompletion");
            scope.Start();
            try
            {
                using PipelineMessage message = CreateCreateChatCompletionRequest(content, context);
                return Result.FromResponse(await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Creates a model response for the given chat conversation.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CreateChatCompletion(CreateChatCompletionRequest,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="MessageFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Result CreateChatCompletion(RequestBody content, RequestOptions context = null)
        {
            ClientUtilities.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateSpan("Chat.CreateChatCompletion");
            scope.Start();
            try
            {
                using PipelineMessage message = CreateCreateChatCompletionRequest(content, context);
                return Result.FromResponse(_pipeline.ProcessMessage(message, context));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal PipelineMessage CreateCreateChatCompletionRequest(RequestBody content, RequestOptions context)
        {
            var message = _pipeline.CreateMessage(context, ResponseErrorClassifier200);
            var request = message.Request;
            request.SetMethod("POST");
            var uri = new RequestUri();
            uri.Reset(_endpoint);
            uri.AppendPath("/chat/completions", false);
            request.Uri = uri.ToUri();
            request.SetHeaderValue("Accept", "application/json");
            request.SetHeaderValue("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        private static RequestOptions DefaultRequestContext = new RequestOptions();
        internal static RequestOptions FromCancellationToken(CancellationToken cancellationToken = default)
        {
            if (!cancellationToken.CanBeCanceled)
            {
                return DefaultRequestContext;
            }

            return new RequestOptions() { CancellationToken = cancellationToken };
        }

        private static ResponseErrorClassifier _responseErrorClassifier200;
        private static ResponseErrorClassifier ResponseErrorClassifier200 => _responseErrorClassifier200 ??= new StatusResponseClassifier(stackalloc ushort[] { 200 });
    }
}
