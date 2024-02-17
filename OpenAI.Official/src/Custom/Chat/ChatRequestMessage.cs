using System;
using System.Collections.Generic;

namespace OpenAI.Official.Chat;

public abstract class ChatRequestMessage
{
    public ChatMessageContent Content { get; }

    protected ChatRole Role { get; set; }
    protected ChatRequestMessage(ChatRole role, ChatMessageContent content)
    {
        Role = role;
        Content = content;
    }

    internal BinaryData ToBinaryData()
    {
        dynamic data = new {};
        data.role = Role.ToString();
        if (this is ChatRequestSystemMessage systemMessage && !string.IsNullOrEmpty(systemMessage.ParticipantName))
        {
            data.name = systemMessage.ParticipantName;
        }
        if (this is ChatRequestUserMessage userMessage && !string.IsNullOrEmpty(userMessage.ParticipantName))
        {
            data.name = userMessage.ParticipantName;
        }

        if (Content is ChatMessageContentCollection contentCollection)
        {
            data.content = new List<dynamic>();
            foreach (ChatMessageContent contentItem in contentCollection)
            {
                if (contentItem is ChatMessageTextContent textContent)
                {
                    data.content.Add(new
                    {
                        type = "text",
                        text = textContent.ToString(),
                    });
                }
                else if (contentItem is ChatMessageImageUrlContent imageUrlContent)
                {
                    data.content.Add(new
                    {
                        type = "image_url",
                        image_url = new
                        {
                            url = imageUrlContent.ImageUrl,
                        }
                    });
                }
            }
        }
        else if (Content is ChatMessageTextContent textContent)
        {
            data.content = textContent.Text;
        }

        if (this is ChatRequestAssistantMessage assistantMessage)
        {
            if (assistantMessage.ToolCalls != null)
            {
                data.tool_calls = new List<dynamic>();
                foreach (ChatToolCall toolCall in assistantMessage.ToolCalls)
                {
                    if (toolCall is ChatFunctionToolCall functionToolCall)
                    {
                        data.tool_calls.Add(new
                        {
                            id = functionToolCall.Id,
                            type = "function",
                            function = new
                            {
                                name = functionToolCall.FunctionName,
                                arguments = functionToolCall.Arguments,
                            }
                        });
                    }
                }
            }
            if (assistantMessage.FunctionCall != null)
            {
                data.function_call = new
                {
                    name = assistantMessage.FunctionCall.FunctionName,
                    arguments = assistantMessage.FunctionCall.Arguments,
                };
            }
        }

        return BinaryData.FromObjectAsJson(data);
    }
}
