using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PublicProject.Models;

namespace PublicProject.Pages
{
    public class NewSubcategoriesModel : PageModel
    {

        private readonly Data.ApplicationDbContext DBContext; // Byt ut "YourDbContext" med namnet på din databaskontext
        public Models.SubCategory Subcategory { get; set; }
        public List< Models.Blog> Blogs { get; set; }


        public NewSubcategoriesModel(Data.ApplicationDbContext dbContext) // Byt ut "YourDbContext" med namnet på din databaskontext
        {
            DBContext = dbContext;
        }


        public IActionResult OnGet(int id)
        {

            Blogs = DBContext.Blogs.ToList();
            Subcategory = DBContext.SubCategories.Find(id);


            DBContext.SaveChanges();
            return Page();

        }
    }
}
