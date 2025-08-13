using Newtonsoft.Json;

namespace SimpleBookStore.Model.Report
{
    public class UserBookStatsReport
    {
        [JsonProperty("UserId")]
        public string UserId { get; set; }
        [JsonProperty("UserName")]
        public string UserName { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("Age")]
        public int Age { get; set; }
        [JsonProperty("Gender")]
        public string Gender { get; set; }
        [JsonProperty("BookBuyCount")]
        public int BookBuyCount { get; set; }
    }
}
