using NUnit.Framework;
using OpenAI.Assistants;
using OpenAI.Files;
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using static OpenAI.Tests.TestHelpers;

namespace OpenAI.Tests.Examples;

public partial class AssistantExamples
{
    [Test]
    [Ignore("Compilation validation only")]
    public void ListAllAssistants()
    {
        AssistantClient client = new();
        string latestId = null;
        bool continueQuery = true;
        int count = 0;

        while (continueQuery)
        {
            var assistantList = client.GetAssistants(previousAssistantId: latestId).Value;
            foreach (Assistant assistant in assistantList)
            {
                Console.WriteLine($"[{count,3}] {assistant.Id} {assistant.CreatedAt:s} {assistant.Name}");
                latestId = assistant.Id;
                count++;
            }
            continueQuery = assistantList.HasMore;
        }
    }

    [Test]
    // [Ignore("Compilation validation only")]
    public async Task SimpleRetrievalAugmentedGeneration()
    {
        // First, let's contrive a document we'll use retrieval with and upload it.
        BinaryData contrivedDocumentBody = BinaryData.FromObjectAsJson(new
        {
            description = "This document contains sale history data for Contoso products.",
            sales = new dynamic[]
            {
                new
                {
                    month = "January",
                    by_product = new Dictionary<int, int>()
                    {
                        [113043] = 15,
                        [113045] = 12,
                        [113049] = 2,
                    },
                },
                new
                {
                    month = "February",
                    by_product = new Dictionary<int, int>()
                    {
                        [113045] = 22,
                    }
                },
                new
                {
                    month = "March",
                    by_product = new Dictionary<int, int>()
                    {
                        [113045] = 12,
                        [113055] = 5,
                    }
                }
            },
        });
        FileClient fileClient = new();
        ClientResult<OpenAIFileInfo> uploadResult
            = await fileClient.UploadFileAsync(contrivedDocumentBody, "test-rag-file-delete-me.json", OpenAIFilePurpose.Assistants);
        OpenAIFileInfo uploadedFile = uploadResult.Value;

        // Now, we'll create a client intended to help with that data
        AssistantClient client = new();
        ClientResult<Assistant> newAssistantResult = await client.CreateAssistantAsync("gpt-4-1106-preview", new AssistantCreationOptions()
        {
            Name = "Example: Contoso sales RAG",
            Instructions = "You are an assistant that looks up sales data and helps visualize the information based on user queries."
                + " When asked to generate a graph, chart, or other visualization, use the code interpreter tool to do so.",
            FileIds = { uploadedFile.Id },
            Tools =
            {
                new RetrievalToolDefinition(),
                new CodeInterpreterToolDefinition(),
            },
            Metadata = { ["test_key_delete_me"] = "true" },
        });
        Assistant assistant = newAssistantResult.Value;

        // Now we'll create a thread with a user query about the data already associated with the assistant, then run it
        ClientResult<ThreadRun> runResult = await client.CreateThreadAndRunAsync(
            assistant.Id,
            new ThreadCreationOptions()
            {
                Messages =
                {
                    new ThreadInitializationMessage(MessageRole.User, "How well did product 113045 sell in Februrary? Graph its trend over time."),
                }
            });
        ThreadRun threadRun = runResult.Value;

        // Check back to see when the run is done
        do
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            ClientResult<ThreadRun> runPollResult = await client.GetRunAsync(threadRun.ThreadId, threadRun.Id);
            threadRun = runPollResult.Value;
        } while (threadRun.Status == RunStatus.Queued || threadRun.Status == RunStatus.InProgress);

        // Finally, we'll print out the full history for the thread that includes the augmented generation
        ClientResult<ListQueryPage<ThreadMessage>> messageListResult = await client.GetMessagesAsync(threadRun.ThreadId);
        ListQueryPage<ThreadMessage> messages = messageListResult.Value;

        for (int i = messages.Count - 1; i >= 0; i--)
        {
            ThreadMessage message = messages[i];
            Console.WriteLine($"Message {message.Id} ({message.Role}):");
            foreach (MessageContent contentItem in message.ContentItems)
            {
                if (contentItem is MessageTextContent textContent)
                {
                    Console.WriteLine($"   {textContent.Text}");
                    foreach (TextContentAnnotation annotation in textContent.Annotations)
                    {
                        if (annotation is TextContentFilePathAnnotation fileAnnotation)
                        {
                            Console.WriteLine($"      File annotation, created ID: {fileAnnotation.FileId}");
                        }
                        else if (annotation is TextContentFilePathAnnotation pathAnnotation)
                        {
                            Console.WriteLine($"      File path annotation, created ID: {pathAnnotation.FileId}");
                        }
                    }
                }
                else if (contentItem is MessageImageFileContent imageFileContentItem)
                {
                    string imageFileId = imageFileContentItem.FileId;
                    Console.WriteLine($"   <<Image File Content>> fileId: {imageFileId}");
                    ClientResult<OpenAIFileInfo> imageFileInfoResult = await fileClient.GetFileInfoAsync(imageFileId);
                    ClientResult<BinaryData> imageFileDownloadResult = await fileClient.DownloadFileAsync(imageFileId);
                    FileInfo imageFileInfo = new($"{imageFileInfoResult.Value.Filename}.png");
                    using FileStream outputStream = imageFileInfo.Create();
                    using BinaryWriter writer = new(outputStream);
                    writer.Write(imageFileDownloadResult.Value);
                    Console.WriteLine($"Wrote to file: {new Uri(imageFileInfo.FullName).AbsoluteUri}");
                }
            }
        }
    }
}
