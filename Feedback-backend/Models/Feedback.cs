using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Feedback_backend.Models
{
    public class FeedbackDTO
    {
        [JsonProperty("FeedbackVerbatim")]
        public string FeedbackVerbatim { get; set; } = string.Empty;

        [JsonProperty("Rating")]
        [Required]
        public int Rating { get; set; }

        [JsonProperty("IsPositive")]
        [Required]
        public bool IsPositive { get; set; }

        [JsonProperty("SessionID")]
        [Required]
        public string SessionID { get; set; }

        [JsonProperty("ChatID")]
        [Required]
        public string ChatID { get; set; }

        [JsonProperty("ClientState")]
        public ClientState? ClientState { get; set; }
    }

    public class ClientState
    {
        [JsonProperty("OS")]
        public string OS { get; set; }

        [JsonProperty("Browser")]
        public string Browser { get; set; }

        [JsonProperty("ScreenResolution")]
        public string ScreenResolution { get; set; }
    }
}
