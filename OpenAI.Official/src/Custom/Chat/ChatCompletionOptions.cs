using OpenAI.ClientShared.Internal;
using System;
using System.ClientModel.Internal;

using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Chat;

/// <summary>
/// Request-level options for chat completion.
/// </summary>
public partial class ChatCompletionOptions
{
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.FrequencyPenalty" />
    public double? FrequencyPenalty { get; set; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.LogitBias" />
    public IDictionary<long, long> TokenSelectionBiases { get; set; } = new OptionalDictionary<long, long>();
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.Logprobs" />
    public bool? IncludeLogProbabilities { get; set; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.TopLogprobs" />
    public long? LogProbabilityCount { get; set; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.MaxTokens" />
    public long? MaxTokens { get; set; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.PresencePenalty" />
    public double? PresencePenalty { get; set; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.ResponseFormat" />
    public ChatResponseFormat? ResponseFormat { get; set; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.Seed" />
    public long? Seed { get; set; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.Stop" />
    public IList<string> StopSequences { get; } = new OptionalList<string>();
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.Temperature" />
    public double? Temperature { get; set; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.TopP" />
    public double? NucleusSamplingFactor { get; set; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.Tools" />
    public IList<ChatToolDefinition> Tools { get; init; } = new OptionalList<ChatToolDefinition>();
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.ToolChoice" />
    public ChatToolConstraint? ToolConstraint { get; set; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.User" />
    public string User { get; set; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.Functions" />
    public IList<ChatFunctionDefinition> Functions { get; } = new OptionalList<ChatFunctionDefinition>();
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.FunctionCall" />
    public ChatFunctionConstraint? FunctionConstraint { get; set; }

    internal BinaryData GetInternalStopSequences()
    {
        if (!OptionalProperty.IsCollectionDefined(StopSequences))
        {
            return null;
        }
        return BinaryData.FromObjectAsJson(StopSequences);
    }

    internal IDictionary<string, long> GetInternalLogitBias()
    {
        OptionalDictionary<string, long> packedLogitBias = [];
        foreach (KeyValuePair<long, long> pair in TokenSelectionBiases)
        {
            packedLogitBias[$"{pair.Key}"] = pair.Value;
        }
        return packedLogitBias;
    }

    internal IList<Internal.Models.ChatCompletionTool> GetInternalTools()
    {
        OptionalList<Internal.Models.ChatCompletionTool> internalTools = [];
        foreach (ChatToolDefinition tool in Tools)
        {
            if (tool is ChatFunctionToolDefinition functionTool)
            {
                Internal.Models.FunctionObject functionObject = new(
                    functionTool.Description,
                    functionTool.Name,
                    CreateInternalFunctionParameters(functionTool.Parameters),
                    serializedAdditionalRawData: null);
                internalTools.Add(new(functionObject));
            }
        }
        return internalTools;
    }

    internal IList<Internal.Models.ChatCompletionFunctions> GetInternalFunctions()
    {
        OptionalList<Internal.Models.ChatCompletionFunctions> internalFunctions = [];
        foreach (ChatFunctionDefinition function in Functions)
        {
            Internal.Models.ChatCompletionFunctions internalFunction = new(
                function.Description,
                function.Name,
                CreateInternalFunctionParameters(function.Parameters),
                serializedAdditionalRawData: null);
            internalFunctions.Add(internalFunction);
        }
        return internalFunctions;
    }

    internal static Internal.Models.FunctionParameters CreateInternalFunctionParameters(BinaryData parameters)
    {
        if (parameters == null)
        {
            return null;
        }
        JsonElement parametersElement = JsonDocument.Parse(parameters.ToString()).RootElement;
        Internal.Models.FunctionParameters internalParameters = new();
        foreach (JsonProperty property in parametersElement.EnumerateObject())
        {
            BinaryData propertyData = BinaryData.FromString(property.Value.GetRawText());
            internalParameters.AdditionalProperties.Add(property.Name, propertyData);
        }
        return internalParameters;
    }
}