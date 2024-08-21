using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenAI.FineTuning;

[CodeGenModel("FineTuningJob")]
public partial class FineTuningJob
{
    [CodeGenMember("EstimatedFinish")]
    public DateTimeOffset? EstimatedFinishAt { get; }

    [CodeGenMember("ValidationFile")]
    public string ValidationFileId { get; }

    [CodeGenMember("TrainingFile")]
    public string TrainingFileId { get; }

    [CodeGenMember("ResultFiles")]
    public IReadOnlyList<string> ResultFileIds { get; }

    [CodeGenMember("Status")]
    public FineTuningJobStatus Status { get; }

    [CodeGenMember("Object")]
    private string _object { get; }

    [CodeGenMember("Hyperparameters")]
    public FineTuningJobHyperparameters Hyperparameters { get; set; } = default;

    [CodeGenMember("Integrations")]
    public IReadOnlyList<FineTuningIntegration> Integrations { get; }

    public string GetPlaygroundURL() {
        return $"https://platform.openai.com/playground/chat?models={Model}&models={FineTunedModel}";
    }
}