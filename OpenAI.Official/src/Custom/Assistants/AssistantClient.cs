using System;
using System.ClientModel;
using System.ClientModel.Primitives;
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

}
