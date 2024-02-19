using NUnit.Framework;
using OpenAI.Official.Models;
using System.ClientModel;
using System.Linq;
using System.Threading.Tasks;

namespace OpenAI.Official.Tests.Models;

public partial class ModelClientTests
{
    [Test]
    public async Task CanListModels()
    {
        ModelClient client = new();
        Result<ModelInfoCollection> result = await client.GetModelsAsync();
        Assert.That(result.Value, Is.Not.Null.Or.Empty);
        Assert.That(result.Value.Any(modelInfo => modelInfo.Id.ToLowerInvariant().Contains("whisper")));
    }

    [Test]
    public async Task CanRetrieveModelInfo()
    {
        ModelClient client = new();
        Result<ModelInfo> result = await client.GetModelInfoAsync("gpt-3.5-turbo");
        Assert.That(result.Value, Is.Not.Null);
        Assert.That(result.Value.OwnerOrganization.ToLowerInvariant(), Contains.Substring("openai"));
    }
}
