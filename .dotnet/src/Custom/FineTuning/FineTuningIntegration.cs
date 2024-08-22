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
        WeightsAndBiasesIntegration result = new()
        {
            ProjectName = projectName,
            DisplayName = displayName,
            EntityName = entityName,
        };
        foreach (string tag in tags ?? [])
        {
            result.Tags.Add(tag);
        }
        return result;
    }
}