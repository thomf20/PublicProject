using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PublicProject.Services;

namespace PublicProject.Pages
{
    public class ShowAllMyBlogsModel : PageModel
    {
        public readonly UtilitiesToBeScoped ScopedData;
        public ShowAllMyBlogsModel(UtilitiesToBeScoped utilitiesToBeScoped)
        {
            ScopedData = utilitiesToBeScoped;
        }

        public void OnGet()
        {
        }
    }
}
