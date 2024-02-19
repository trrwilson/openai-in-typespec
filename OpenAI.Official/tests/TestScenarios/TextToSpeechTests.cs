using NUnit.Framework;
using OpenAI.Official.Audio;
using System;
using System.ClientModel;

namespace OpenAI.Official.Tests.Audio;

public partial class TextToSpeechTests
{
    [Test]
    public void BasicTTSWorks()
    {
        AudioClient client = new("tts-1");
        Result<BinaryData> result = client.GenerateSpeechFromText("hello, world, this is a test", TextToSpeechVoice.Shimmer);
        Assert.That(result.Value, Is.Not.Null);
    }

    [Test]
    [TestCase(null)]
    [TestCase(AudioDataFormat.Mp3)]
    [TestCase(AudioDataFormat.Aac)]
    [TestCase(AudioDataFormat.Opus)]
    [TestCase(AudioDataFormat.Flac)]
    public void OutputFormatWorks(AudioDataFormat? responseFormat)
    {
        AudioClient client = new("tts-1");
        TextToSpeechOptions options = new();
        if (responseFormat != null)
        {
            options.ResponseFormat = responseFormat;
        }
        Result<BinaryData> result = client.GenerateSpeechFromText("Hello, world!", TextToSpeechVoice.Alloy, options);
        Assert.That(result.Value, Is.Not.Null);
    }
}
