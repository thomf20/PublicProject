using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PublicProject.Models;
using System.Diagnostics.Metrics;

namespace PublicProject.Pages
{
    public class ViewBlogModel : PageModel
    {
        private readonly Data.ApplicationDbContext dbContext; // Byt ut "YourDbContext" med namnet på din databaskontext




        public Blog BlogPost { get; set; }

        public ViewBlogModel(Data.ApplicationDbContext dbContext) // Byt ut "YourDbContext" med namnet på din databaskontext
        {
            this.dbContext = dbContext;
        }



        public IActionResult OnGet(int id)
        {

            BlogPost.Popularity =+ BlogPost.Popularity;



            BlogPost = dbContext.Blog.Find(id);

            BlogPost.Popularity++;

            if (BlogPost == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
