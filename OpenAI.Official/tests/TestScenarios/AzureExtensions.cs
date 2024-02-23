using NUnit.Framework;
using OpenAI.Chat;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace OpenAI.Tests.Chat;

public partial class AzureExtensionsTests
{
    [Test]
    public void HelloWorldChat()
    {
        string key = Environment.GetEnvironmentVariable("AZ_OPENAI_KEY")!;
        string endpoint = Environment.GetEnvironmentVariable("AZ_OPENAI_ENDPOINT")!;

        var options = new AzureOpenAIClientOptions(new Uri(endpoint), key, "gpt35turbo");
        ChatClient client = new ChatClient("", new ApiKeyCredential(key), options);

        Assert.That(client, Is.InstanceOf<ChatClient>());
        ClientResult<ChatCompletion> result = client.CompleteChat("Hello, world!");
        Assert.That(result, Is.InstanceOf<ClientResult<ChatCompletion>>());
        Assert.That(result.Value.Content?.ContentKind, Is.EqualTo(ChatMessageContentKind.Text));
        Assert.That(result.Value.Content.ToText().Length, Is.GreaterThan(0));
    }
}

public class AzureOpenAIClientOptions : OpenAIClientOptions
{
    public AzureOpenAIClientOptions(Uri endpoint, ApiKeyCredential apiKey, string deployment, ServiceVersion version = ServiceVersion.V20231201_preview)
    {
        base.AddPolicy(new ToAzureRequestPolicy(endpoint, apiKey, deployment, version), PipelinePosition.BeforeTransport);
    }

    public enum ServiceVersion
    {
        V20231201_preview
    }

    class ToAzureRequestPolicy : PipelinePolicy
    {
        Uri endpoint;
        string deployment;
        string version;
        ApiKeyCredential apiKey;

        public ToAzureRequestPolicy(Uri endpoint, ApiKeyCredential apiKey, string deployment, ServiceVersion version)
        {
            this.endpoint=endpoint;
            this.deployment=deployment;
            this.version=version == ServiceVersion.V20231201_preview? "2023-12-01-preview" : throw new NotSupportedException();
            this.apiKey=apiKey;
        }

        private void RewriteRequest(PipelineMessage message)
        {
            apiKey.Deconstruct(out string key);
            message.Request.Headers.Add("api-key", key);
            message.Request.Headers.Remove("Authorization");

            var uri = message.Request.Uri.PathAndQuery.ToString();
            string operation = "";
            if (uri.EndsWith("chat/completions")) operation = "chat/completions";
            else throw new NotImplementedException();
            message.Request.Uri = new Uri($"{endpoint}openai/deployments/{deployment}/{operation}?api-version={version}");
        }

        public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            RewriteRequest(message);
            ProcessNext(message, pipeline, currentIndex);
        }

        public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            RewriteRequest(message);
            await ProcessNextAsync(message, pipeline, currentIndex).ConfigureAwait(false);
        }
    }
}


