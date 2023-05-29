using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PublicProject.Models;
using PublicProject.Services;

namespace PublicProject.Pages
{
    public class NewSubcategoriesModel : PageModel
    {

        public readonly UtilitiesToBeScoped ScopedData;

        public NewSubcategoriesModel(UtilitiesToBeScoped utilitiesToBeScoped)
        {
            ScopedData = utilitiesToBeScoped;
        }
        

        public IActionResult OnGet(int id)
        {           

            ScopedData.category = ScopedData.DBContext.Categories.Find(id);
            ScopedData.DBContext.SaveChanges();
            return Page();

        }
    }
}
