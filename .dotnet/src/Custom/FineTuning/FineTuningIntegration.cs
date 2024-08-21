using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAI.FineTuning;

[CodeGenModel("CreateFineTuningJobRequestIntegration")]
public partial class FineTuningIntegration
{
    public static FineTuningIntegration CreateWeightsAndBiasesIntegration(
        string projectName,
        string displayName = null,
        string entityName = null,
        IEnumerable<string> tags = null)
    {
        return new WeightsAndBiasesIntegration("wandb", serializedAdditionalRawData: null, projectName, displayName, entityName, tags.ToList());
    }
}