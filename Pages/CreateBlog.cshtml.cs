using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PublicProject.Models;
using PublicProject.Services;

namespace PublicProject.Pages
{
    public class CreateBlogModel : PageModel
    {
        public readonly UtilitiesToBeScoped ScopedData;
        static int blogpostid;
       
        public int subcategoryid { get; set; }

        [BindProperty]
        public IFormFile UploadedImage { get; set; }

        public CreateBlogModel(UtilitiesToBeScoped utilitiesToBeScoped)
        {
            ScopedData = utilitiesToBeScoped;         
        }
        [BindProperty]
        public Blog Blog { get; set; } = default!;
        public IActionResult OnGet(int SubCategoryId)
        {

            subcategoryid = SubCategoryId;
 
            return Page();

        }
        public async Task<IActionResult> OnPostAsync(int SubCategoryId)
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
            else
            {
                fileName = "ingenbildbild.jpg";
            }
            Blog.Image = fileName;
            blogpostid = SubCategoryId;

            ScopedData.DBContext.Blogs.Add(Blog);
            await ScopedData.DBContext.SaveChangesAsync();

            return RedirectToPage("/Viewforumpost", new { id = Blog.Id });
        }


    }

}

