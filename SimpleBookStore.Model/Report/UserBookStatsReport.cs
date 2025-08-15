using Newtonsoft.Json;

namespace SimpleBookStore.Model.Report
{
    public class UserBookStatsReport
    {
        [JsonProperty(nameof(UserId))]
        public string UserId { get; set; }
        [JsonProperty(nameof(UserName))]
        public string UserName { get; set; }
        [JsonProperty(nameof(Email))]
        public string Email { get; set; }
        [JsonProperty(nameof(Age))]
        public int Age { get; set; }
        [JsonProperty(nameof(Gender))]
        public string Gender { get; set; }
        [JsonProperty(nameof(BookBuyCount))]
        public int BookBuyCount { get; set; }
    }
}
