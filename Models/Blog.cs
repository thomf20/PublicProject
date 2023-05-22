namespace PublicProject.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string? Image { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public int? Popularity { get; set; }
        public int SubcategoryId { get; set; }

    }
}
