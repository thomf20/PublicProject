namespace PublicProject.Models
{

        public class Comment
        {
            public string Id { get; set; }
            public string Author { get; set; }
            public string Text { get; set; }
            public string Image { get; set; }
            public DateTime Date { get; set; }
            public int BlogId { get; set; }
            public string? UserId { get; set; }
    }
    }