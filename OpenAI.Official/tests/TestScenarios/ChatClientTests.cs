using NUnit.Framework;
using OpenAI.Official.Chat;
using System;
using System.ClientModel;
using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.ClientModel.Primitives.Pipeline;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace OpenAI.Official.Tests.Chat;

public partial class ChatClientTests
{
    [Test]
    public void HelloWorldChat()
    {
        ChatClient client = new("gpt-3.5-turbo");
        Assert.That(client, Is.InstanceOf<ChatClient>());
        Result<ChatCompletion> result = client.CompleteChat("Hello, world!");
        Assert.That(result, Is.InstanceOf<Result<ChatCompletion>>());
        Assert.That(result.Value.Content, Is.InstanceOf<ChatMessageTextContent>());
        Assert.That(result.Value.Content.ToString().Length, Is.GreaterThan(0));
    }

    [Test]
    public void MultiMessageChat()
    {
        ChatClient client = new("gpt-3.5-turbo");
        Result<ChatCompletion> result = client.CompleteChat(
        [
            new ChatRequestSystemMessage("You are a helpful assistant. You always talk like a pirate."),
            new ChatRequestUserMessage("Hello, assistant! Can you help me train my parrot?"),
        ]);
        Console.WriteLine(result.GetRawResponse().Content.ToString());
        Assert.That(result.Value.Content.ToString().ToLowerInvariant(), Contains.Substring("arr"));
    }

    [Test]
    public async Task StreamingChat()
    {
        ChatClient client = new("gpt-3.5-turbo");
        StreamingResult<StreamingChatUpdate> streamingResult
            = client.CompleteChatStreaming("What are the best pizza toppings?");
        Assert.That(streamingResult, Is.InstanceOf<StreamingResult<StreamingChatUpdate>>());
        int updateCount = 0;
        await foreach (StreamingChatUpdate chatUpdate in streamingResult)
        {
            updateCount++;
        }
        Assert.That(updateCount, Is.GreaterThan(1));
    }

    [Test]
    public void AuthFailure()
    {
        ChatClient client = new("gpt-3.5-turbo", new KeyCredential("not-a-real-key"));
        Exception caughtException = null;
        try
        {
            _ = client.CompleteChat("Uh oh, this isn't going to work with that key");
        }
        catch (Exception ex)
        {
            caughtException = ex;
        }
        var messageFailedException = caughtException as MessageFailedException;
        Assert.That(messageFailedException, Is.Not.Null);
        Assert.That(messageFailedException.Status, Is.EqualTo((int)HttpStatusCode.Unauthorized));
    }
}
