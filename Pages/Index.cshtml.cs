using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PublicProject.Models;
using PublicProject.Services;
using System.Security.Claims;

namespace PublicProject.Pages
{
    public class IndexModel : PageModel
    {
        public readonly UtilitiesToBeScoped ScopedData;

        public IndexModel(UtilitiesToBeScoped utilitiesToBeScoped)
        {
            ScopedData = utilitiesToBeScoped;
        }
     
        [BindProperty]
        public Models.Category Category { get; set; }
        
        [BindProperty]
        public IFormFile UploadedImage { get; set; }

        public static string LimitLength(string source, int maxLength)
        {
            if (source != null)
            {
                if (source.Length <= maxLength)
                {
                    return source;
                }

                return source.Substring(0, maxLength);
            }
            return source;
        }

        public async Task<IActionResult> OnGetAsync(int deleteid)
        {
            if (deleteid != 0)
            {
                //Models.Category blog = await _context.Blog.FindAsync(deleteid);

                //if (blog != null)
                {
                    //if (System.IO.File.Exists("./wwwroot/img/" + blog.Image))
                    //{
                    //    System.IO.File.Delete("./wwwroot/img/" + blog.Image);
                    //}
                    //_context.Blog.Remove(blog);
                    await ScopedData.DBContext.SaveChangesAsync();

                    return RedirectToPage("./Index");
                }
            }
            return Page();
        }
     
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    string fileName = string.Empty;

           
        //    if (UploadedImage != null)
        //    {
        //        Random rnd = new Random();
        //        fileName = rnd.Next(1, 100000).ToString() + UploadedImage.FileName;
        //        var file = "./wwwroot/img/" + fileName;

        //        using (var fileStream = new FileStream(file, FileMode.Create))
        //        {
        //            await UploadedImage.CopyToAsync(fileStream);
        //        }
        //    }
        //    else
        //    {
        //        fileName = UploadedImage + "ingenbildbild.jpg";
        //        var file = "./wwwroot/img/" + fileName;
        //    }
          

        //    _context.Add(Category);

        //    await _context.SaveChangesAsync();


        //    return RedirectToPage("./Index");
        //}




    }
}