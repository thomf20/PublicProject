using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PublicProject.Models;
using PublicProject.Services;
using System.Diagnostics.Metrics;

namespace PublicProject.Pages
{
    public class ViewBlogModel : PageModel
    {
        public readonly UtilitiesToBeScoped ScopedData;

        public ViewBlogModel(UtilitiesToBeScoped utilitiesToBeScoped)
        {
            ScopedData = utilitiesToBeScoped;
        }

        [BindProperty(SupportsGet =true)]
        public int SubCategoryId { get; set; }
      
        public IActionResult OnGet()
        {
            var x = SubCategoryId;

            return Page();
        }
    }
}
