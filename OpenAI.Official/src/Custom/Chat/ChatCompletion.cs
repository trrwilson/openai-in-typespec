namespace OpenAI.Official.Chat;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.Xml.Serialization;

/// <inheritdoc cref="Internal.CreateChatCompletionResponse"/>
public class ChatCompletion
{
    private Internal.CreateChatCompletionResponse _internalResponse;
    private long _internalChoiceIndex;

    /// <inheritdoc cref="Internal.CreateChatCompletionResponse.Id"/>
    public string Id => _internalResponse.Id;
    /// <inheritdoc cref="Internal.CreateChatCompletionResponse.SystemFingerprint"/>
    public string SystemFingerprint => _internalResponse.SystemFingerprint;
    /// <inheritdoc cref="Internal.CreateChatCompletionResponse.Created"/>
    public DateTimeOffset Created => _internalResponse.Created;
    /// <inheritdoc cref="Internal.CreateChatCompletionResponse.Usage"/>
    public ChatTokenUsage Usage { get; set; }
    /// <inheritdoc cref="Internal.CreateChatCompletionResponseChoice.FinishReason"/>
    public ChatFinishReason FinishReason { get; set; }
    /// <inheritdoc cref="Internal.ChatCompletionResponseMessage.Content"/>
    public ChatMessageContent Content { get; set; }
    /// <inheritdoc cref="Internal.ChatCompletionResponseMessage.ToolCalls"/>
    public IReadOnlyList<ChatToolCall> ToolCalls { get; }
    /// <inheritdoc cref="Internal.ChatCompletionResponseMessage.FunctionCall"/>
    public ChatFunctionCall FunctionCall { get; }
    /// <inheritdoc cref="Internal.ChatCompletionResponseMessage.Role"/>
    public ChatRole Role { get; set; }
    /// <inheritdoc cref="Internal.CreateChatCompletionResponseChoice.Logprobs"/>
    public ChatLogProbabilityCollection LogProbabilities { get; }
    /// <inheritdoc cref="Internal.CreateChatCompletionResponseChoice.Index"/>
    public long Index => _internalResponse.Choices[(int)_internalChoiceIndex].Index;

    internal ChatCompletion(Internal.CreateChatCompletionResponse internalResponse, long internalChoiceIndex)
    {
        Internal.CreateChatCompletionResponseChoice internalChoice = internalResponse.Choices[(int)internalChoiceIndex];
        _internalResponse = internalResponse;
        _internalChoiceIndex = internalChoiceIndex;
        Role = internalChoice.Message.Role.ToString();
        Usage = new(_internalResponse.Usage);
        FinishReason = internalChoice.FinishReason.ToString();
        Content = internalChoice.Message.Content;
        if (internalChoice.Message.ToolCalls != null)
        {
            List<ChatToolCall> toolCalls = [];
            foreach (Internal.ChatCompletionMessageToolCall internalToolCall in internalChoice.Message.ToolCalls)
            {
                if (internalToolCall.Type == "function")
                {
                    toolCalls.Add(new ChatFunctionToolCall(internalToolCall.Id, internalToolCall.Function.Name, internalToolCall.Function.Arguments));
                }
            }
        }
        if (internalChoice.Message.FunctionCall != null)
        {
            FunctionCall = new(internalChoice.Message.FunctionCall.Name, internalChoice.Message.FunctionCall.Arguments);
        }
        if (internalChoice.Logprobs != null)
        {
            LogProbabilities = ChatLogProbabilityCollection.FromInternalData(internalChoice.Logprobs);
        }
    }
}
