using AcademyHomework.Models;
using AcademyHomework.ServicesContract;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyHomework.Services
{
    public class TableService : ITableService
    {
        private IWebConfigurations webSvc;

        public TableService(IWebConfigurations webSvc)
        {
            this.webSvc = webSvc;
        }

        public async Task<bool> Upload(GitInfo gitInfo, string tableReference)
        {
            // Validation data
            var validationData = gitInfo != null
                && !string.IsNullOrEmpty(gitInfo.Username)
                && !string.IsNullOrEmpty(gitInfo.Email)
                && !string.IsNullOrEmpty(gitInfo.GitUrl)
                && !string.IsNullOrEmpty(gitInfo.GitTestProjectPath)
                && !string.IsNullOrEmpty(tableReference);
            if (!validationData) return false;

            // Connection table
            //var connStr = CloudConfigurationManager.GetSetting(this.webSvc.QueueStorageConnectionString);
            var storageAccount = CloudStorageAccount.Parse(this.webSvc.QueueStorageConnectionString);
            var tableClient = storageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference(tableReference);
            await table.CreateIfNotExistsAsync();

            // Insert data to table
            var data = new TableData(gitInfo)
            {
                PartitionKey = gitInfo.Username,
                RowKey = gitInfo.Username
            };
            var insertOperation = TableOperation.Insert(data);
            await table.ExecuteAsync(insertOperation);

            return true;
        }

    }

    public class TableData : TableEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string GitUrl { get; set; }
        public string GitTestProjectPath { get; set; }

        public TableData(GitInfo info)
        {
            this.Username = info.Username;
            this.Email = info.Email;
            this.GitUrl = info.GitUrl;
            this.GitTestProjectPath = info.GitTestProjectPath;
        }
    }
}
