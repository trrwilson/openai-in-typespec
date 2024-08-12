using NUnit.Framework;
using System;
using OpenAI.FineTuning;

namespace OpenAI.Tests.FineTuning
{
    internal class FineTuningJobTests
    {
        [Test]
        [Parallelizable]
        public void PlaygroundURL()
        {
            var job = JobStub();
            var url = job.GetPlaygroundURL();
            Assert.AreEqual("https://platform.openai.com/playground/chat?models=gpt-3.5-turbo-0125&models=ft:gpt-3.5-turbo-0125:personal::unitTest", url);
        }

        private static FineTuningJob JobStub()
        {
            return new FineTuningJob(
                            id: "ftjob-unitTest",
                            createdAt: DateTimeOffset.MinValue,
                            error: null,
                            fineTunedModel: "ft:gpt-3.5-turbo-0125:personal::unitTest",
                            finishedAt: DateTimeOffset.Now,
                            hyperparameters: new(),
                            model: "gpt-3.5-turbo-0125",
                            organizationId: "org-unitTest",
                            resultFiles: ["file-unitTest"],
                            FineTuningJobStatus.Succeeded,
                            trainedTokens: 0,
                            trainingFile: "file-unitTest",
                            validationFile: "file-unitTest",
                            seed: 0
                            );
        }
    }
}
