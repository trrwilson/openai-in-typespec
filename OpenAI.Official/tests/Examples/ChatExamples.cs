using NUnit.Framework;
using OpenAI.Official.Chat;
using System;
using System.ClientModel;
using System.Threading.Tasks;

namespace OpenAI.Official.Tests.Examples;

public partial class ChatExamples
{
    [Test]
    [Ignore("Compilation validation only")]
    public void HelloWorldChat()
    {
        ChatClient client = new("gpt-3.5-turbo");
        Result<ChatCompletion> result = client.CompleteChat("Hello, world!");
        Console.WriteLine(result.Value.Content);
    }

    [Test]
    [Ignore("Compilation validation only")]
    public async Task HelloWorldStreamingChat()
    {
        ChatClient client = new("gpt-3.5-turbo");
        StreamingResult<StreamingChatUpdate> result
            = client.CompleteChatStreaming("Hi, assistant, please introduce yourself.");
        await foreach (StreamingChatUpdate chatUpdate in result)
        {
            Console.Write(chatUpdate.ContentUpdate);
        }
    }

    [Test]
    [Ignore("Compilation validation only")]
    public void ChatWithImage(string imageUrl = "")
    {
        ChatClient client = new("gpt-4-vision-preview");
        Result<ChatCompletion> result = client.CompleteChat(
        [
            new ChatRequestUserMessage(
                "Describe this image for me",
                new ChatMessageImageUrlContent(imageUrl)),
        ]);
    }

    [Test]
    [Ignore("Compilation validation only")]
    public void ChatWithTools()
    {
        ChatClient client = new("gpt-3.5-turbo");
        ChatFunctionToolDefinition getSecretWordTool = new()
        {
            Name = "get_secret_word",
            Description = "gets the arbitrary secret word from the caller"
        };

    }

}
