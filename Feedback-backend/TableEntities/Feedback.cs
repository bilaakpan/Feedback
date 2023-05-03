using Azure.Data.Tables;
using Azure;
using Newtonsoft.Json;

namespace Feedback_backend.TableEntities
{
    public class Feedback: ITableEntity
    {
        /// <summary>
        /// sessionID as PartitionKey
        /// </summary>
        public string PartitionKey { get; set; }

        /// <summary>
        /// chatID as RowKey
        /// </summary>
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
        public int Rating { get; set; }

        public string SessionID { get; set; } = string.Empty;

        public string ChatID { get; set; } = string.Empty;
        public string FeedbackVerbatim { get; set; }
        public string ClientState { get; set; }
    }
}
