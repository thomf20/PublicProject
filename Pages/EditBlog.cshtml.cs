using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            var oldblog = ScopedData.DBContext.Blogs.FirstOrDefault(b => b.Id == Blog.Id);
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
                fileName = Blog.Image;

                if(fileName== null)
                {
                    fileName = "ingenbildbild.jpg";
                }
            }

        
           
            oldblog.Image = fileName;   
            oldblog.Title = Blog.Title;
            oldblog.Text = Blog.Text;
          
            await ScopedData.DBContext.SaveChangesAsync();
            
            return RedirectToPage("./Viewforumpost", new { id = Blog.Id } );
        }
       
    }
}
