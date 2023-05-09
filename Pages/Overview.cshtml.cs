using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace PublicProject.Pages
{
    public class OverviewModel : PageModel
    {
    
        //[BindProperty]
        //public Models.Blog Blog { get; set; }

        //private readonly Data.ApplicationDbContext _context;
        //public OverviewModel(Data.ApplicationDbContext context)
        //{
        //    _context = context;
        //}


        //public List<Models.Blog> Blogs { get; set; }

        //[BindProperty]
        //public IFormFile UploadedImage { get; set; }

     

        public void OnGet()
        {

        }
        //public async Task<IActionResult> OnGetAsync(int deleteid)
        //{
        //    if (deleteid != 0)
        //    {
        //        Models.Blog blog = await _context.Blog.FindAsync(deleteid);

        //        if (blog != null)
        //        {
        //            if (System.IO.File.Exists("./wwwroot/img/" + blog.Image))
        //            {
        //                System.IO.File.Delete("./wwwroot/img/" + blog.Image);
        //            }
        //            _context.Blog.Remove(blog);
        //            await _context.SaveChangesAsync();
        //            return RedirectToPage("./Index");
        //        }
        //    }

        //    if (Blogs != null )
        //    {
        //        Blogs = await _context.Blog.ToListAsync();
        //    }
            
        //    return Page();
        //}

        //public async Task<IActionResult> OngetAsync()
        //{
        //    //if (_indexmodel.Blog != null)
        //    //{
        //    //    var findid = _indexmodel.Blogs.Where(b => b.UserId == id);

        //    //    foreach (var x in findid)
        //    //        Blogsunique.Add(x);

        //    //}

        //    //Uri address = new Uri(Request.Host.ToString());


        //    return Page();
        //}

        //public async Task<IActionResult> OnGetAsync(string id)
        //{

        //    return RedirectToPage("./Index");
        //}
        //public static FindBlogId()
        //{
        //    var findid = IndexModel.Blogs.Where(b => b.UserId == user.Id)
        //}

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
        //    Blog.Date = DateTime.Now;
        //    Blog.Image = fileName;
        //    Blog.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    _context.Add(Blog);

        //    await _context.SaveChangesAsync();


        //    return Page();
        //}



    }
}
