using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OpenAI.Official;

public class EmbeddingCollection : ReadOnlyCollection<Embedding>
{
    internal EmbeddingCollection(IList<Embedding> list) : base(list) { }
    internal static EmbeddingCollection CreateFromInternalResponse(Internal.CreateEmbeddingResponse response)
    {
        EmbeddingTokenUsage usage = new(response.Usage);
        List<Embedding> items = [];
        for (int i = 0; i < response.Data.Count; i++)
        {
            items.Add(new(response, i, usage));
        }
        return new EmbeddingCollection(items);
    }
}