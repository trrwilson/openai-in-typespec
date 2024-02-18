using NUnit.Framework;
using OpenAI.Official.Chat;
using OpenAI.Official.LegacyCompletions;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace OpenAI.Official.Tests.LegacyCompletions;

public partial class LegacyCompletionTests
{
    [Test]
    public void BasicValidationWorks()
    {
        LegacyCompletionClient client = new();
        BinaryData requestData = BinaryData.FromObjectAsJson(new
        {
            model = "gpt-3.5-turbo-instruct",
            prompt = "hello world",
            max_tokens = 256,
            temperature = 0,
        });
        RequestBody content = RequestBody.CreateFromStream(requestData.ToStream());
        Result result = client.GenerateLegacyCompletions(content);
        Assert.That(result, Is.Not.Null);
        JsonObject responseObject = JsonSerializer.Deserialize<JsonObject>(result.GetRawResponse().Content.ToString());
        string text = responseObject["choices"].AsArray()[0].AsObject()["text"].ToString();
        Assert.That(text, Is.Not.Null.Or.Empty);
    }
}
