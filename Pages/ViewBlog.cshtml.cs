using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PublicProject.Models;
using System.Diagnostics.Metrics;

namespace PublicProject.Pages
{
    public class ViewBlogModel : PageModel
    {
        private readonly Data.ApplicationDbContext DBContext; 

        public Blog BlogPost { get; set; }

        public ViewBlogModel(Data.ApplicationDbContext dbContext) 
        {
            DBContext = dbContext;
        }


        public IActionResult OnGet(int id)
        {

            BlogPost = DBContext.Blog.Find(id);


            if( BlogPost.Popularity == null)
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
