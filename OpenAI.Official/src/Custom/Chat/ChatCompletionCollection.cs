namespace OpenAI.Official.Chat;

using System.Collections.Generic;
using System.Collections.ObjectModel;

/// <summary>
/// Represents a chat completions response payload that contains information about multiple requested chat completion
/// choices.
/// </summary>
public class ChatCompletionCollection : ReadOnlyCollection<ChatCompletion>
{
    internal ChatCompletionCollection(IList<ChatCompletion> list) : base(list) { }
}