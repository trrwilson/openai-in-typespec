using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenAI.FineTuning;

[CodeGenModel("FineTuningJobHyperparameters")]
public partial struct FineTuningJobHyperparameters
{
    // constructor with two arguments
    public FineTuningJobHyperparameters(BinaryData nEpochs, IDictionary<string, BinaryData> serializedAdditionalRawData = null)
    {
        NEpochs = nEpochs;
        SerializedAdditionalRawData = serializedAdditionalRawData ?? new Dictionary<string, BinaryData>();
    }

    // constructor with just nEpochs
    public FineTuningJobHyperparameters(BinaryData nEpochs)
    {
        NEpochs = nEpochs;
    }

    // open draft PR to get feedback
    // re-add hyperparameters
    [CodeGenMember("n_epochs")]
    public BinaryData NEpochs { get; }

    [CodeGenMember("batch_size")]
    public BinaryData BatchSize { get; }

    [CodeGenMember("learning_rate_multiplier")]
    public BinaryData LearningRateMultipler { get; }

    public IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }
}