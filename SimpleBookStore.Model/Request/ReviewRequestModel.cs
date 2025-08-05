using System.ComponentModel.DataAnnotations;

namespace SimpleBookStore.Model.Request
{
    public class ReviewRequestModel
    {
        public string UID { get; set; }
        public int BID { get; set; }
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow.AddHours(6);
    }
}
