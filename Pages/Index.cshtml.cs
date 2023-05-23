using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PublicProject.Models;
using System.Security.Claims;

namespace PublicProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public IndexModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Models.Category> Categories { get; set; }

        [BindProperty]
        public Models.Category Category { get; set; }
        public List<Blog> Blogs { get; set; }



        [BindProperty]
        public IFormFile UploadedImage { get; set; }
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
                    await _context.SaveChangesAsync();

                    return RedirectToPage("./Index");
                }
            }

            //Blogs = await _context.Blog.ToListAsync();
            Blogs = _context.Blogs.ToList();


            return Page();
        }
     
        public async Task<IActionResult> OnPostAsync()
        {
            string fileName = string.Empty;

            // Generarar ett relativt unikt fil namn så att det inte finns 100 filer med samma namn.
            if (UploadedImage != null)
            {
                Random rnd = new Random();
                fileName = rnd.Next(1, 100000).ToString() + UploadedImage.FileName;
                var file = "./wwwroot/img/" + fileName;

                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await UploadedImage.CopyToAsync(fileStream);
                }
            }
            else
            {
                fileName = UploadedImage + "ingenbildbild.jpg";
                var file = "./wwwroot/img/" + fileName;
            }
            //Blog.Date = DateTime.Now;
            //Blog.Image = fileName;
            //Blog.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            _context.Add(Category);

            await _context.SaveChangesAsync();


            return RedirectToPage("./Index");
        }




    }
}