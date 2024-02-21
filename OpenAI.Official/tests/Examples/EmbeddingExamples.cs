using NUnit.Framework;
using OpenAI.Chat;
using OpenAI.Embeddings;
using System;
using System.ClientModel;
using System.Collections.Generic;

namespace OpenAI.Tests.Examples;

public partial class EmbeddingExamples
{
    [Test]
    [Ignore("Compilation validation only")]
    public void SimpleEmbedding()
    {
        EmbeddingClient client = new("text-embedding-ada-002");
        ClientResult<Embedding> result = client.GenerateEmbedding("some text I'd like lots of floats for");
        float[] values = result.Value.Vector.ToArray();
        Console.WriteLine($"The embedding has {values.Length} values");
    }

    [Test]
    [Ignore("Compilation validation only")]
    public void ComplexEmbedding()
    {
        EmbeddingClient client = new("text-embedding-3-small");
        List<string> prompts =
        [
            "Hello, world!",
            "This is a test.",
            "Goodbye!"
        ];
        EmbeddingOptions options = new()
        {
            Dimensions = 456,
        };
        ClientResult<EmbeddingCollection> response = client.GenerateEmbeddings(prompts, options);
        for (int i = 0; i < response.Value.Count; i++)
        {
            Embedding embedding = response.Value[i];
            float[] array = embedding.Vector.ToArray();
            Console.WriteLine($"Index: {embedding.Index} has {array.Length} values");
        }
    }
}
