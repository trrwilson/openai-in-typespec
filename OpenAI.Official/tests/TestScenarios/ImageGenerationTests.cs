using NUnit.Framework;
using OpenAI.Official.Images;
using System;
using System.ClientModel;

namespace OpenAI.Official.Tests.Images;

public partial class ImageGenerationTests
{
    [Test]
    public void BasicGenerationWorks()
    {
        ImageClient client = new("dall-e-3");
        ClientResult<ImageGeneration> result = client.GenerateImage("an isolated stop sign");
        Assert.That(result, Is.InstanceOf<ClientResult<ImageGeneration>>());
        Assert.That(result.Value.ImageBlobUri, Is.Not.Null);
        Console.WriteLine(result.Value.ImageBlobUri.AbsoluteUri);
        Assert.That(result.Value.ImageBytes, Is.Null);
        Assert.That(result.Value.CreatedAt, Is.GreaterThan(new DateTimeOffset(new DateTime(year: 2020, month: 1, day: 1))));
    }
}
