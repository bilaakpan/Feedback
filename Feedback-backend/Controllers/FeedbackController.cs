using Feedback_backend.Models;
using Feedback_backend.TableEntities;
using Feedback_backend.TableServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Feedback_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly ITableStorageService _tableStorageService;
        private readonly ILogger<FeedbackController> _logger;
        public FeedbackController(ITableStorageService tableStorageService, ILogger<FeedbackController> logger)
        {
            _tableStorageService = tableStorageService;
            _logger = logger;
        }
        [HttpPost("/api/feedback")]
        public IActionResult PostFeedback([FromBody] FeedbackDTO feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please proivde the required values");
            }
            try
            {
                var feedbackEntity = new Feedback()
                {
                    SessionID = feedback.SessionID,
                    PartitionKey = feedback.SessionID,
                    ChatID = feedback.ChatID,
                    RowKey = feedback.ChatID,
                    FeedbackVerbatim = feedback.FeedbackVerbatim,
                    ClientState = feedback.ClientState != null ? JsonConvert.SerializeObject(feedback.ClientState) : null,
                    Rating = feedback.Rating
                };
                var isSuccess = _tableStorageService.Insert(feedbackEntity);
                if (isSuccess)
                {
                    _logger.LogInformation("record processed with status 200");
                    return Ok("Record inserted successfully!");
                }
                _logger.LogDebug("record not inserted");
                return BadRequest("Record not inserted");
            }catch(Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                return StatusCode(500,"Internal server error!");
            }
        }
    }
}
