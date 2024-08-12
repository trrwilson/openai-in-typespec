using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenAI.Files;
using OpenAI.FineTuning;
using System.ClientModel;
using System.IO;
using System.Threading.Tasks;

namespace OpenAI.Tests.FineTuning
{

    public class Expensive : ExplicitAttribute
    {
        public Expensive() : base("This finishes the job so it will cost $ on the account.") { }
    }

    [TestFixture]
    public class FineTuningClientTests
    {
        FineTuningClient client;
        FileClient fileClient;
        OpenAIFileInfo sampleFile;

        [OneTimeSetUp]
        public void Setup()
        {
            client = new FineTuningClient();
            fileClient = new FileClient();
            string path = Path.Combine("Assets", "fine_tuning_sample.jsonl");

            sampleFile = fileClient.UploadFile(path, FileUploadPurpose.FineTune);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            fileClient.DeleteFile(sampleFile.Id);
        }

        [Test]
        [Parallelizable]
        public void ExceptionThrownOnInvalidFileName()
        {
            Assert.Throws<ClientResultException>(() =>
                client.CreateJob(model: "gpt-3.5-turbo", trainingFile: "Invalid File Name")
            );
        }

        [Test]
        [Parallelizable]
        public void ExceptionThrownOnInvalidModelName()
        {
            Assert.Throws<ClientResultException>(() =>
                client.CreateJob(model: "gpt-nonexistent", trainingFile: sampleFile.Id)
            );
        }

        [Test]
        [Parallelizable]
        public void CreateAndCancelJob()
        {

            FineTuningJob job = client.CreateJob("gpt-3.5-turbo", sampleFile.Id);

            Assert.True(job.Status.InProgress());
            Assert.AreEqual(0, job.Hyperparameters.GetCycleCount());

            job = client.CancelJob(job.Id);

            Assert.AreEqual(FineTuningJobStatus.Cancelled, job.Status);
            Assert.False(job.Status.InProgress());
        }

        [Test]
        [Parallelizable]
        public void CreateAndCancelJobWithHyperparams()
        {

            var hp = new HyperparameterOptions(cycleCount: 1, batchSize: 2, learningRate: 3);

            FineTuningJob job = client.CreateJob("gpt-3.5-turbo", sampleFile.Id, hyperparameters: hp);

            Assert.AreEqual(1, job.Hyperparameters.GetCycleCount());
            Assert.AreEqual(2, job.Hyperparameters.GetBatchSize());
            Assert.AreEqual(3, job.Hyperparameters.GetLearningRateMultiplier());

            client.CancelJob(job.Id);
        }

        [Test]
        [Parallelizable]
        public async Task CreateAndCancelJobAsync()
        {
            FineTuningJob job = await client.CreateJobAsync("gpt-3.5-turbo", sampleFile.Id);
            Assert.True(job.Status.InProgress());

            job = await client.CancelJobAsync(job.Id);

            Assert.AreEqual(FineTuningJobStatus.Cancelled, job.Status);
            Assert.False(job.Status.InProgress());
        }

        [Test]
        [Parallelizable]
        [Expensive]
        public async Task TestWaitForSuccess()
        {
            // Keep number of iterations low to avoid high costs
            var hp = new HyperparameterOptions(cycleCount: 10, batchSize: 1);

            FineTuningJob job = client.CreateJob("ft:gpt-3.5-turbo-0125:personal::9rYqxSbx", sampleFile.Id, hp);

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
        public void TestSuffixAndSeed() {
            FineTuningJob job = client.CreateJob("gpt-3.5-turbo", sampleFile.Id, suffix: "TestFTJob", seed: 1234567);
            job = client.CancelJob(job.Id);
            
            Assert.AreEqual(job._user_provided_suffix, "TestFTJob");
            Assert.AreEqual(1234567, job.Seed);
        }
    }
}