using OpenAI.Official.Assistants;
using OpenAI.Official.Audio;
using OpenAI.Official.Chat;
using OpenAI.Official.Embeddings;
using OpenAI.Official.Files;
using OpenAI.Official.FineTuning;
using OpenAI.Official.Images;
using OpenAI.Official.LegacyCompletions;
using OpenAI.Official.Models;
using OpenAI.Official.Moderations;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace OpenAI.Official;

/// <summary>
/// A top-level client factory that enables convenient creation of scenario-specific sub-clients while reusing shared
/// configuration details like endpoint, authentication, and pipeline customization.
/// </summary>
public partial class OpenAIClient
{
    private readonly Uri _cachedEndpoint = null;
    private readonly ApiKeyCredential _cachedCredential = null;
    private readonly OpenAIClientOptions _cachedOptions = null;

    public OpenAIClient(Uri endpoint = null, ApiKeyCredential credential = null, OpenAIClientOptions clientOptions = null)
    {
        _cachedEndpoint = endpoint;
        _cachedCredential = credential;
        _cachedOptions = clientOptions;
    }

    public AssistantClient GetAssistantClient()
    {
        AssistantClientOptions assistantOptions = new();
        _cachedOptions.CopyTo(assistantOptions);
        return new AssistantClient(assistantOptions);
    }

    public AudioClient GetAudio(string model)
    {
        AudioClientOptions audioOptions = new();
        _cachedOptions.CopyTo(audioOptions);
        return new AudioClient(_cachedEndpoint, model, _cachedCredential, audioOptions);
    }

    public ChatClient GetChatClient(string model)
    {
        ChatClientOptions chatOptions = new();
        _cachedOptions?.CopyTo(chatOptions);
        return new ChatClient(_cachedEndpoint, model, _cachedCredential, chatOptions);
    }

    public EmbeddingClient GetEmbeddingClient(string model)
    {
        EmbeddingClientOptions embeddingOptions = new();
        _cachedOptions?.CopyTo(embeddingOptions);
        return new EmbeddingClient(_cachedEndpoint, model, _cachedCredential, embeddingOptions);
    }

    public FileClient GetFileClient()
    {
        FileClientOptions fileOptions = new();
        _cachedOptions?.CopyTo(fileOptions);
        return new FileClient(_cachedEndpoint, _cachedCredential, fileOptions);
    }

    public FineTuningClient GetFineTuningClient()
    {
        FineTuningClientOptions fineTuningClientOptions = new();
        _cachedOptions.CopyTo(fineTuningClientOptions);
        return new FineTuningClient(_cachedEndpoint, _cachedCredential, fineTuningClientOptions);
    }

    public ImageClient GetImageClient(string model)
    {
        ImageClientOptions imageOptions = new();
        _cachedOptions?.CopyTo(imageOptions);
        return new ImageClient(_cachedEndpoint, model, _cachedCredential, imageOptions);
    }

    public LegacyCompletionClient GetLegacyCompletionClient()
    {
        LegacyCompletionClientOptions legacyCompletionClientOptions = new();
        _cachedOptions.CopyTo(legacyCompletionClientOptions);
        return new LegacyCompletionClient(_cachedEndpoint, _cachedCredential, legacyCompletionClientOptions);
    }

    public ModelClient GetModelClient()
    {
        ModelClientOptions modelOptions = new();
        _cachedOptions.CopyTo(modelOptions);
        return new ModelClient(_cachedEndpoint, _cachedCredential, modelOptions);
    }

    public ModerationClient GetModerationClient()
    {
        ModerationClientOptions moderationClientOptions = new();
        _cachedOptions.CopyTo(moderationClientOptions);
        return new ModerationClient(_cachedEndpoint, _cachedCredential, moderationClientOptions);
    }
}
