using System.ClientModel;
using System.ClientModel.Primitives.Pipeline;
using System.ClientModel.Primitives;
using System.Threading;

namespace OpenAI.Official;

/// <summary>
/// Client-level options for the OpenAI service.
/// </summary>
public partial class OpenAIClientOptions : RequestOptions
{
    internal Internal.OpenAIClientOptions InternalOptions { get; }

    /// <inheritdoc cref="RequestOptions.CancellationToken"/>
    public new CancellationToken CancellationToken
    {
        get => InternalOptions.CancellationToken;
        set => InternalOptions.CancellationToken = value;
    }

    /// <inheritdoc cref="RequestOptions.ErrorBehavior"/>
    public new ErrorBehavior ErrorBehavior
    {
        get => InternalOptions.ErrorBehavior;
        set => InternalOptions.ErrorBehavior = value;
    }

    /// <inheritdoc cref="RequestOptions.PerTryPolicies"/>
    public new IPipelinePolicy<PipelineMessage>[]? PerTryPolicies
    {
        get => InternalOptions.PerTryPolicies;
        set => InternalOptions.PerTryPolicies = value;
    }

    /// <inheritdoc cref="RequestOptions.PerCallPolicies"/>
    public new IPipelinePolicy<PipelineMessage>[]? PerCallPolicies
    {
        get => InternalOptions.PerCallPolicies;
        set => InternalOptions.PerCallPolicies = value;
    }

    /// <inheritdoc cref="RequestOptions.RetryPolicy"/>
    public new IPipelinePolicy<PipelineMessage>? RetryPolicy
    {
        get => InternalOptions.RetryPolicy;
        set => InternalOptions.RetryPolicy = value;
    }

    /// <inheritdoc cref="RequestOptions.LoggingPolicy"/>
    public new IPipelinePolicy<PipelineMessage>? LoggingPolicy {
        get => InternalOptions.LoggingPolicy; set => InternalOptions.LoggingPolicy = value;
    }

    /// <inheritdoc cref="RequestOptions.Transport"/>
    public new PipelineTransport<PipelineMessage>? Transport
    {
        get => InternalOptions.Transport;
        set => InternalOptions.Transport = value;
    }

    /// <inheritdoc cref="RequestOptions.BufferResponse"/>
    public new bool BufferResponse
    {
        get => InternalOptions.BufferResponse;
        set => InternalOptions.BufferResponse = value;
    }

    internal OpenAIClientOptions(Internal.OpenAIClientOptions internalOptions = null)
    {
        internalOptions ??= new();
        InternalOptions = internalOptions;
    }
}
