using System;
using System.ClientModel.Internal;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OpenAI.Official.Assistants;

public abstract partial class ListQueryPage
{
    public string FirstId { get; }
    public string LastId { get; }
    public bool HasMore { get; }

    internal ListQueryPage(string firstId, string lastId, bool hasMore)
    {
        FirstId = firstId;
        LastId = lastId;
        HasMore = hasMore;
    }

    internal static ListQueryPage<Assistant> Create(Internal.ListAssistantsResponse internalResponse)
    {
        OptionalList<Assistant> assistants = new();
        foreach (Internal.AssistantObject internalAssistant in internalResponse.Data)
        {
            assistants.Add(new(internalAssistant));
        }
        return new(assistants, internalResponse.FirstId, internalResponse.LastId, internalResponse.HasMore);
    }

    internal static ListQueryPage<AssistantFileAssociation> Create(Internal.ListAssistantFilesResponse internalResponse)
    {
        OptionalList<AssistantFileAssociation> assistantFileAssociations = new();
        foreach (Internal.AssistantFileObject internalFile in internalResponse.Data)
        {
            assistantFileAssociations.Add(new(internalFile));
        }
        return new(assistantFileAssociations, internalResponse.FirstId, internalResponse.LastId, internalResponse.HasMore);
    }

    internal static ListQueryPage<ThreadMessage> Create(Internal.ListMessagesResponse internalResponse)
    {
        OptionalList<ThreadMessage> messages = new();
        foreach (Internal.MessageObject internalMessage in internalResponse.Data)
        {
            messages.Add(new(internalMessage));
        }
        return new(messages, internalResponse.FirstId, internalResponse.LastId, internalResponse.HasMore);
    }

    internal static ListQueryPage<MessageFileAssociation> Create(Internal.ListMessageFilesResponse internalResponse)
    {
        OptionalList<MessageFileAssociation> messageFileAssociations = new();
        foreach (Internal.MessageFileObject internalFile in internalResponse.Data)
        {
            messageFileAssociations.Add(new(internalFile));
        }
        return new(messageFileAssociations, internalResponse.FirstId, internalResponse.LastId, internalResponse.HasMore);
    }

    internal static ListQueryPage<ThreadRun> Create(Internal.ListRunsResponse internalResponse)
    {
        OptionalList<ThreadRun> runs = new();
        foreach (Internal.RunObject internalRun in internalResponse.Data)
        {
            runs.Add(new(internalRun));
        }
        return new(runs, internalResponse.FirstId, internalResponse.LastId, internalResponse.HasMore);
    }

    internal static ListQueryPage Create<T>(T internalResponse)
        where T : class
    {
        return internalResponse switch
        {
            Internal.ListAssistantsResponse internalAssistantsResponse => Create(internalAssistantsResponse),
            Internal.ListAssistantFilesResponse internalFilesResponse => Create(internalFilesResponse),
            Internal.ListMessagesResponse internalMessagesResponse => Create(internalMessagesResponse),
            Internal.ListMessageFilesResponse internalMessageFilesResponse => Create(internalMessageFilesResponse),
            Internal.ListRunsResponse internalRunsResponse => Create(internalRunsResponse),
            _ => throw new ArgumentException(
                $"Unknown type for generic {nameof(ListQueryPage)} conversion: {internalResponse.GetType()}"),
        };
    }
}

public partial class ListQueryPage<T> : ListQueryPage, IReadOnlyList<T>
    where T : class
{
    public IReadOnlyList<T> Items { get; }

    /// <inheritdoc/>
    public int Count => Items.Count;

    /// <inheritdoc/>
    public T this[int index]
    {
        get => Items[index];
    }

    internal ListQueryPage(IEnumerable<T> items, string firstId, string lastId, bool hasMore)
        : base(firstId, lastId, hasMore)
    {
        Items = items.ToList();
    }

    /// <inheritdoc/>
    public IEnumerator<T> GetEnumerator() => Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();
}
