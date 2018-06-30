using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using AcademyHomework.ServicesContract;

namespace AcademyHomework.Services
{
    public class QueueService : IQueueService
    {
        IWebConfigurations webConfig;
        public QueueService(IWebConfigurations webConfig)
        {
            this.webConfig = webConfig;
        }

        public async Task<bool> EnQueue(string message, string queueReference)
        {
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(webConfig.QueueStorageConnectionString);
                CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
                CloudQueue messageQueue = queueClient.GetQueueReference(queueReference);
                CloudQueueMessage qMessage = new CloudQueueMessage(message);
                await messageQueue.AddMessageAsync(qMessage);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("เกิดข้อผิดพลาดในระหว่างดำเนิน กรุณาลองอีกครั้ง");
            }

        }  
    }
}
