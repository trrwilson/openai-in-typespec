using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI.Official.Chat;

public partial class ChatCompletionOptions
{
    /// <inheritdoc cref="Internal.CreateChatCompletionRequest.FrequencyPenalty" />
    public double? FrequencyPenalty { get; set; }
    /// <inheritdoc cref="Internal.CreateChatCompletionRequest.LogitBias" />
    public IDictionary<long, long> TokenSelectionBiases { get; set; }
    /// <inheritdoc cref="Internal.CreateChatCompletionRequest.Logprobs" />
    public bool? IncludeLogProbabilities { get; set; }
    /// <inheritdoc cref="Internal.CreateChatCompletionRequest.TopLogprobs" />
    public long? LogProbabilityCount { get; set; }
    /// <inheritdoc cref="Internal.CreateChatCompletionRequest.MaxTokens" />
    public long? MaxTokens { get; set; }
    /// <inheritdoc cref="Internal.CreateChatCompletionRequest.PresencePenalty" />
    public double? PresencePenalty { get; set; }
    /// <inheritdoc cref="Internal.CreateChatCompletionRequest.ResponseFormat" />
    public ChatResponseFormat ResponseFormat { get; set; }
    /// <inheritdoc cref="Internal.CreateChatCompletionRequest.Seed" />
    public long? Seed { get; set; }
    /// <inheritdoc cref="Internal.CreateChatCompletionRequest.Stop" />
    public List<string> StopSequences { get; set; }
    /// <inheritdoc cref="Internal.CreateChatCompletionRequest.Temperature" />
    public double? Temperature { get; set; }
    /// <inheritdoc cref="Internal.CreateChatCompletionRequest.TopP" />
    public double? NucleusSamplingFactor { get; set; }
    /// <inheritdoc cref="Internal.CreateChatCompletionRequest.Tools" />
    public IList<ChatToolDefinition> Tools { get; }
    /// <inheritdoc cref="Internal.CreateChatCompletionRequest.ToolChoice" />
    public ChatToolConstraint? ToolConstraint { get; set; }
    /// <inheritdoc cref="Internal.CreateChatCompletionRequest.User" />
    public string User { get; set; }
    /// <inheritdoc cref="Internal.CreateChatCompletionRequest.Functions" />
    public IList<ChatFunctionDefinition> Functions { get; }
    /// <inheritdoc cref="Internal.CreateChatCompletionRequest.FunctionCall" />
    public ChatFunctionConstraint? FunctionConstraint { get; set; }

    internal BinaryData GetInternalStopSequences()
    {
        if (StopSequences == null || StopSequences.Count == 0)
        {
            return null;
        }
        return BinaryData.FromObjectAsJson(StopSequences);
    }

    internal IDictionary<string, long> GetInternalLogitBias()
    {
        if (TokenSelectionBiases == null)
        {
            return null;
        }
        Dictionary<string, long> packedLogitBias = new();
        foreach (KeyValuePair<long, long> pair in TokenSelectionBiases)
        {
            packedLogitBias[$"{pair.Key}"] = pair.Value;
        }
        return packedLogitBias;
    }

    internal Internal.CreateChatCompletionRequestResponseFormat GetInternalFormat()
    {
        string formatValue = ResponseFormat.ToString();
        if (string.IsNullOrEmpty(formatValue))
        {
            return null;
        }
        Internal.CreateChatCompletionRequestResponseFormatType internalFormatType = formatValue;
        Internal.CreateChatCompletionRequestResponseFormat internalFormat = new(
            internalFormatType,
            serializedAdditionalRawData: null);
        return internalFormat;
    }

    internal IList<Internal.ChatCompletionTool> GetInternalTools()
    {
        if (Tools == null)
        {
            return null;
        }
        List<Internal.ChatCompletionTool> internalTools = [];
        foreach (ChatToolDefinition tool in Tools)
        {
            if (tool is ChatFunctionToolDefinition functionTool)
            {
                Internal.FunctionObject functionObject = new(
                    functionTool.Description,
                    functionTool.Name,
                    CreateInternalFunctionParameters(functionTool.Parameters),
                    serializedAdditionalRawData: null);
                internalTools.Add(new(functionObject));
            }
        }
        return internalTools;
    }

    internal IList<Internal.ChatCompletionFunctions> GetInternalFunctions()
    {
        List<Internal.ChatCompletionFunctions> internalFunctions = [];
        foreach (ChatFunctionDefinition function in Functions)
        {
            Internal.ChatCompletionFunctions internalFunction = new(
                function.Description,
                function.Name,
                CreateInternalFunctionParameters(function.Parameters),
                serializedAdditionalRawData: null);
            internalFunctions.Add(internalFunction);
        }
        return internalFunctions;
    }

    internal static Internal.FunctionParameters CreateInternalFunctionParameters(BinaryData parameters)
    {
        JsonElement parametersElement = JsonDocument.Parse(parameters.ToString()).RootElement;
        Internal.FunctionParameters internalParameters = new();
        foreach (JsonProperty property in parametersElement.EnumerateObject())
        {
            BinaryData propertyData = BinaryData.FromString(property.Value.GetRawText());
            internalParameters.AdditionalProperties.Add(property.Name, propertyData);
        }
        return internalParameters;
    }
}