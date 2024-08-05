using TypeSpec.OpenAPI;

namespace OpenAI;

union CreateFineTuningJobRequestHyperparametersBatchSizeChoiceEnum {
  auto: "auto",
}
alias CreateFineTuningJobRequestHyperparametersBatchSize = CreateFineTuningJobRequestHyperparametersBatchSizeChoiceEnum | int32;

union CreateFineTuningJobRequestHyperparametersLearningRateMultiplierChoiceEnum {
  auto: "auto",
}
alias CreateFineTuningJobRequestHyperparametersLearningRateMultiplier = CreateFineTuningJobRequestHyperparametersLearningRateMultiplierChoiceEnum | float32;

union CreateFineTuningJobRequestHyperparametersNEpochsChoiceEnum {
  auto: "auto",
}
alias CreateFineTuningJobRequestHyperparametersNEpochs = CreateFineTuningJobRequestHyperparametersNEpochsChoiceEnum | int32;
