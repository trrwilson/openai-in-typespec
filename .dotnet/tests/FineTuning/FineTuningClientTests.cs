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
		[Test]
		public void ClientDefaults()
		{
			var client = new FineTuningClient();
			Assert.IsNotNull(client);
		}

		[Test]
		public void ExceptionThrownOnInvalidFilename()
		{
			var client = new FineTuningClient();

			// Wrong filename will respond with http 400
			Assert.Throws<ClientResultException>(() =>
				client.CreateJob(training_file: "Invalid File Name", model: "gpt-3.5-turbo")
			);
        }

        [Test]
		public void CreateAndCancelJob()
		{
            var client = new FineTuningClient();

			var fileClient = new FileClient();
			string path = Path.Combine("Assets", "fine_tuning_sample.jsonl");

			OpenAIFileInfo file = fileClient.UploadFile(path, "fine-tune");

			try
			{

				Console.WriteLine("Creating job...");
				FineTuningJob job = client.CreateJob(file.Id, "gpt-3.5-turbo");	
                Assert.True(job.Status.InProgress());
				Console.WriteLine("Job created successfully! Cancelling...");
				job = client.CancelJob(job.Id);
				Assert.AreEqual(FineTuningJobStatus.Cancelled, job.Status);
                Assert.AreEqual("fine_tuning.job", job.Object);
                Assert.False(job.Status.InProgress());
			}
			finally
			{
				fileClient.DeleteFile(file.Id);
			}
		}

		[Test]
		public async Task CreateAndCancelJobAsync()
        {
            var client = new FineTuningClient();

            var fileClient = new FileClient();
            string path = Path.Combine("Assets", "fine_tuning_sample.jsonl");

            OpenAIFileInfo file = await fileClient.UploadFileAsync(path, "fine-tune");

            try
            {
                FineTuningJob job = await client.CreateJobAsync(file.Id, "gpt-3.5-turbo");
                Assert.True(job.Status.InProgress());
                job = await client.CancelJobAsync(job.Id);
                Assert.AreEqual(FineTuningJobStatus.Cancelled, job.Status);
                Assert.False(job.Status.InProgress());
            }
            finally
            {
                await fileClient.DeleteFileAsync(file.Id);
            }
        }
	}
}