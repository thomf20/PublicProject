﻿namespace PublicProject.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int RecieverId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
