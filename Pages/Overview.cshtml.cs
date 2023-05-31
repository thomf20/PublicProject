using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PublicProject.Models;
using PublicProject.Services;
using System.Security.Claims;

namespace PublicProject.Pages
{
    public class OverviewModel : PageModel
    {
        public readonly UtilitiesToBeScoped ScopedData;
        public OverviewModel(UtilitiesToBeScoped utilitiesToBeScoped)
        {
            ScopedData = utilitiesToBeScoped;
        }

        [BindProperty]
        public Models.UserProfile UserProfile { get; set; }

        [BindProperty]
        public IFormFile UploadedImage { get; set; }
        public async Task<IActionResult> OnGetAsync() 
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()  
        {
            string fileName = string.Empty;

            if (UploadedImage != null)
            {
                Random rnd = new();
                fileName = rnd.Next(0, 100000).ToString() + UploadedImage.FileName;
                var file = "./wwwroot/img/" + fileName;
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await UploadedImage.CopyToAsync(fileStream);
                }
            }

            UserProfile existingProfile = ScopedData.DBContext.UserProfiles.FirstOrDefault(p => p.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (existingProfile != null)
            {
                // Update the existing profile if found
                existingProfile.Imglink = fileName;
                existingProfile.UserName = UserProfile.UserName;
            }
            else
            {
                // Create a new profile if it doesn't exist
                UserProfile newProfile = new UserProfile
                {
                    Imglink = fileName,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    UserName = UserProfile.UserName
                };
                ScopedData.DBContext.Add(newProfile);
            }

            await ScopedData.DBContext.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
