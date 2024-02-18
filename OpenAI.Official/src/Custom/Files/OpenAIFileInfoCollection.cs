using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OpenAI.Official.Files;

public partial class OpenAIFileInfoCollection : ReadOnlyCollection<OpenAIFileInfo>
{
    internal OpenAIFileInfoCollection(IList<OpenAIFileInfo> list) : base(list)
    {
    }
}