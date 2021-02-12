namespace Library.Models.Queries
{
    public class BooksQuery
    {
        public string Text { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
    }
}
