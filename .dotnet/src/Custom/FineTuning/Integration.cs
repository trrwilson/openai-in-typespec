using System;
using System.Collections.Generic;
using System.Text;

namespace OpenAI.FineTuning;

[CodeGenModel("CreateFineTuningJobRequestIntegration")]
public partial class Integration
{
    public static Integration WandB(string name) => new(new IntegrationWandB(name));

}