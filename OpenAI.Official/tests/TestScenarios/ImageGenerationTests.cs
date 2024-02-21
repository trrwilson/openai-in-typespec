﻿using NUnit.Framework;
using OpenAI.Images;
using System;
using System.ClientModel;

namespace OpenAI.Tests.Images;

public partial class ImageGenerationTests
{
    [Test]
    public void BasicGenerationWorks()
    {
        ImageClient client = new("dall-e-3");
        ClientResult<GeneratedImage> result = client.GenerateImage("an isolated stop sign");
        Assert.That(result, Is.InstanceOf<ClientResult<GeneratedImage>>());
        Assert.That(result.Value.ImageUri, Is.Not.Null);
        Console.WriteLine(result.Value.ImageUri.AbsoluteUri);
        Assert.That(result.Value.ImageBytes, Is.Null);
        Assert.That(result.Value.CreatedAt, Is.GreaterThan(new DateTimeOffset(new DateTime(year: 2020, month: 1, day: 1))));
    }
}
