using System;
using System.ClientModel;
using System.ClientModel.Internal;


namespace OpenAI.Official;

// This internal type facilitates composition rather than inheritance for scenario clients.

internal partial class OpenAIClientConnector
{
    private static readonly string s_OpenAIEndpointEnvironmentVariable = "OPENAI_ENDPOINT";
    private static readonly string s_OpenAIApiKeyEnvironmentVariable = "OPENAI_API_KEY";
    private static readonly string s_defaultOpenAIV1Endpoint = "https://api.openai.com/v1";

    internal Internal.OpenAIClient InternalClient { get; }
    internal string Model { get; }

    internal OpenAIClientConnector(
        string model,
        Uri endpoint = null,
        ApiKeyCredential credential = null,
        OpenAIClientOptions options = null)
    {
        if (model is null) throw new ArgumentNullException(nameof(model));        Model = model;
        endpoint ??= new(Environment.GetEnvironmentVariable(s_OpenAIEndpointEnvironmentVariable) ?? s_defaultOpenAIV1Endpoint);
        credential ??= new(Environment.GetEnvironmentVariable(s_OpenAIApiKeyEnvironmentVariable) ?? string.Empty);
        options ??= new();
        InternalClient = new(endpoint, credential, options.InternalOptions);
    }
}
