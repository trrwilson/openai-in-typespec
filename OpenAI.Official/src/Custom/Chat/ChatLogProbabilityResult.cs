namespace OpenAI.Official.Chat;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.Xml.Serialization;

public class ChatLogProbabilityResult
{
    public string Token { get; }
    public double LogProbability { get; }
    public IReadOnlyList<long> Utf8ByteValues { get; }
    public IReadOnlyList<ChatLogProbabilityResultItem> AlternateLogProbabilities { get; }
    protected ChatLogProbabilityResult() { }
    internal ChatLogProbabilityResult(
        string token,
        double logProbability,
        IEnumerable<long> byteValues,
        IEnumerable<ChatLogProbabilityResultItem> alternateLogProbabilities)
        {
            Token = token;
            LogProbability = logProbability;
            Utf8ByteValues = byteValues.ToList();
            AlternateLogProbabilities = alternateLogProbabilities.ToList();
        }
}

