using NUnit.Framework;
using OpenAI.Official.Files;
using System;
using System.ClientModel;

namespace OpenAI.Official.Tests.Files;

public partial class FileClientTests
{
    [Test]
    public void ListFilesWorks()
    {
        FileClient client = new();
        Result<OpenAIFileInfoCollection> result = client.GetFileInfoItems();
        Assert.That(result.Value.Count, Is.GreaterThan(0));
        Console.WriteLine(result.Value.Count);
        Result<OpenAIFileInfoCollection> assistantsResult = client.GetFileInfoItems(OpenAIFilePurpose.Assistants);
        Assert.That(assistantsResult.Value.Count, Is.GreaterThan(0));
        Assert.That(assistantsResult.Value.Count, Is.LessThan(result.Value.Count));
        Console.WriteLine(assistantsResult.Value.Count);
    }

    [Test]
    public void UploadFileWorks()
    {
        FileClient client = new();
        BinaryData uploadData = BinaryData.FromString("hello, this is a text file, please delete me");
    }
}