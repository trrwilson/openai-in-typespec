using NUnit.Framework;
using OpenAI.Audio;
using System;
using System.ClientModel;
using System.IO;
using static OpenAI.Tests.TestHelpers;

namespace OpenAI.Tests.Audio;

public partial class TranscriptionTests
{
    [Test]
    public void BasicTranscriptionWorks()
    {
        AudioClient client = GetTestClient();
        using FileStream inputStream = File.OpenRead(Path.Combine("data", "hello_world.m4a"));
        BinaryData inputData = BinaryData.FromStream(inputStream);
        ClientResult<AudioTranscription> transcriptionResult = client.TranscribeAudio(inputData, "hello_world.m4a");
        Assert.That(transcriptionResult.Value, Is.Not.Null);
        Assert.That(transcriptionResult.Value.Text.ToLowerInvariant(), Contains.Substring("hello"));
    }

    private static AudioClient GetTestClient() => GetTestClient<AudioClient>(TestScenario.Transcription);
}
