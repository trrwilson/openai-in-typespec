using System.ClientModel;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading;

namespace OpenAI.Official;

/// <summary>
/// Client-level options for the OpenAI service.
/// </summary>
public partial class OpenAIClientOptions : RequestOptions
{
    // Note: this type currently proxies RequestOptions properties manually via the matching internal type. This is a
    //       temporary extra step pending richer integration with code generation.

    internal Internal.OpenAIClientOptions InternalOptions { get; }

    public new void AddPolicy(PipelinePolicy policy, PipelinePosition position)
    {
        InternalOptions.AddPolicy(policy, position);
    }

    public OpenAIClientOptions()
        : this(internalOptions: null)
    { }

    internal OpenAIClientOptions(Internal.OpenAIClientOptions internalOptions = null)
    {
        internalOptions ??= new();
        InternalOptions = internalOptions;
    }
}
