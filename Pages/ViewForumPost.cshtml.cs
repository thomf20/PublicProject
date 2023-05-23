using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PublicProject.Models;

namespace PublicProject.Pages
{
    public class ViewForumPostModel : PageModel
    {

        private readonly Data.ApplicationDbContext DBContext; // Byt ut "YourDbContext" med namnet på din databaskontext

        public Blog BlogPost { get; set; }
        public Models.Category Category { get; set; }
        public List<Models.SubCategory> Subcategories { get; set; }
        public List<Models.Comment> Comments { get; set; }

        public ViewForumPostModel(Data.ApplicationDbContext dbContext) // Byt ut "YourDbContext" med namnet på din databaskontext
        {
            DBContext = dbContext;
        }
        public IActionResult OnGet(int id)
        {

            BlogPost = DBContext.Blogs.Find(id);
            Comments = DBContext.Comments.ToList();

            if (BlogPost.Popularity == null)
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
