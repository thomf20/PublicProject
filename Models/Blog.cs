using System.ComponentModel.DataAnnotations.Schema;

namespace PublicProject.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public int? Popularity { get; set; } 
        public string? Footer { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? YouTube { get; set; }
        public string? Twitter { get; set; }
        public int Style { get; set; }
    }



    //public class SocialMedia
    //{
    //   

    //}
}
