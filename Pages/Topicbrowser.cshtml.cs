using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PublicProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PublicProject.Models;
using PublicProject.Services;

namespace PublicProject.Pages
{
    public class Topicbrowser  : PageModel
    {


        public readonly UtilitiesToBeScoped ScopedData;

        public Topicbrowser(UtilitiesToBeScoped utilitiesToBeScoped)
        {
            ScopedData = utilitiesToBeScoped;
        }

        
        public IActionResult OnGet()
        {

          
            return Page();

        }
    
    }
}
