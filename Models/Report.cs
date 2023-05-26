namespace PublicProject.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string reporterId { get; set; }
        public string reportedId { get; set; }
        public string? Text { get; set; }
        public int CommentId { get; set; }
    }
}
