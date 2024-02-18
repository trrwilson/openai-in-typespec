using NUnit.Framework;
using OpenAI.Official.Audio;
using OpenAI.Official.Chat;
using OpenAI.Official.Images;
using System;
using System.ClientModel;
using System.IO;

namespace OpenAI.Official.Tests.Examples;

public partial class CombinationExamples
{
    [Test]
    [Ignore("Compilation validation")]
    public void AlpacaArtCritic()
    {
        // First, we create an image using dall-e-3:
        ImageClient imageClient = new("dall-e-3");
        Result<ImageGeneration> imageResult = imageClient.GenerateImage(
            "a majestic alpaca on a mountain ridge, backed by an expansive blue sky accented with sparse clouds",
            new()
            {
                Style = ImageStyle.Vivid,
                Quality = ImageQuality.High,
                Size = ImageSize.Size1792x1024,
            });
        string absoluteUri = imageResult.Value.ImageBlobUri.AbsoluteUri;
        Console.WriteLine($"Majestic alpaca available at:\n{absoluteUri}");

        // Now, we'll ask a cranky art critic to evaluate the image using gpt-4-vision-preview:
        ChatClient chatClient = new("gpt-4-vision-preview");
        Result<ChatCompletion> chatResult = chatClient.CompleteChat(
            [
                new ChatRequestSystemMessage("Assume the role of a cranky art critic. When asked to describe or "
                    + "evaluate imagery, focus on criticizing elements of subject, composition, and other details."),
                new ChatRequestUserMessage(
                    "describe the following image in a few sentences",
                    new ChatMessageImageUrlContent(absoluteUri)),
            ],
            new ChatCompletionOptions()
            {
                MaxTokens = 2048,
            });
        string chatResponseText = chatResult.Value.Content;
        Console.WriteLine($"Art critique of majestic alpaca:\n{chatResponseText}");

        // Finally, we'll get some text-to-speech for that critical evaluation using tts-1-hd:
        AudioClient audioClient = new("tts-1-hd");
        Result<BinaryData> ttsResult = audioClient.GenerateSpeechFromText(
            input: chatResponseText,
            TextToSpeechVoice.Fable,
            new TextToSpeechOptions()
            {
                SpeedMultiplier = 0.9f,
                ResponseFormat = AudioDataFormat.Opus,
            });
        FileInfo ttsFileInfo = new($"{chatResult.Value.Id}.opus");
        using (FileStream ttsFileStream = ttsFileInfo.Create())
        using (BinaryWriter ttsFileWriter = new(ttsFileStream))
        {
            ttsFileWriter.Write(ttsResult.Value);
        }
        Console.WriteLine($"Alpaca evaluation audio available at:\n{new Uri(ttsFileInfo.FullName).AbsoluteUri}");
    }
}
