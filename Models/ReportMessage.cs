namespace PublicProject.Models
{
    public class ReportMessage
    {
        public int Id { get; set; }
        public string senderId { get; set; }
        public string reportedId { get; set; }
        public string? Text { get; set; }
    }
}
