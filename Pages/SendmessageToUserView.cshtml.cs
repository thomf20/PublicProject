using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PublicProject.Models;
using PublicProject.Services;

namespace PublicProject.Pages
{
    public class SendmessageToUserViewModel : PageModel
    {
        public readonly UtilitiesToBeScoped ScopedData;
        public SendmessageToUserViewModel(UtilitiesToBeScoped utilitiesToBeScoped)
        {
            ScopedData = utilitiesToBeScoped;
        }
        public string userid { get; set; }

        [BindProperty]
        public Message Message { get; set; } = default!;

        [BindProperty]
        public Report Report { get; set; } = default!;
        public IActionResult OnGet(string id)
        {
          
            userid = id;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
           

            ScopedData.DBContext.Messages.Add(Message);
            await ScopedData.DBContext.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
