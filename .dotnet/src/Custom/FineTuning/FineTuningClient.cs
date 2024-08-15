using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI.FineTuning;

/// <summary>
/// The service client for OpenAI fine-tuning operations.
/// </summary>
[CodeGenClient("FineTuning")]
[CodeGenSuppress("CreateFineTuningJobAsync", typeof(FineTuningOptions))]
[CodeGenSuppress("CreateFineTuningJob", typeof(FineTuningOptions))]
[CodeGenSuppress("GetPaginatedFineTuningJobsAsync", typeof(string), typeof(int?))]
[CodeGenSuppress("GetPaginatedFineTuningJobs", typeof(string), typeof(int?))]
[CodeGenSuppress("RetrieveFineTuningJobAsync", typeof(string))]
[CodeGenSuppress("RetrieveFineTuningJob", typeof(string))]
[CodeGenSuppress("CancelFineTuningJobAsync", typeof(string))]
[CodeGenSuppress("CancelFineTuningJob", typeof(string))]
[CodeGenSuppress("GetFineTuningEventsAsync", typeof(string), typeof(string), typeof(int?))]
[CodeGenSuppress("GetFineTuningEvents", typeof(string), typeof(string), typeof(int?))]
[CodeGenSuppress("GetFineTuningJobCheckpointsAsync", typeof(string), typeof(string), typeof(int?))]
[CodeGenSuppress("GetFineTuningJobCheckpoints", typeof(string), typeof(string), typeof(int?))]
public partial class FineTuningClient
{
    // Customization: documented constructors, apply protected visibility    

    /// <summary>
    /// Initializes a new instance of <see cref="FineTuningClient"/> that will use an API key when authenticating.
    /// </summary>
    /// <param name="credential"> The API key used to authenticate with the service endpoint. </param>
    /// <param name="options"> Additional options to customize the client. </param>
    /// <exception cref="ArgumentNullException"> The provided <paramref name="credential"/> was null. </exception>
    public FineTuningClient(ApiKeyCredential credential, OpenAIClientOptions options = null)
        : this(
              OpenAIClient.CreatePipeline(OpenAIClient.GetApiKey(credential, requireExplicitCredential: true), options),
              OpenAIClient.GetEndpoint(options),
              options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="FineTuningClient"/> that will use an API key from the OPENAI_API_KEY
    /// environment variable when authenticating.
    /// </summary>
    /// <remarks>
    /// To provide an explicit credential instead of using the environment variable, use an alternate constructor like
    /// <see cref="FineTuningClient(ApiKeyCredential,OpenAIClientOptions)"/>.
    /// </remarks>
    /// <param name="options"> Additional options to customize the client. </param>
    /// <exception cref="InvalidOperationException"> The OPENAI_API_KEY environment variable was not found. </exception>
    public FineTuningClient(OpenAIClientOptions options = null)
        : this(
              OpenAIClient.CreatePipeline(OpenAIClient.GetApiKey(), options),
              OpenAIClient.GetEndpoint(options),
              options)
    { }

    /// <summary> Initializes a new instance of FineTuningClient. </summary>
    /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
    /// <param name="endpoint"> OpenAI Endpoint. </param>
    protected internal FineTuningClient(ClientPipeline pipeline, Uri endpoint, OpenAIClientOptions options)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
    }

    /// <summary> Creates a job with a training file and model. </summary>
    /// <param name="model"> The model name to fine-tune. String such as "gpt-3.5-turbo" </param>
    /// <param name="trainingFileId"> The training file name that is already uploaded. String should match pattern '^file-[a-zA-Z0-9]{24}$'. </param>
    /// <param name="options"> Additional options (<see cref="FineTuningOptions"/>) to customize the request. </param>
    /// <returns>A <see cref="ClientResult{FineTuningJob}"/> containing the newly started fine-tuning job.</returns>
    public ClientResult<FineTuningJob> CreateJob(
        string model,
        string trainingFileId,
        FineTuningOptions options = default,
        CancellationToken cancellationToken = default
        )
    {
        options ??= new FineTuningOptions();
        options.Model = model;
        options.TrainingFile = trainingFileId;

        ClientResult result = CreateJob(options.ToBinaryContent(), cancellationToken.ToRequestOptions());
        return ClientResult.FromValue(FineTuningJob.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary> Async Creates a job with a training file and model. </summary>
    /// <param name="model"> The model name to fine-tune. String such as "gpt-3.5-turbo" </param>
    /// <param name="trainingFileId"> The training file Id that is already uploaded. String should match pattern '^file-[a-zA-Z0-9]{24}$'. </param>
    /// <param name="options"> Additional options (<see cref="FineTuningOptions"/>) to customize the request. </param>
    /// <returns>A <see cref="Task"/> of a <see cref="ClientResult{FineTuningJob}"/> containing the newly started fine-tuning job.</returns>
    public async Task<ClientResult<FineTuningJob>> CreateJobAsync(
        string model,
        string trainingFileId,
        FineTuningOptions options = default,
        CancellationToken cancellationToken = default
        )
    {
       
        options ??= new FineTuningOptions();
        options.Model = model;
        options.TrainingFile = trainingFileId;

        ClientResult result = await CreateJobAsync(options.ToBinaryContent(), cancellationToken.ToRequestOptions());
        return ClientResult.FromValue(FineTuningJob.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary>
    /// Cancels a fine-tuning job with the specified job ID.
    /// </summary>
    /// <param name="jobId">The ID of the job to cancel.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="ClientResult{FineTuningJob}"/> containing the canceled fine-tuning job.</returns>
    public ClientResult<FineTuningJob> CancelJob(string jobId, CancellationToken cancellationToken = default)
    {
        ClientResult result = CancelJob(jobId, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue(FineTuningJob.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary> Async version of cancel job</summary>
    /// <param name="jobId"> The job ID to cancel. </param>
    /// <param name="cancellationToken"> The cancellation token. </param>
    /// <returns> A <see cref="Task{T}"/> of <see cref="ClientResult{FineTuningJob}"/> containing the canceled fine-tuning job. </returns>
    public async Task<ClientResult<FineTuningJob>> CancelJobAsync(string jobId, CancellationToken cancellationToken = default)
    {
        ClientResult result = await CancelJobAsync(jobId, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue(FineTuningJob.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    public async Task<ClientResult<FineTuningJob>> GetJobAsync(string jobId)
    {
        ClientResult result = await GetJobAsync(jobId, null);
        return ClientResult.FromValue(FineTuningJob.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    public async Task<FineTuningJob> WaitUntilCompleted(FineTuningJob job)
    {
        while (job.Status.InProgress())
        {
            var estimate = job.EstimatedFinishAt;

            if (estimate.HasValue)
            {
                // Console.WriteLine($"Waiting for {estimate.Value - DateTimeOffset.UtcNow}");
                await Task.Delay(estimate.Value - DateTimeOffset.UtcNow);
            }
            else
            {
                // Console.WriteLine("Waiting for 30 seconds");
                await Task.Delay(30 * 1000);
            }

            job = await GetJobAsync(job.Id);
        }
        return job;
    }
}
