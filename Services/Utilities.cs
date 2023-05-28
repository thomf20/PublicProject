using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Licenses;
using PublicProject.Data;
using PublicProject.Models;
using System.Collections.Generic;

namespace PublicProject.Services
{
    public class Utilities : IUtilities
    {
        public DateTime TodayDate { get; set; }
        public int AnyRandomNumber { get; set; }
        public string Message { get; set; }
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



        public readonly Data.ApplicationDbContext DBContext;
        
      
           
        public Utilities(Data.ApplicationDbContext dbContext)
        {
            
            DBContext = dbContext;
            
            Refresh();

        }


        public DateTime GetDate()
        {
            return TodayDate;
        }

        public int GetRandomInt()
        {
            return AnyRandomNumber;
        }

        public void Refresh()
        {
            TodayDate = DateTime.Now;
            AnyRandomNumber = Random.Shared.Next(1000, 10000);


        }

    }
}
