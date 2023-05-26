using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PublicProject.Models;

namespace PublicProject.Pages
{
    public class ViewForumPostModel : PageModel
    {

        private readonly Data.ApplicationDbContext DBContext; // Byt ut "YourDbContext" med namnet på din databaskontext

        public Blog BlogPost { get; set; }
        public Models.Category Category { get; set; }
        public List<Models.SubCategory> Subcategories { get; set; }
        public List<Models.Comment> Comments { get; set; }
        public List<Models.UserProfile> UserProfiles { get; set; }


        private readonly PublicProject.Data.ApplicationDbContext _context;
        public ViewForumPostModel(Data.ApplicationDbContext dbContext) // Byt ut "YourDbContext" med namnet på din databaskontext
        {
            DBContext = dbContext;
            _context = dbContext;
        }
        

        [BindProperty]
        public Comment Comment { get; set; } = default!;

        [BindProperty]
        public Message Message { get; set; } = default!;

        [BindProperty]
        public Report Report { get; set; } = default!;


        public IActionResult OnGet(int id)
        {

            BlogPost = DBContext.Blogs.Find(id);
            Comments = DBContext.Comments.ToList();
            UserProfiles = DBContext.UserProfiles.ToList();



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

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostSendCommentAsync()
        {
            //if (!ModelState.IsValid || _context.Comments == null || Comment == null)
            //{
            //    return Page();
            //}


            _context.Comments.Add(Comment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostReportAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _context.Reports.Add(Report);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostSendMessageAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _context.Messages.Add(Message);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
