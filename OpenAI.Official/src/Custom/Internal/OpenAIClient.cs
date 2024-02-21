using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace OpenAI.Internal
{
    internal partial class OpenAIClient
    {
        internal virtual Embeddings GetEmbeddingsClient()
        {
            return Volatile.Read(ref _cachedEmbeddings) ?? Interlocked.CompareExchange(ref _cachedEmbeddings, new Embeddings(_pipeline, _credential, _endpoint), null) ?? _cachedEmbeddings;
        }
    }
}
