using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OpenAI.Official.Chat;

/// <summary>
/// Represents an array of <c>content</c> items. Currently only used by <c>gpt-4-vision-preview</c> when supplying
/// image data to the model in chat completion requests.
/// </summary>
public class ChatMessageContentCollection : ChatMessageContent, IEnumerable<ChatMessageContent>
{
    /// <summary>
    /// The list of content items represented by this collection.
    /// </summary>
    public IReadOnlyList<ChatMessageContent> Items { get; }

    /// <summary>
    /// Creates a new instance of <see cref="ChatMessageContentCollection"/>.
    /// </summary>
    /// <param name="contentItems"> The content items contained in this collection. </param>
    public ChatMessageContentCollection(IEnumerable<ChatMessageContent> contentItems)
    {
        Items = contentItems.ToList();
    }
    
    /// <inheritdoc/>
    public IEnumerator<ChatMessageContent> GetEnumerator() => Items.GetEnumerator();

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();
}