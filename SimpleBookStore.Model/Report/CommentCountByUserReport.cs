namespace SimpleBookStore.Model.Report
{
    public class CommentCountByUserReport
    {
        public string UID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int CommentCount { get; set; }
    }
}
