using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PublicProject.Models;
using System.Security.Claims;

namespace PublicProject.Pages
{
    public class OverviewModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public OverviewModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Models.UserProfile> UserProfiles;

        [BindProperty]
        public Models.UserProfile UserProfile { get; set; }

        [BindProperty]
        public IFormFile UploadedImage { get; set; }
        public async Task<IActionResult> OnGetAsync()  //tar bort en blog
        {
            UserProfiles = await _context.UserProfiles.ToListAsync();
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

            UserProfile existingProfile = _context.UserProfiles.FirstOrDefault(p => p.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier));

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
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };
                _context.Add(newProfile);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
