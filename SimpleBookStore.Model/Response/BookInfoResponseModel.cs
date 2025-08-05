namespace SimpleBookStore.Model.Response
{
    public class BookInfoResponseModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public string PublishDate { get; set; }
        public int Stock { get; set; }
        public int BookId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int ReviewId { get; set; }
    }
}
