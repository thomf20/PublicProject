using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PublicProject.Models;
using System.Diagnostics.Metrics;

namespace PublicProject.Pages
{
    public class ViewBlogModel : PageModel
    {
        private readonly Data.ApplicationDbContext DBContext; // Byt ut "YourDbContext" med namnet på din databaskontext

        public Blog BlogPost { get; set; }
        public Models.Category Category { get; set; }
        public List<Models.SubCategory> Subcategories { get; set; }
        public List<Models.Blog> Blogs { get; set; }

        public ViewBlogModel(Data.ApplicationDbContext dbContext) // Byt ut "YourDbContext" med namnet på din databaskontext
        {
            DBContext = dbContext;
        }


        public IActionResult OnGet(int id)
        {

            BlogPost = DBContext.Blogs.Find(id);
            Blogs = DBContext.Blogs.ToList();
            Subcategories = DBContext.SubCategories.ToList();
            Category = DBContext.Categories.Find(id);



            if ( BlogPost.Popularity == null)
            {
                BlogPost.Popularity = 0;
            }

            BlogPost.Popularity++;

            if (BlogPost == null)
            {
                return NotFound();
            }

            DBContext.SaveChanges();
            return Page();
        }
    }
}
