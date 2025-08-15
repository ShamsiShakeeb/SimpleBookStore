using Newtonsoft.Json;

namespace SimpleBookStore.Model.Report
{
    public class CommentCountByUserReport
    {
        [JsonProperty(nameof(UID))]
        public string UID { get; set; }
        [JsonProperty(nameof(UserName))]
        public string UserName { get; set; }
        [JsonProperty(nameof(Email))]
        public string Email { get; set; }
        [JsonProperty(nameof(Gender))]
        public string Gender { get; set; }
        [JsonProperty(nameof(CommentCount))]
        public int CommentCount { get; set; }
    }
}
