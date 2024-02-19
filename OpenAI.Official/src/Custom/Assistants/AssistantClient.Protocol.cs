using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Threading.Tasks;

namespace OpenAI.Official.Assistants;

public partial class AssistantClient
{

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result CreateAssistant(RequestBody content, RequestOptions context = null)
    {
        return Shim.CreateAssistant(content, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> CreateAssistantAsync(RequestBody content, RequestOptions context = null)
    {
        return Shim.CreateAssistantAsync(content, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result GetAssistant(string assistantId, RequestOptions context)
    {
        return Shim.GetAssistant(assistantId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> GetAssistantAsync(string assistantId, RequestOptions context)
    {
        return Shim.GetAssistantAsync(assistantId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result GetAssistants(
        int? maxResults,
        string createdSortOrder,
        string previousAssistantId,
        string subsequentAssistantId,
        RequestOptions context)
    {
        return Shim.GetAssistants(maxResults, createdSortOrder, previousAssistantId, subsequentAssistantId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> GetAssistantsAsync(
        int? maxResults,
        string createdSortOrder,
        string previousAssistantId,
        string subsequentAssistantId,
        RequestOptions context)
    {
        return Shim.GetAssistantsAsync(maxResults, createdSortOrder, previousAssistantId, subsequentAssistantId, context);
    }


    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result ModifyAssistant(string assistantId, RequestBody content, RequestOptions context = null)
    {
        return Shim.ModifyAssistant(assistantId, content, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> ModifyAssistantAsync(string assistantId, RequestBody content, RequestOptions context = null)
    {
        return Shim.ModifyAssistantAsync(assistantId, content, context);
    }


    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result DeleteAssistant(string assistantId, RequestOptions context)
    {
        return Shim.DeleteAssistant(assistantId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> DeleteAssistantAsync(string assistantId, RequestOptions context)
    {
        return Shim.DeleteAssistantAsync(assistantId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result CreateAssistantFileAssociation(
        string assistantId,
        RequestBody content,
        RequestOptions context = null)
    {
        return Shim.CreateAssistantFile(assistantId, content, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> CreateAssistantFileAssociationAsync(
        string assistantId,
        RequestBody content,
        RequestOptions context = null)
    {
        return Shim.CreateAssistantFileAsync(assistantId, content, context);
    }


    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result GetAssistantFileAssociation(string assistantId, string fileId, RequestOptions context)
    {
        return Shim.GetAssistantFile(assistantId, fileId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> GetAssistantFileAssociationAsync(string assistantId, string fileId, RequestOptions context)
    {
        return Shim.GetAssistantFileAsync(assistantId, fileId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Result GetAssistantFileAssociations(
        string assistantId,
        int? maxResults,
        string createdSortOrder,
        string previousId,
        string subsequentId,
        RequestOptions context)
    {
        return Shim.GetAssistantFiles(assistantId, maxResults, createdSortOrder, previousId, subsequentId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Task<Result> GetAssistantFileAssociationsAsync(
        string assistantId,
        int? maxResults,
        string createdSortOrder,
        string previousId,
        string subsequentId,
        RequestOptions context)
    {
        return Shim
            .GetAssistantFilesAsync(assistantId, maxResults, createdSortOrder, previousId, subsequentId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result RemoveAssistantFileAssociation(string assistantId, string fileId, RequestOptions context)
    {
        return Shim.DeleteAssistantFile(assistantId, fileId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> RemoveAssistantFileAssociationAsync(string assistantId, string fileId, RequestOptions context)
    {
        return Shim.DeleteAssistantFileAsync(assistantId, fileId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result CreateThread(RequestBody content, RequestOptions context = null)
    {
        return ThreadShim.CreateThread(content, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> CreateThreadAsync(RequestBody content, RequestOptions context = null)
    {
        return ThreadShim.CreateThreadAsync(content, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result GetThread(string threadId, RequestOptions context)
    {
        return ThreadShim.GetThread(threadId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> GetThreadAsync(string threadId, RequestOptions context)
    {
        return ThreadShim.GetThreadAsync(threadId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result ModifyThread(string threadId, RequestBody content, RequestOptions context = null)
    {
        return ThreadShim.ModifyThread(threadId, content, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> ModifyThreadAsync(string threadId, RequestBody content, RequestOptions context = null)
    {
        return ThreadShim.ModifyThreadAsync(threadId, content, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result DeleteThread(string threadId, RequestOptions context)
    {
        return ThreadShim.DeleteThread(threadId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> DeleteThreadAsync(string threadId, RequestOptions context)
    {
        return ThreadShim.DeleteThreadAsync(threadId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result CreateMessage(string threadId, RequestBody content, RequestOptions context = null)
    {
        return MessageShim.CreateMessage(threadId, content, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> CreateMessageAsync(string threadId, RequestBody content, RequestOptions context = null)
    {
        return MessageShim.CreateMessageAsync(threadId, content, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result GetMessage(string threadId, string messageId, RequestOptions context)
    {
        return MessageShim.GetMessage(threadId, messageId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> GetMessageAsync(string threadId, string messageId, RequestOptions context)
    {
        return MessageShim.GetMessageAsync(threadId, messageId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result GetMessages(
        string threadId,
        int? maxResults,
        string createdSortOrder,
        string previousMessageId,
        string subsequentMessageId,
        RequestOptions context)
    {
        return MessageShim
            .GetMessages(threadId, maxResults, createdSortOrder, previousMessageId, subsequentMessageId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> GetMessagesAsync(
        string threadId,
        int? maxResults,
        string createdSortOrder,
        string previousMessageId,
        string subsequentMessageId,
        RequestOptions context)
    {
        return MessageShim
            .GetMessagesAsync(threadId, maxResults, createdSortOrder, previousMessageId, subsequentMessageId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result GetMessageFileAssociation(string threadId, string messageId, string fileId, RequestOptions context)
    {
        return MessageShim.GetMessageFile(threadId, messageId, fileId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> GetMessageFileAssociationAsync(
        string threadId,
        string messageId,
        string fileId,
        RequestOptions context)
    {
        return MessageShim.GetMessageFileAsync(threadId, messageId, fileId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result GetMessageFileAssociations(
        string threadId,
        string messageId,
        int? maxResults,
        string createdSortOrder,
        string previousId ,
        string subsequentId,
        RequestOptions context)
    {
        return MessageShim
            .GetMessageFiles(threadId, messageId, maxResults, createdSortOrder, previousId, subsequentId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> GetMessageFileAssociationsAsync(
        string threadId,
        string messageId,
        int? maxResults,
        string createdSortOrder,
        string previousId,
        string subsequentId,
        RequestOptions context)
    {
        return MessageShim
            .GetMessageFilesAsync(threadId, messageId, maxResults, createdSortOrder, previousId, subsequentId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result CreateRun(string threadId, RequestBody content, RequestOptions context = null)
    {
        return RunShim.CreateRun(threadId, content, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> CreateRunAsync(string threadId, RequestBody content, RequestOptions context = null)
    {
        return RunShim.CreateRunAsync(threadId, content, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result CreateThreadAndRun(RequestBody content, RequestOptions context = null)
    {
        return RunShim.CreateThreadAndRun(content, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> CreateThreadAndRunAsync(RequestBody content, RequestOptions context = null)
    {
        return RunShim.CreateThreadAndRunAsync(content, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result GetRun(string threadId, string runId, RequestOptions context)
    {
        return RunShim.GetRun(threadId, runId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> GetRunAsync(string threadId, string runId, RequestOptions context)
    {
        return RunShim.GetRunAsync(threadId, runId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Result GetRuns(
        string threadId,
        int? maxResults,
        string createdSortOrder,
        string previousRunId,
        string subsequentRunId,
        RequestOptions context)
    {
        return RunShim.GetRuns(threadId, maxResults, createdSortOrder, previousRunId, subsequentRunId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> GetRunsAsync(
        string threadId,
        int? maxResults,
        string createdSortOrder,
        string previousRunId,
        string subsequentRunId,
        RequestOptions context)
    {
        return RunShim.GetRunsAsync(threadId, maxResults, createdSortOrder, previousRunId, subsequentRunId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result ModifyRun(string threadId, string runId, RequestBody content, RequestOptions context = null)
    {
        return RunShim.ModifyRun(threadId, runId, content, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> ModifyRunAsync(
        string threadId,
        string runId,
        RequestBody content,
        RequestOptions context = null)
    {
        return RunShim.ModifyRunAsync(threadId, runId, content, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result CancelRun(string threadId, string runId, RequestOptions context)
    {
        return RunShim.CancelRun(threadId, runId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> CancelRunAsync(string threadId, string runId, RequestOptions context)
    {
        return RunShim.CancelRunAsync(threadId, runId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result SubmitToolOutputs(string threadId, string runId, RequestBody content, RequestOptions context = null)
    {
        return RunShim.SubmitToolOuputsToRun(threadId, runId, content, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> SubmitToolOutputsAsync(string threadId, string runId, RequestBody content, RequestOptions context = null)
    {
        return RunShim.SubmitToolOuputsToRunAsync(threadId, runId, content, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result GetRunStep(string threadId, string runId, string stepId, RequestOptions context)
    {
        return RunShim.GetRunStep(threadId, runId, stepId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> GetRunStepAsync(string threadId, string runId, string stepId, RequestOptions context)
    {
        return RunShim.GetRunStepAsync(threadId, runId, stepId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Result GetRunSteps(
        string threadId,
        string runId,
        int? maxResults,
        string createdSortOrder,
        string previousStepId,
        string subsequentStepId,
        RequestOptions context)
    {
        return RunShim
            .GetRunSteps(threadId, runId, maxResults, createdSortOrder, previousStepId, subsequentStepId, context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<Result> GetRunStepsAsync(
        string threadId,
        string runId,
        int? maxResults,
        string createdSortOrder,
        string previousStepId,
        string subsequentStepId,
        RequestOptions context)
    {
        return RunShim
            .GetRunStepsAsync(threadId, runId, maxResults, createdSortOrder, previousStepId, subsequentStepId, context);
    }
}
