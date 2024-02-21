using System;
using System.ClientModel;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI.Official.Files;

/// <summary>
///     The service client for OpenAI file operations.
/// </summary>
public partial class FileClient
{
    private OpenAIClientConnector _clientConnector;
    private Internal.Files Shim => _clientConnector.InternalClient.GetFilesClient();

    /// <summary>
    /// Initializes a new instance of <see cref="FileClient"/>, used for file operation requests. 
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
    public FileClient(Uri endpoint, ApiKeyCredential credential, OpenAIClientOptions options = null)
    {
        _clientConnector = new("none", endpoint, credential, options);
    }

    /// <summary>
    /// Initializes a new instance of <see cref="FileClient"/>, used for file operation requests. 
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
    public FileClient(Uri endpoint, OpenAIClientOptions options = null)
        : this(endpoint, credential: null, options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="FileClient"/>, used for file operation requests. 
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
    public FileClient(ApiKeyCredential credential, OpenAIClientOptions options = null)
        : this(endpoint: null, credential, options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="FileClient"/>, used for file operation requests. 
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
    public FileClient(OpenAIClientOptions options = null)
        : this(endpoint: null, credential: null, options)
    { }

     public virtual ClientResult<OpenAIFileInfo> UploadFile(BinaryData file, OpenAIFilePurpose purpose)
    {
        Internal.Models.CreateFileRequest request = new(file, ToInternalFilePurpose(purpose).ToString());
        ClientResult<Internal.Models.OpenAIFile> result = Shim.CreateFile(request);
        return ClientResult.FromValue(new OpenAIFileInfo(result.Value), result.GetRawResponse());
    }

     public virtual async Task<ClientResult<OpenAIFileInfo>> UploadFileAsync(BinaryData file, OpenAIFilePurpose purpose)
    {
        Internal.Models.CreateFileRequest request = new(file, ToInternalFilePurpose(purpose).ToString());
        ClientResult<Internal.Models.OpenAIFile> result = await Shim.CreateFileAsync(request).ConfigureAwait(false);
        return ClientResult.FromValue(new OpenAIFileInfo(result.Value), result.GetRawResponse());
    }

     public virtual ClientResult<OpenAIFileInfoCollection> GetFileInfoItems(OpenAIFilePurpose? purpose = null)
    {
        Internal.Models.OpenAIFilePurpose? internalPurpose = ToInternalFilePurpose(purpose);
        string internalPurposeText = null;
        if (internalPurpose != null)
        {
            internalPurposeText = internalPurpose.ToString();
        }
        ClientResult<Internal.Models.ListFilesResponse> result = Shim.GetFiles(internalPurposeText);
        List<OpenAIFileInfo> infoItems = [];
        foreach (Internal.Models.OpenAIFile internalFile in result.Value.Data)
        {
            infoItems.Add(new(internalFile));
        }
        return ClientResult.FromValue(new OpenAIFileInfoCollection(infoItems), result.GetRawResponse());
    }

     public virtual async Task<ClientResult<OpenAIFileInfoCollection>> GetFileInfoItemsAsync(OpenAIFilePurpose? purpose = null)
    {
        Internal.Models.OpenAIFilePurpose? internalPurpose = ToInternalFilePurpose(purpose);
        string internalPurposeText = null;
        if (internalPurpose != null)
        {
            internalPurposeText = internalPurpose.ToString();
        }
        ClientResult<Internal.Models.ListFilesResponse> result = await Shim.GetFilesAsync(internalPurposeText).ConfigureAwait(false);
        List<OpenAIFileInfo> infoItems = [];
        foreach (Internal.Models.OpenAIFile internalFile in result.Value.Data)
        {
            infoItems.Add(new(internalFile));
        }
        return ClientResult.FromValue(new OpenAIFileInfoCollection(infoItems), result.GetRawResponse());
    }

    internal static Internal.Models.OpenAIFilePurpose? ToInternalFilePurpose(OpenAIFilePurpose? purpose)
    {
        if (purpose == null)
        {
            return null;
        }
        return purpose switch
        {
            OpenAIFilePurpose.FineTuning => Internal.Models.OpenAIFilePurpose.FineTune,
            OpenAIFilePurpose.FineTuningResults => Internal.Models.OpenAIFilePurpose.FineTuneResults,
            OpenAIFilePurpose.Assistants => Internal.Models.OpenAIFilePurpose.Assistants,
            OpenAIFilePurpose.AssistantOutputs => Internal.Models.OpenAIFilePurpose.AssistantsOutput,
            _ => throw new ArgumentException($"Unsupported file purpose: {purpose}"),
        };
    }
    
}
