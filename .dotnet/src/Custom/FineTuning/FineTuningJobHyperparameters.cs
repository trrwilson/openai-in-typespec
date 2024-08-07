using System;
using System.Collections.Generic;

namespace OpenAI.FineTuning;


[CodeGenModel("FineTuningJobHyperparameters")]
public partial struct FineTuningJobHyperparameters
{
    private static readonly BinaryData Auto = new("\"auto\"");

    [CodeGenMember("n_epochs")]
    internal BinaryData NEpochs { get; set; }

    [CodeGenMember("batch_size")]
    internal BinaryData BatchSize { get; set; }

    [CodeGenMember("learning_rate_multiplier")]
    internal BinaryData LearningRateMultipler { get; set; }

    public IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }

    public FineTuningJobHyperparameters(BinaryData nEpochs)
    {
        NEpochs = nEpochs;
    }

    public FineTuningJobHyperparameters(BinaryData nEpochs, IDictionary<string, BinaryData> serializedAdditionalRawData)
    {
        NEpochs = nEpochs;
        SerializedAdditionalRawData = serializedAdditionalRawData;

        serializedAdditionalRawData.TryGetValue("batch_size", out BinaryData batchSize);
        serializedAdditionalRawData.TryGetValue("learning_rate_multiplier", out BinaryData learningRateMultiplier);

        /*        foreach (KeyValuePair<string, BinaryData> kvp in serializedAdditionalRawData)
                {
                    if (kvp.Key == "batch_size") { BatchSize = kvp.Value; }            
                    if (kvp.Key == "learning_rate_multiplier") { LearningRateMultipler = kvp.Value; }
                }
        */
    }

    public FineTuningJobHyperparameters(int nEpochs = 0, int batchSize = 0, int learningRateMultiplier = 0)
    {
        NEpochs = nEpochs > 0 ? new BinaryData(nEpochs) : Auto;
        BatchSize = batchSize > 0 ? new BinaryData(batchSize) : Auto;
        LearningRateMultipler = learningRateMultiplier > 0 ? new BinaryData(learningRateMultiplier) : Auto;
    }

    private int HandleDefaults(BinaryData data)
    {
        if (data is null)
        {
            throw new ArgumentNullException("This hyperparameter is not set. Values for BatchSize and LearningRateMultiplier are not available in responses.");
        }

        if (data.ToString() == Auto.ToString())
        {
            return 0;
        }

        try
        {
            return int.Parse(data.ToString());
        }
        catch (FormatException)
        {
            throw new FormatException($"Hyperparameter expected a number or \"auto\" string. Got {data}");
        }
    }

    public int GetNEpochs() => HandleDefaults(NEpochs);
    public int GetBatchSize()
    {
        Console.WriteLine($"Getting batch size: {BatchSize}");
        return HandleDefaults(BatchSize);
    }

    public int GetLearningRateMultiplier() => HandleDefaults(LearningRateMultipler);


    public void SetNEpochs(int value)
    {
        NEpochs = new BinaryData(value);
    }

    public void SetNEpochsAuto()
    {
        NEpochs = Auto;
    }
    public void SetNEpochs(BinaryData value)
    {
        NEpochs = value;
    }

    public void SetBatchSize(int value)
    {
        BatchSize = new BinaryData(value);
    }
    public void SetBatchAuto()
    {
        BatchSize = Auto;
    }
    public void SetBatchSize(BinaryData value)
    {
        BatchSize = value;

    }
    public void SetLearningRateMultiplier(int value)
    {
        LearningRateMultipler = new BinaryData(value);
    }
    public void SetLearningRateMultiplierAuto()
    {
        LearningRateMultipler = Auto;
    }
    public void SetLearningRateMultiplier(BinaryData value)
    {
        LearningRateMultipler = value;
    }
}
