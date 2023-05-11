using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PublicProject.Models;

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
            BlogPost = dbContext.Blog.Find(id);

            if (BlogPost == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
