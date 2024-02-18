using System;
using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.ClientModel.Primitives.Pipeline;
using System.IO;
using System.Threading.Tasks;

namespace OpenAI.Official.Tests;

internal class TestPipelinePolicy : IPipelinePolicy<PipelineMessage>
{
    public void Process(PipelineMessage message, IPipelineEnumerator pipeline)
    {
        if (message?.Request?.Content is Utf8JsonRequestBody json)
        {
            using MemoryStream stream = new();
            json.WriteTo(stream, default);
            stream.Position = 0;
            using StreamReader reader = new(stream);
            Console.WriteLine(reader.ReadToEnd());
        }

        if (message.HasResponse)
        {
            Console.WriteLine(message.Response.Content.ToString());
        }

        // pipeline?.ProcessNext();
    }

    public ValueTask ProcessAsync(PipelineMessage message, IPipelineEnumerator pipeline)
    {
        throw new NotImplementedException();
    }
}
