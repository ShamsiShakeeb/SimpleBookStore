namespace SimpleBookStore.Model.Response
{
    public class BookResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishedDate { get; set; }
        public int Stock { get; set; }
    }
}
