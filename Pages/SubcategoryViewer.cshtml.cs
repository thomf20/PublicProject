using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PublicProject.Models;

namespace PublicProject.Pages
{
    public class NewSubcategoriesModel : PageModel
    {

        private readonly Data.ApplicationDbContext DBContext;
        public Models.Category Category { get; set; }
        public List<Models.SubCategory> Subcategories { get; set; }
        public List< Models.Blog> Blogs { get; set; }


        public NewSubcategoriesModel(Data.ApplicationDbContext dbContext) 
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
