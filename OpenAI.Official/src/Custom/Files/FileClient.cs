using System;
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
    public FileClient(Uri endpoint, KeyCredential credential, FileClientOptions options = null)
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
    public FileClient(Uri endpoint, FileClientOptions options = null)
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
    public FileClient(KeyCredential credential, FileClientOptions options = null)
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
    public FileClient(FileClientOptions options = null)
        : this(endpoint: null, credential: null, options)
    { }

    public virtual Result<OpenAIFileInfo> UploadFile(BinaryData file, OpenAIFilePurpose purpose, CancellationToken cancellationToken = default)
    {
        Internal.CreateFileRequest request = new(file, ToInternalFilePurpose(purpose).ToString());
        Result<Internal.OpenAIFile> result = Shim.CreateFile(request, cancellationToken);
        return Result.FromValue(new OpenAIFileInfo(result.Value), result.GetRawResponse());
    }

    public virtual async Task<Result<OpenAIFileInfo>> UploadFileAsync(BinaryData file, OpenAIFilePurpose purpose, CancellationToken cancellationToken = default)
    {
        Internal.CreateFileRequest request = new(file, ToInternalFilePurpose(purpose).ToString());
        Result<Internal.OpenAIFile> result = await Shim.CreateFileAsync(request, cancellationToken).ConfigureAwait(false);
        return Result.FromValue(new OpenAIFileInfo(result.Value), result.GetRawResponse());
    }

    public virtual Result<OpenAIFileInfoCollection> GetFileInfoItems(OpenAIFilePurpose? purpose = null, CancellationToken cancellationToken = default)
    {
        Internal.OpenAIFilePurpose? internalPurpose = ToInternalFilePurpose(purpose);
        string internalPurposeText = null;
        if (internalPurpose != null)
        {
            internalPurposeText = internalPurpose.ToString();
        }
        Result<Internal.ListFilesResponse> result = Shim.GetFiles(internalPurposeText, cancellationToken);
        List<OpenAIFileInfo> infoItems = [];
        foreach (Internal.OpenAIFile internalFile in result.Value.Data)
        {
            infoItems.Add(new(internalFile));
        }
        return Result.FromValue(new OpenAIFileInfoCollection(infoItems), result.GetRawResponse());
    }

    public virtual async Task<Result<OpenAIFileInfoCollection>> GetFileInfoItemsAsync(OpenAIFilePurpose? purpose = null, CancellationToken cancellationToken = default)
    {
        Internal.OpenAIFilePurpose? internalPurpose = ToInternalFilePurpose(purpose);
        string internalPurposeText = null;
        if (internalPurpose != null)
        {
            internalPurposeText = internalPurpose.ToString();
        }
        Result<Internal.ListFilesResponse> result = await Shim.GetFilesAsync(internalPurposeText, cancellationToken).ConfigureAwait(false);
        List<OpenAIFileInfo> infoItems = [];
        foreach (Internal.OpenAIFile internalFile in result.Value.Data)
        {
            infoItems.Add(new(internalFile));
        }
        return Result.FromValue(new OpenAIFileInfoCollection(infoItems), result.GetRawResponse());
    }

    internal static Internal.OpenAIFilePurpose? ToInternalFilePurpose(OpenAIFilePurpose? purpose)
    {
        if (purpose == null)
        {
            return null;
        }
        return purpose switch
        {
            OpenAIFilePurpose.FineTuning => Internal.OpenAIFilePurpose.FineTune,
            OpenAIFilePurpose.FineTuningResults => Internal.OpenAIFilePurpose.FineTuneResults,
            OpenAIFilePurpose.Assistants => Internal.OpenAIFilePurpose.Assistants,
            OpenAIFilePurpose.AssistantOutputs => Internal.OpenAIFilePurpose.AssistantsOutput,
            _ => throw new ArgumentException($"Unsupported file purpose: {purpose}"),
        };
    }
    
}
