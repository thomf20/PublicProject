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
        public List<Models.Category> Categories { get; set; }
        public List<Models.SubCategory> Subcategories { get; set; }
        public List<Models.Blog> Blogs { get; set; }
        [BindProperty(SupportsGet =true)]
        public int SubCategoryId { get; set; }

        public ViewBlogModel(Data.ApplicationDbContext dbContext)
        {
            DBContext = dbContext;
        }
        public IActionResult OnGet()
        {


            Blogs = DBContext.Blogs.ToList();
            Subcategories = DBContext.SubCategories.ToList();
            Categories = DBContext.Categories.ToList();

            var x = SubCategoryId;

            return Page();
        }
    }
}
