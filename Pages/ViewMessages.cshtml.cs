using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PublicProject.Services;

namespace PublicProject.Pages
{
    public class MessagesModel : PageModel
    {


        public readonly UtilitiesToBeScoped ScopedData;

        public MessagesModel(UtilitiesToBeScoped utilitiesToBeScoped)
        {
            ScopedData = utilitiesToBeScoped;
        }




        public IActionResult OnGet(int id)
        {
            
            ScopedData.message = ScopedData.DBContext.Messages.Find(id);
      


            ScopedData.DBContext.SaveChanges();
            return Page();

        }
       
    }
}
