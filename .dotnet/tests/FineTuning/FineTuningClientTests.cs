using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenAI.Files;
using OpenAI.FineTuning;
using System;
using System.ClientModel;
using System.IO;
using System.Threading.Tasks;

namespace OpenAI.Tests.FineTuning
{
    [TestFixture]
    public class FineTuningClientTests
    {
        FineTuningClient client;
        FileClient fileClient;
        OpenAIFileInfo sampleFile;

        [SetUp]
        public void Setup()
        {
            client = new FineTuningClient();
            fileClient = new FileClient();
            string path = Path.Combine("Assets", "fine_tuning_sample.jsonl");

            sampleFile = fileClient.UploadFile(path, "fine-tune");

        }
        [TearDown]
        public void TearDown()
        {
            fileClient.DeleteFile(sampleFile.Id);
        }

        [Test]
        public void ClientDefaults()
        {
            var client = new FineTuningClient();
            Assert.IsNotNull(client);
        }

        [Test]
        public void ExceptionThrownOnInvalidFileName()
        {
            var client = new FineTuningClient();

            // Wrong filename will respond with http 400
            Assert.Throws<ClientResultException>(() =>
                client.CreateJob(model: "gpt-3.5-turbo", trainingFile: "Invalid File Name")
            );
        }

        [Test]
        public void ExceptionThrownOnInvalidModelName()
        {
            var client = new FineTuningClient();

            Assert.Throws<ClientResultException>(() =>
            {
                string path = Path.Combine("Assets", "fine_tuning_sample.jsonl");
                client.CreateJob(model: "gpt-nonexistent", trainingFile: sampleFile.Id);
            }
            );
        }

        [Test]
        public void CreateAndCancelJob()
        {
            var client = new FineTuningClient();

            Assert.True(job.Status.InProgress());
            Assert.AreEqual(0, job.Hyperparameters.GetNEpochs());

            job = client.CancelJob(job.Id);

            Assert.AreEqual(FineTuningJobStatus.Cancelled, job.Status);
            Assert.AreEqual("fine_tuning.job", job.Object);
            Assert.False(job.Status.InProgress());
        }
        [Test]
        public void CreateAndCancelJobWithHyperparams()
        {
            var hp = new FineTuningJobHyperparameters(nEpochs: 1, batchSize: 2, learningRateMultiplier: 3);

            FineTuningJob job = client.CreateJob("gpt-3.5-turbo", sampleFile.Id, hyperparameters: hp);

            Assert.AreEqual(1, job.Hyperparameters.GetNEpochs());
            Assert.AreEqual(2, job.Hyperparameters.GetBatchSize());
            Assert.AreEqual(3, job.Hyperparameters.GetLearningRateMultiplier());

            job = client.CancelJob(job.Id);
        }

        [Test]
        public async Task CreateAndCancelJobAsync()
        {
            var hp = new FineTuningJobHyperparameters(nEpochs: 1, batchSize: 2, learningRateMultiplier: 3);

            FineTuningJob job = await client.CreateJobAsync(sampleFile.Id, "gpt-3.5-turbo");
            Assert.True(job.Status.InProgress());
            job = await client.CancelJobAsync(job.Id);
            Assert.AreEqual(FineTuningJobStatus.Cancelled, job.Status);
            Assert.False(job.Status.InProgress());
        }
    }
}