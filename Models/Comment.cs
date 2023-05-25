namespace PublicProject.Models
{

        public class Comment
        {
            public int Id { get; set; }
            public string Author { get; set; }
            public string Text { get; set; }
            public DateTime Date { get; set; }
            public int BlogId { get; set; }
            public string? UserId { get; set; }
        }
}