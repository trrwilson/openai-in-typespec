using OpenAI.Assistants;
using OpenAI.Audio;
using OpenAI.Chat;
using OpenAI.Embeddings;
using OpenAI.Files;
using OpenAI.FineTuning;
using OpenAI.Images;
using OpenAI.LegacyCompletions;
using OpenAI.ModelManagement;
using OpenAI.Moderations;
using System;
using System.ClientModel;

namespace OpenAI;

/// <summary>
/// A top-level client factory that enables convenient creation of scenario-specific sub-clients while reusing shared
/// configuration details like endpoint, authentication, and pipeline customization.
/// </summary>
public partial class OpenAIClient
{
    private readonly Uri _cachedEndpoint = null;
    private readonly ApiKeyCredential _cachedCredential = null;
    private readonly OpenAIClientOptions _cachedOptions = null;

    /// <summary>
    /// Creates a new instance of <see cref="OpenAIClient"/> will store common client configuration details to permit
    /// easy reuse and propagation to multiple, scenario-specific subclients.
    /// </summary>
    /// <remarks>
    /// This client does not provide any model functionality directly and is purely a helper to facilitate the creation
    /// of the scenario-specific subclients like <see cref="ChatClient"/>.
    /// </remarks>
    /// <param name="endpoint"> An explicitly defined endpoint that all clients created by this <see cref="OpenAIClient"/> should use. </param>
    /// <param name="credential"> An explicitly defined credential that all clients created by this <see cref="OpenAIClient"/> should use. </param>
    /// <param name="clientOptions"> A common client options definition that all clients created by this <see cref="OpenAIClient"/> should use. </param>
    public OpenAIClient(Uri endpoint = null, ApiKeyCredential credential = null, OpenAIClientOptions clientOptions = null)
    {
        _cachedEndpoint = endpoint;
        _cachedCredential = credential;
        _cachedOptions = clientOptions;
    }

    /// <summary>
    /// Gets a new instance of <see cref="AssistantClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="AssistantClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="AssistantClient"/>. </returns>
    public AssistantClient GetAssistantClient()
        => new AssistantClient(_cachedEndpoint, _cachedCredential, _cachedOptions);

    /// <summary>
    /// Gets a new instance of <see cref="AudioClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="AudioClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="AudioClient"/>. </returns>
    public AudioClient GetAudio(string model)
        => new AudioClient(_cachedEndpoint, model, _cachedCredential, _cachedOptions);

    /// <summary>
    /// Gets a new instance of <see cref="ChatClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="ChatClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="ChatClient"/>. </returns>
    public ChatClient GetChatClient(string model)
        => new ChatClient(_cachedEndpoint, model, _cachedCredential, _cachedOptions);

    /// <summary>
    /// Gets a new instance of <see cref="EmbeddingClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="EmbeddingClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="EmbeddingClient"/>. </returns>
    public EmbeddingClient GetEmbeddingClient(string model)
        => new EmbeddingClient(_cachedEndpoint, model, _cachedCredential, _cachedOptions);

    /// <summary>
    /// Gets a new instance of <see cref="FileClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="FileClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="FileClient"/>. </returns>
    public FileClient GetFileClient()
        => new FileClient(_cachedEndpoint, _cachedCredential, _cachedOptions);

    /// <summary>
    /// Gets a new instance of <see cref="FineTuningClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="FineTuningClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="FineTuningClient"/>. </returns>
    public FineTuningClient GetFineTuningClient()
        => new FineTuningClient(_cachedEndpoint, _cachedCredential, _cachedOptions);

    /// <summary>
    /// Gets a new instance of <see cref="ImageClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="ImageClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="ImageClient"/>. </returns>
    public ImageClient GetImageClient(string model)
        => new ImageClient(_cachedEndpoint, model, _cachedCredential, _cachedOptions);

    /// <summary>
    /// Gets a new instance of <see cref="LegacyCompletionClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="LegacyCompletionClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="LegacyCompletionClient"/>. </returns>
    public LegacyCompletionClient GetLegacyCompletionClient()
        => new LegacyCompletionClient(_cachedEndpoint, _cachedCredential, _cachedOptions);

    /// <summary>
    /// Gets a new instance of <see cref="ModelManagementClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="ModelManagementClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="ModelManagementClient"/>. </returns>
    public ModelManagementClient GetModelManagementClient()
        => new ModelManagementClient(_cachedEndpoint, _cachedCredential, _cachedOptions);

    /// <summary>
    /// Gets a new instance of <see cref="ModerationClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="ModerationClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="ModerationClient"/>. </returns>
    public ModerationClient GetModerationClient()
        => new ModerationClient(_cachedEndpoint, _cachedCredential, _cachedOptions);
}
