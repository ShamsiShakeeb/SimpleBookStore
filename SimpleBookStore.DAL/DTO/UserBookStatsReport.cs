namespace SimpleBookStore.DAL.DTO
{
    public class UserBookStatsReport
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int BookBuyCount { get; set; }
    }
}
