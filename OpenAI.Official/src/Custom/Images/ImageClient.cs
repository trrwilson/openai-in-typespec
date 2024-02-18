using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI.Official.Images;

/// <summary> The service client for OpenAI image operations. </summary>
public partial class ImageClient
{
    private OpenAIClientConnector _clientConnector;
    private Internal.Images Shim => _clientConnector.InternalClient.GetImagesClient();

    /// <summary>
    /// Initializes a new instance of <see cref="ImageClient"/>, used for image operation requests. 
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
    /// <param name="model">The model name for image operations that the client should use.</param>
    /// <param name="credential">The API key used to authenticate with the service endpoint.</param>
    /// <param name="options">Additional options to customize the client.</param>
    public ImageClient(Uri endpoint, string model, KeyCredential credential, ImageClientOptions options = null)
    {
        _clientConnector = new(model, endpoint, credential, options);
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ImageClient"/>, used for image operation requests. 
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
    /// <param name="model">The model name for image operations that the client should use.</param>
    /// <param name="options">Additional options to customize the client.</param>
    public ImageClient(Uri endpoint, string model, ImageClientOptions options = null)
        : this(endpoint, model, credential: null, options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="ImageClient"/>, used for image operation requests. 
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
    /// <param name="model">The model name for image operations that the client should use.</param>
    /// <param name="credential">The API key used to authenticate with the service endpoint.</param>
    /// <param name="options">Additional options to customize the client.</param>
    public ImageClient(string model, KeyCredential credential, ImageClientOptions options = null)
        : this(endpoint: null, model, credential, options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="ImageClient"/>, used for image operation requests. 
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
    /// <param name="model">The model name for image operations that the client should use.</param>
    /// <param name="options">Additional options to customize the client.</param>
    public ImageClient(string model, ImageClientOptions options = null)
        : this(endpoint: null, model, credential: null, options)
    { }

    /// <summary>
    /// Generates a single image for a provided prompt.
    /// </summary>
    /// <param name="prompt"> The description and instructions for the image. </param>
    /// <param name="options"> Additional options for the image generation request. </param>
    /// <param name="cancellationToken"> The cancellation token for the operation. </param>
    /// <returns> A result for a single image generation. </returns>
    public virtual Result<ImageGeneration> GenerateImage(string prompt, ImageGenerationOptions options = null, CancellationToken cancellationToken = default)
    {
        Result<ImageGenerationCollection> multiResult = GenerateImages(prompt, imageCount: null, options, cancellationToken);
        return Result.FromValue(multiResult.Value[0], multiResult.GetRawResponse());
    }

    /// <summary>
    /// Generates a single image for a provided prompt.
    /// </summary>
    /// <param name="prompt"> The description and instructions for the image. </param>
    /// <param name="options"> Additional options for the image generation request. </param>
    /// <param name="cancellationToken"> The cancellation token for the operation. </param>
    /// <returns> A result for a single image generation. </returns>
    public virtual async Task<Result<ImageGeneration>> GenerateImageAsync(string prompt, ImageGenerationOptions options = null, CancellationToken cancellationToken = default)
    {
        Result<ImageGenerationCollection> multiResult = await GenerateImagesAsync(prompt, imageCount: null, options, cancellationToken).ConfigureAwait(false);
        return Result.FromValue(multiResult.Value[0], multiResult.GetRawResponse());
    }

    /// <summary>
    /// Generates a collection of image alternatives for a provided prompt.
    /// </summary>
    /// <param name="prompt"> The description and instructions for the image. </param>
    /// <param name="imageCount">
    ///     The number of alternative images to generate for the prompt.
    /// </param>
    /// <param name="options"> Additional options for the image generation request. </param>
    /// <param name="cancellationToken"> The cancellation token for the operation. </param>
    /// <returns> A result for a single image generation. </returns>
    public virtual Result<ImageGenerationCollection> GenerateImages(
        string prompt,
        int? imageCount = null,
        ImageGenerationOptions options = null,
        CancellationToken cancellationToken = default)
    {
        Internal.CreateImageRequest request = CreateInternalRequest(prompt, imageCount, options);
        Result<Internal.ImagesResponse> response = Shim.CreateImage(request, cancellationToken);
        List<ImageGeneration> ImageGenerations = [];
        for (int i = 0; i < response.Value.Data.Count; i++)
        {
            ImageGenerations.Add(new(response.Value, i));
        }
        return Result.FromValue(new ImageGenerationCollection(ImageGenerations), response.GetRawResponse());
    }

    /// <summary>
    /// Generates a collection of image alternatives for a provided prompt.
    /// </summary>
    /// <param name="prompt"> The description and instructions for the image. </param>
    /// <param name="imageCount">
    ///     The number of alternative images to generate for the prompt.
    /// </param>
    /// <param name="options"> Additional options for the image generation request. </param>
    /// <param name="cancellationToken"> The cancellation token for the operation. </param>
    /// <returns> A result for a single image generation. </returns>
    public virtual async Task<Result<ImageGenerationCollection>> GenerateImagesAsync(
        string prompt,
        int? imageCount = null,
        ImageGenerationOptions options = null,
        CancellationToken cancellationToken = default)
    {
        Internal.CreateImageRequest request = CreateInternalRequest(prompt, imageCount, options);
        Result<Internal.ImagesResponse> response = await Shim.CreateImageAsync(request, cancellationToken).ConfigureAwait(false);
        List<ImageGeneration> ImageGenerations = [];
        for (int i = 0; i < response.Value.Data.Count; i++)
        {
            ImageGenerations.Add(new(response.Value, i));
        }
        return Result.FromValue(new ImageGenerationCollection(ImageGenerations), response.GetRawResponse());
    }

    /// <inheritdoc cref="Internal.Images.CreateImage(RequestBody, RequestOptions)"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result GenerateImage(RequestBody content, RequestOptions context = null)
        => Shim.CreateImage(content, context);

    /// <inheritdoc cref="Internal.Images.CreateImageAsync(RequestBody, RequestOptions)"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> GenerateImageAsync(RequestBody content, RequestOptions context = null)
        => Shim.CreateImageAsync(content, context);

    private Internal.CreateImageRequest CreateInternalRequest(
        string prompt,
        int? imageCount = null,
        ImageGenerationOptions options = null)
    {
        options ??= new();
        Internal.CreateImageRequestQuality? internalQuality = null;
        if (options.Quality != null)
        {
            internalQuality = options.Quality.ToString();
        }
        Internal.CreateImageRequestResponseFormat? internalFormat = null;
        if (options.ResponseFormat != null)
        {
            internalFormat = options.ResponseFormat.ToString();
        }
        Internal.CreateImageRequestSize? internalSize = null;
        if (options.Size != null)
        {
            internalSize = options.Size.ToString();
        }
        Internal.CreateImageRequestStyle? internalStyle = null;
        if (options.Style != null)
        {
            internalStyle = options.Style.ToString();
        }
        return new Internal.CreateImageRequest(
            prompt,
            _clientConnector.Model,
            imageCount,
            quality: internalQuality,
            responseFormat: internalFormat,
            size: internalSize,
            style: internalStyle,
            options.User,
            serializedAdditionalRawData: null);
    }
}
