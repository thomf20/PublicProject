using System;
using System.Collections.Generic;
using System.Linq;
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

        public EditBlogModel(UtilitiesToBeScoped utilitiesToBeScoped, PublicProject.Data.ApplicationDbContext context)
        {
            ScopedData = utilitiesToBeScoped;
            _context = context;
        }

        private readonly PublicProject.Data.ApplicationDbContext _context;

        [BindProperty]
        public IFormFile UploadedImage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Blogs == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs.FirstOrDefaultAsync(m => m.Id == id);
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
            }

            

            var oldblog = _context.Blogs.FirstOrDefault(b => b.Id == Blog.Id);
            oldblog.Title = Blog.Title;
            oldblog.Text = Blog.Text;
            oldblog.Image = Blog.Image;

            try
            {
                await _context.SaveChangesAsync();
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
            return RedirectToPage("./Index");
        }
        private bool BlogExists(int id)
        {
            return (_context.Blogs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
