using NUnit.Framework;
using OpenAI.Assistants;
using System;

namespace OpenAI.Tests.Examples;

public partial class AssistantExamples
{
    [Test]
    [Ignore("Compilation validation only")]
    public void ListAllAssistants()
    {
        AssistantClient client = new();
        string latestId = null;
        bool continueQuery = true;
        int count = 0;

        while (continueQuery)
        {
            var assistantList = client.GetAssistants(previousAssistantId: latestId).Value;
            foreach (Assistant assistant in assistantList)
            {
                Console.WriteLine($"[{count,3}] {assistant.Id} {assistant.CreatedAt:s} {assistant.Name}");
                latestId = assistant.Id;
                count++;
            }
            continueQuery = assistantList.HasMore;
        }
    }

}
