using System;

namespace OpenAI.Official.Files;

public partial class OpenAIFileInfo
{
    public string Id { get; }
    public long Size { get; }
    public DateTimeOffset CreatedAt { get; }
    public string Filename { get; }

    internal OpenAIFileInfo(Internal.OpenAIFile internalFile)
    {
        Id = internalFile.Id;
        Size = internalFile.Bytes;
        CreatedAt = internalFile.CreatedAt;
        Filename = internalFile.Filename;
    }
}

public enum OpenAIFilePurpose
{
    FineTuning,
    FineTuningResults,
    Assistants,
    AssistantOutputs,
}