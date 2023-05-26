using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PublicProject.Models;

namespace PublicProject.Pages
{
    public class SendmessageToUserViewModel : PageModel
    {
        private readonly Data.ApplicationDbContext DBContext; // Byt ut "YourDbContext" med namnet på din databaskontext

        public UserProfile UserProfile { get; set; }
        public List<UserProfile> UserProfiles { get; set; }

        public SendmessageToUserViewModel(Data.ApplicationDbContext dbContext) // Byt ut "YourDbContext" med namnet på din databaskontext
        {
            DBContext = dbContext;
        }

        public string userid { get; set; }

        [BindProperty]
        public Message Message { get; set; } = default!;

        [BindProperty]
        public Report Report { get; set; } = default!;
        public IActionResult OnGet(string id)
        {
            UserProfiles = DBContext.UserProfiles.ToList();
            userid = id;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
           

            DBContext.Messages.Add(Message);
            await DBContext.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
