using NUnit.Framework;
using System;
using System.ClientModel.Primitives;
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
            return ModelReaderWriter.Read<FineTuningJob>(BinaryData.FromString($$"""
            {
              "object": "fine_tuning.job",
              "id": "ftjob-unitTest",
              "created_at": {{DateTimeOffset.MinValue.ToUnixTimeSeconds()}},
              "error": null,
              "fine_tuned_model": "ft:gpt-3.5-turbo-0125:personal::unitTest",
              "finished_at": {{DateTimeOffset.Now.ToUnixTimeSeconds()}},
              "hyperparameters": {},
              "model": "gpt-3.5-turbo-0125",
              "organization_id": "org-unitTest",
              "result_files": ["file-unitTest"],
              "status": "succeeded",
              "trained_tokens": 0,
              "training_file": "file-unitTest",
              "validation_file": "file-unitTest",
              "seed": 0
            }
            """));
        }
    }
}
