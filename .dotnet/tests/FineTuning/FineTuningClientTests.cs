using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenAI.Files;
using OpenAI.FineTuning;
using System.ClientModel;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace OpenAI.Tests.FineTuning
{
    [TestFixture]
    public class FineTuningClientTests
    {
        FineTuningClient client;
        FileClient fileClient;
        OpenAIFileInfo sampleFile, validationFile;

        [OneTimeSetUp]
        public void Setup()
        {
            client = new FineTuningClient();
            fileClient = new FileClient();
            string samplePath = Path.Combine("Assets", "fine_tuning_sample.jsonl");
            string validationPath = Path.Combine("Assets", "fine_tuning_sample_validation.jsonl");

            sampleFile = fileClient.UploadFile(samplePath, FileUploadPurpose.FineTune);
            validationFile = fileClient.UploadFile(validationPath, FileUploadPurpose.FineTune);

        }

        [OneTimeTearDown]
        public void TearDown()
        {
            fileClient.DeleteFile(sampleFile.Id);
            fileClient.DeleteFile(validationFile.Id);
        }



        [Test]
        [Parallelizable]
        public void MinimalRequiredParams()
        {

            FineTuningJob job = client.CreateJob("gpt-3.5-turbo", sampleFile.Id);

            Assert.True(job.Status.InProgress());
            Assert.AreEqual(0, job.Hyperparameters.GetCycleCount());

            job = client.CancelJob(job.Id);

            Assert.AreEqual(FineTuningJobStatus.Cancelled, job.Status);
            Assert.False(job.Status.InProgress());
        }

        // minimal but async
        [Test]
        [Parallelizable]
        public async Task MinimalRequiredParamsAsync()
        {

            FineTuningJob job = await client.CreateJobAsync("gpt-3.5-turbo", sampleFile.Id);

            Assert.True(job.Status.InProgress());
            Assert.AreEqual(0, job.Hyperparameters.GetCycleCount());

            job = await client.CancelJobAsync(job.Id);

            Assert.AreEqual(FineTuningJobStatus.Cancelled, job.Status);
            Assert.False(job.Status.InProgress());
        }

        [Test]
        [Parallelizable]
        public void AllParameters()
        {
            // This test does not check for Integrations because it requires a valid API key

            var options = new FineTuningOptions()
            {
                Hyperparameters = new(cycleCount: 1, batchSize: 2, learningRate: 3),
                Suffix = "TestFTJob",
                ValidationFile = validationFile.Id,
                Seed = 1234567
            };

            FineTuningJob job = client.CreateJob(
                "gpt-3.5-turbo",
                sampleFile.Id,
                options
                );

            Assert.AreEqual(1, job.Hyperparameters.GetCycleCount());
            Assert.AreEqual(2, job.Hyperparameters.GetBatchSize());
            Assert.AreEqual(3, job.Hyperparameters.GetLearningRateMultiplier());
            Assert.AreEqual(job._user_provided_suffix, "TestFTJob");
            Assert.AreEqual(1234567, job.Seed);
            Assert.AreEqual(validationFile.Id, job.ValidationFileId);

            job = client.CancelJob(job.Id);
        }

        [Test]
        [Parallelizable]
        public async Task AllParametersAsync()
        {
            // This test does not check for Integrations because it requires a valid API key

            var options = new FineTuningOptions()
            {
                Hyperparameters = new(cycleCount: 1, batchSize: 2, learningRate: 3),
                Suffix = "TestFTJob",
                ValidationFile = validationFile.Id,
                Seed = 1234567
            };

            FineTuningJob job = await client.CreateJobAsync(
                "gpt-3.5-turbo",
                sampleFile.Id,
                options
            );


            Assert.AreEqual(1, job.Hyperparameters.GetCycleCount());
            Assert.AreEqual(2, job.Hyperparameters.GetBatchSize());
            Assert.AreEqual(3, job.Hyperparameters.GetLearningRateMultiplier());
            Assert.AreEqual(job._user_provided_suffix, "TestFTJob");
            Assert.AreEqual(1234567, job.Seed);
            Assert.AreEqual(validationFile.Id, job.ValidationFileId);

            job = await client.CancelJobAsync(job.Id);
        }



        [Test]
        [Parallelizable]
        [Explicit("This test is slow and costs $ because it completes the fine-tuning job.")]
        public async Task TestWaitForSuccess()
        {
            // Keep number of iterations low to avoid high costs
            var hp = new HyperparameterOptions(cycleCount: 1, batchSize: 10);

            FineTuningJob job = client.CreateJob(
                "gpt-3.5-turbo",
                sampleFile.Id,
                options: new() { Hyperparameters = hp }
            );

            job = await client.WaitUntilCompleted(job);
            // Debug logs might be similar to:
            /*
             *     Waiting for 30 seconds
             *     Waiting for 30 seconds
             *     ...
             *     Waiting for 30 seconds
             *     Waiting for 00:03:16.7177007
             */

            Assert.AreEqual(FineTuningJobStatus.Succeeded, job.Status);
        }


        [Test]
        [Parallelizable]
        [Explicit("This test requires wandb.ai account and api key integration.")]
        public void WandBIntegrations()
        {

            var integrations = new List<Integration> {
                new(new IntegrationWandB("ft-tests"))
            };

            FineTuningJob job = client.CreateJob(
                "gpt-3.5-turbo",
                sampleFile.Id,
                options: new() { Integrations = integrations }
            );
            client.CancelJob(job.Id);

        }

        [Test]
        [Parallelizable]
        public void ExceptionThrownOnInvalidFileName()
        {
            Assert.Throws<ClientResultException>(() =>
                client.CreateJob(model: "gpt-3.5-turbo", trainingFileId: "Invalid File Name")
            );
        }

        [Test]
        [Parallelizable]
        public void ExceptionThrownOnInvalidModelName()
        {
            Assert.Throws<ClientResultException>(() =>
                client.CreateJob(model: "gpt-nonexistent", trainingFileId: sampleFile.Id)
            );
        }

        [Test]
        [Parallelizable]
        public void ExceptionThrownOnInvalidValidationId()
        {

            Assert.Throws<ClientResultException>(() =>
            {
                FineTuningJob job = client.CreateJob(
                    "gpt-3.5-turbo",
                    sampleFile.Id,
                    new() { ValidationFile = "7" }
                );
            });
        }

        [Test]
        [Parallelizable]
        public void ExceptionThrownOnInvalidValidationIdAsync()
        {

            Assert.ThrowsAsync<ClientResultException>(async () =>
            {
                var job = await client.CreateJobAsync(
                    "gpt-3.5-turbo", 
                    sampleFile.Id,
                    new() { ValidationFile = "7" }
                    );
            });
        }
    }
}