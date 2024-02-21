using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace OpenAI.Models;

/// <summary>
/// Represents a collection of entries for available models.
/// </summary>
public partial class ModelInfoCollection : ReadOnlyCollection<ModelInfo>
{
    internal ModelInfoCollection(IList<ModelInfo> list) : base(list)
    {}
}
