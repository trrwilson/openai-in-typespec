using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI.Official.Audio;

/// <summary> The service client for OpenAI audio operations. </summary>
public partial class AudioClient
{
    private OpenAIClientConnector _clientConnector;
    private Internal.Audio Shim => _clientConnector.InternalClient.GetAudioClient();

    /// <summary>
    /// Initializes a new instance of <see cref="AudioClient"/>, used for audio operation requests. 
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
    /// <param name="model">The model name for audio operations that the client should use.</param>
    /// <param name="credential">The API key used to authenticate with the service endpoint.</param>
    /// <param name="options">Additional options to customize the client.</param>
    public AudioClient(Uri endpoint, string model, KeyCredential credential, AudioClientOptions options = null)
    {
        _clientConnector = new(model, endpoint, credential, options);
    }

    /// <summary>
    /// Initializes a new instance of <see cref="AudioClient"/>, used for audio operation requests. 
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
    /// <param name="model">The model name for audio operations that the client should use.</param>
    /// <param name="options">Additional options to customize the client.</param>
    public AudioClient(Uri endpoint, string model, AudioClientOptions options = null)
        : this(endpoint, model, credential: null, options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="AudioClient"/>, used for audio operation requests. 
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
    /// <param name="model">The model name for audio operations that the client should use.</param>
    /// <param name="credential">The API key used to authenticate with the service endpoint.</param>
    /// <param name="options">Additional options to customize the client.</param>
    public AudioClient(string model, KeyCredential credential, AudioClientOptions options = null)
        : this(endpoint: null, model, credential, options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="AudioClient"/>, used for audio operation requests. 
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
    /// <param name="model">The model name for audio operations that the client should use.</param>
    /// <param name="options">Additional options to customize the client.</param>
    public AudioClient(string model, AudioClientOptions options = null)
        : this(endpoint: null, model, credential: null, options)
    { }

    /// <summary>
    /// Creates text-to-speech audio that reflects the specified voice speaking the provided input text.
    /// </summary>
    /// <remarks>
    /// Unless otherwise specified via <see cref="TextToSpeechOptions.ResponseFormat"/>, the <c>mp3</c> format of
    /// <see cref="AudioDataFormat.Mp3"/> will be used for the generated audio.
    /// </remarks>
    /// <param name="input"> The text for the voice to speak. </param>
    /// <param name="voice"> The voice to use. </param>
    /// <param name="options"> Additional options to control the text-to-speech operation. </param>
    /// <param name="cancellationToken"> A cancellation token for the operation. </param>
    /// <returns>
    ///     A result containing generated, spoken audio in the specified output format.
    ///     Unless otherwise specified via <see cref="TextToSpeechOptions.ResponseFormat"/>, the <c>mp3</c> format of
    ///     <see cref="AudioDataFormat.Mp3"/> will be used for the generated audio.
    /// </returns>
    public virtual Result<BinaryData> GenerateSpeechFromText(
        string input,
        TextToSpeechVoice voice,
        TextToSpeechOptions options = null,
        CancellationToken cancellationToken = default)
    {
        Internal.CreateSpeechRequest request = CreateInternalTtsRequest(input, voice, options);
        return Shim.CreateSpeech(request, cancellationToken);
    }

    /// <summary>
    /// Creates text-to-speech audio that reflects the specified voice speaking the provided input text.
    /// </summary>
    /// <remarks>
    /// Unless otherwise specified via <see cref="TextToSpeechOptions.ResponseFormat"/>, the <c>mp3</c> format of
    /// <see cref="AudioDataFormat.Mp3"/> will be used for the generated audio.
    /// </remarks>
    /// <param name="input"> The text for the voice to speak. </param>
    /// <param name="voice"> The voice to use. </param>
    /// <param name="options"> Additional options to control the text-to-speech operation. </param>
    /// <param name="cancellationToken"> A cancellation token for the operation. </param>
    /// <returns>
    ///     A result containing generated, spoken audio in the specified output format.
    ///     Unless otherwise specified via <see cref="TextToSpeechOptions.ResponseFormat"/>, the <c>mp3</c> format of
    ///     <see cref="AudioDataFormat.Mp3"/> will be used for the generated audio.
    /// </returns>
    public virtual Task<Result<BinaryData>> GenerateSpeechFromTextAsync(
        string input,
        TextToSpeechVoice voice,
        TextToSpeechOptions options = null,
        CancellationToken cancellationToken = default)
    {
        Internal.CreateSpeechRequest request = CreateInternalTtsRequest(input, voice, options);
        return Shim.CreateSpeechAsync(request, cancellationToken);
    }

    /// <inheritdoc cref="Internal.Audio.CreateSpeech(RequestBody, RequestOptions)"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result GenerateSpeechFromText(RequestBody content, RequestOptions context = null)
        => Shim.CreateSpeech(content, context);

    /// <inheritdoc cref="Internal.Audio.CreateSpeech(RequestBody, RequestOptions)"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> GenerateSpeechFromTextAsync(RequestBody content, RequestOptions context = null)
        => Shim.CreateSpeechAsync(content, context);

    private Internal.CreateSpeechRequest CreateInternalTtsRequest(
        string input,
        TextToSpeechVoice voice,
        TextToSpeechOptions options = null)
    {
        options ??= new();
        Internal.CreateSpeechRequestResponseFormat? internalResponseFormat = null;
        if (options.ResponseFormat != null)
        {
            internalResponseFormat = options.ResponseFormat.ToString().ToLowerInvariant();
        }
        return new Internal.CreateSpeechRequest(
            _clientConnector.Model,
            input,
            voice.ToString(),
            internalResponseFormat,
            options?.SpeedMultiplier,
            serializedAdditionalRawData: null);
    }
}
