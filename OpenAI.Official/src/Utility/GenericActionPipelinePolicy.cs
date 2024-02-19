using System;
using System.ClientModel.Primitives;
using System.ClientModel.Primitives.Pipeline;
using System.Threading.Tasks;

namespace OpenAI.Official;

internal partial class GenericActionPipelinePolicy : IPipelinePolicy<PipelineMessage>
{
    private Action<PipelineMessage> _processMessageAction;

    public GenericActionPipelinePolicy(Action<PipelineMessage> processMessageAction)
    {
        _processMessageAction = processMessageAction;
    }

    public void Process(PipelineMessage message, IPipelineEnumerator pipeline)
    {
        _processMessageAction(message);
        _ = pipeline.ProcessNext();
    }

    public async ValueTask ProcessAsync(PipelineMessage message, IPipelineEnumerator pipeline)
    {
        _processMessageAction(message);
        _ = await pipeline.ProcessNextAsync();
    }
}