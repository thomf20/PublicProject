using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PublicProject.Models;

namespace PublicProject.Pages
{
    public class ViewForumPostModel : PageModel
    {

        private readonly Data.ApplicationDbContext DBContext;

        public Blog BlogPost { get; set; }
        public Models.Category Category { get; set; }
        public List<Models.SubCategory> Subcategories { get; set; }
        public List<Models.Comment> Comments { get; set; }


        private readonly PublicProject.Data.ApplicationDbContext _context;
        public ViewForumPostModel(Data.ApplicationDbContext dbContext) 
        {
            DBContext = dbContext;
            _context = dbContext;
        }
        [BindProperty]
        public Comment Comment { get; set; } = default!;

        
        public IActionResult OnGet(int id)
        {

            BlogPost = DBContext.Blogs.Find(id);
            Comments = DBContext.Comments.ToList();

            if (BlogPost.Popularity == null)
            {
                BlogPost.Popularity = 0;
            }
            
            BlogPost.Popularity++;


            if (BlogPost == null)
            {
                return NotFound();
            }

            DBContext.SaveChanges();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Comments == null || Comment == null)
            {
                return Page();
            }


            _context.Comments.Add(Comment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


    }
}
