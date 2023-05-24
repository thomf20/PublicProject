using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PublicProject.Models;

namespace PublicProject.Pages
{
    public class CreateBlogModel : PageModel
    {
        private readonly Data.ApplicationDbContext DBContext; // Byt ut "YourDbContext" med namnet på din databaskontext
        
        public Models.Category Category { get; set; }
        public List<Models.SubCategory> Subcategories { get; set; }
        
        public List<Models.Blog> Blogs { get; set; }
        [BindProperty]
        public Blog Blog { get; set; } = default!;


        public CreateBlogModel(Data.ApplicationDbContext dbContext) // Byt ut "YourDbContext" med namnet på din databaskontext
        {
            DBContext = dbContext;
        }


        public IActionResult OnGet(int id)
        {

            Blogs = DBContext.Blogs.ToList();
            Subcategories = DBContext.SubCategories.ToList();
            Category = DBContext.Categories.Find(id);


            DBContext.SaveChanges();
            return Page();

        }

    }
}
