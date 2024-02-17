namespace OpenAI.Official.Chat;

public class ChatLogProbabilityResultItem
{
    public string Token { get; }
    public double LogProbability { get; }
    public IReadOnlyList<long> Utf8ByteValues { get; }
    protected ChatLogProbabilityResultItem() { }
    internal ChatLogProbabilityResultItem(string token, double logProbability, IEnumerable<long> byteValues)
    {
        Token = token;
        LogProbability = logProbability;
        Utf8ByteValues = new List<long>(byteValues);
    }
}