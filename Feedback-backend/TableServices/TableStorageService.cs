using Azure.Data.Tables;
using Feedback_backend.Controllers;
using Feedback_backend.TableEntities;

namespace Feedback_backend.TableServices
{
    public class TableStorageService : ITableStorageService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<TableStorageService> _logger;


        public TableStorageService(IConfiguration configuration, ILogger<TableStorageService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        public bool Insert(Feedback entity)
        {
            var tableClient = GetTableClient();
            _logger.LogInformation("Azure table connection made successfully");
            var response = tableClient.AddEntity<Feedback>(entity);
            if(response.IsError) 
            {
                return false;
            }
            return true;
        }

        #region
        private TableClient GetTableClient()
        {
            var serviceClient = new TableServiceClient(_configuration["AzTableConnectionString"]);
            return serviceClient.GetTableClient(_configuration["TableName"]);
        }
        #endregion
    }
}
