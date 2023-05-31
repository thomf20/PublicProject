using Microsoft.EntityFrameworkCore;
using PublicProject.Data;
using PublicProject.Models;

namespace PublicProject.Services
{
    public class UtilitiesToBeScoped : Utilities
    {
        private readonly Data.ApplicationDbContext DBContext;
        public UtilitiesToBeScoped(ApplicationDbContext dbContext) : base(dbContext)
        {
            DBContext = dbContext;

            UserProfiles = DBContext.UserProfiles.ToList();
            Blogs = DBContext.Blogs.ToList();
            Categories = DBContext.Categories.ToList();
            Messages = DBContext.Messages.ToList();
            Comments = DBContext.Comments.ToList();
            SubCategories = DBContext.SubCategories.ToList();
            Reports = DBContext.Reports.ToList();

        }

        public Comment comment { get; set; }
        public Blog blog { get; set; }
        public Report report { get; set; }
        public Category category { get; set; }
        public Message message { get; set; }
        public SubCategory subCategory { get; set; }
        public UserProfile userProfile { get; set; }

        public List<Comment> Comments { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Report> Reports { get; set; }
        public List<Category> Categories { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        public List<Message> Messages { get; set; }
        public List<UserProfile> UserProfiles { get; set; }
    }
}
