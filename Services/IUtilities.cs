using PublicProject.Data;
using PublicProject.Models;

namespace PublicProject.Services
{
    public interface IUtilities
    {
        
        int AnyRandomNumber { get; set; }
        string Message { get; set; }
        DateTime TodayDate { get; set; }
        //public Comment comment { get; set; }
        //public Blog blog { get; set; }
        //public Report report { get; set; }
        //public Category category { get; set; }
        //public Message message { get; set; }
        //public SubCategory subCategory { get; set; }
        //public UserProfile userProfile { get; set; }

        //public List<Comment> Comments { get; set; }
        //public List<Blog> Blogs { get; set; }
        //public List<Report> Reports { get; set; }
        //public List<Category> Categories { get; set; }
        //public List<SubCategory> SubCategories { get; set; }
        //public List<Message> Messages { get; set; }
        //public List<UserProfile> UserProfiles { get; set; }


        DateTime GetDate();
        int GetRandomInt();
        void Refresh();
    }
}