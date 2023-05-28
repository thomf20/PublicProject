using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PublicProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PublicProject.Models;
namespace PublicProject.Pages
{
    public class Topicbrowser  : PageModel
    {


        
        private readonly Data.ApplicationDbContext DBContext;


        public List<Models.Category> Categories { get; set; }
        public List<Models.SubCategory> Subcategories { get; set; }
        public List<Models.Blog> Blogs { get; set; }


        public Topicbrowser(Data.ApplicationDbContext dbContext) 
        {
            DBContext = dbContext;
        }


        public IActionResult OnGet()
        {

            Blogs = DBContext.Blogs.ToList();
            Subcategories = DBContext.SubCategories.ToList();
            Categories = DBContext.Categories.ToList();


            DBContext.SaveChanges();
            return Page();

        }
    
    }
}
