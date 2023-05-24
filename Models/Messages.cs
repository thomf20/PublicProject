namespace PublicProject.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string SenderId { get; set; }
        public string RecieverId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
