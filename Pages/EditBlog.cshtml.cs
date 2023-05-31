using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PublicProject.Data;
using PublicProject.Models;
using PublicProject.Services;

namespace PublicProject.Pages
{
    public class EditBlogModel : PageModel
    {
        public readonly UtilitiesToBeScoped ScopedData;

        [BindProperty]
        public Blog Blog { get; set; } = default!;

        public EditBlogModel(UtilitiesToBeScoped utilitiesToBeScoped)
        {
            ScopedData = utilitiesToBeScoped;
            
        }

       
       

        [BindProperty]
        public IFormFile UploadedImage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || ScopedData.DBContext.Blogs == null)
            {
                return NotFound();
            }

            var blog = await ScopedData.DBContext.Blogs.FirstOrDefaultAsync(m => m.Id == id);

            if (blog == null)
            {
                return NotFound();
            }
            Blog = blog;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string fileName = string.Empty;
            var oldblog = ScopedData.DBContext.Blogs.FirstOrDefault(b => b.Id == Blog.Id);
            if (!ModelState.IsValid || ScopedData.Blogs == null || Blog == null)
            {
                return Page();
            }
            if (UploadedImage != null)
            {
                Random rnd = new();
                fileName = rnd.Next(0, 100000).ToString() + UploadedImage.FileName;
                var file = "./wwwroot/img/" + fileName;
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await UploadedImage.CopyToAsync(fileStream);
                }
                oldblog.Image = fileName;   //så här skulle det stå om man ville ändra bild
               
            }
            else
            {
                oldblog.Image = Blog.Image;
            }
                oldblog.Title = Blog.Title;
                oldblog.Text = Blog.Text;
            try
            {
                await ScopedData.DBContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogExists(Blog.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./Viewforumpost", new { id = Blog.Id } );
        }
        private bool BlogExists(int id)
        {
            return (ScopedData.DBContext.Blogs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
