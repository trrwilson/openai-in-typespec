namespace OpenAI.Official.Chat;

public class ChatLogProbabilityCollection : ReadOnlyCollection<ChatLogProbabilityResult>
{
    internal ChatLogProbabilityCollection(IList<ChatLogProbabilityResult> list) : base(list) { }
    internal static ChatLogProbabilityCollection FromInternalData(
        Internal.CreateChatCompletionResponseChoiceLogprobs internalLogprobs)
    {
        List<ChatLogProbabilityResult> logProbabilities = [];
        foreach (Internal.ChatCompletionTokenLogprob internalLogprob in internalLogprobs.Content)
        {
            List<ChatLogProbabilityResultItem> alternateLogProbabilities = null;
            if (internalLogprob.TopLogprobs != null)
            {
                alternateLogProbabilities = [];
                foreach (Internal.ChatCompletionTokenLogprobTopLogprob internalTopLogprob in internalLogprob.TopLogprobs)
                {
                    alternateLogProbabilities.Add(new(
                        internalLogprob.Token,
                        internalLogprob.Logprob,
                        internalLogprob.Bytes));
                }
            }
            logProbabilities.Add(new(
                internalLogprob.Token,
                internalLogprob.Logprob,
                internalLogprob.Bytes,
                alternateLogProbabilities));
        }
        return new ChatLogProbabilityCollection(logProbabilities);
    }
}