using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using PublicProject.Models;
using PublicProject.Services;

namespace PublicProject.Pages
{
    public class ViewForumPostModel : PageModel
    {
        public Blog BlogPost { get; set; }
        //public Models.Category Category { get; set; }
        //public List<Models.SubCategory> Subcategories { get; set; }
        //public List<Models.Comment> Comments { get; set; }
        //public List<Models.UserProfile> UserProfiles { get; set; }

        public IUtilities Data { get; set; }

        public readonly UtilitiesToBeScoped ScopedData;
        
        public ViewForumPostModel(UtilitiesToBeScoped utilitiesToBeScoped) // Byt ut "YourDbContext" med namnet på din databaskontext
        {
            ScopedData = utilitiesToBeScoped;
        }

        
        [BindProperty]
        public Comment Comment { get; set; } = default!;

        [BindProperty]
        public Message Message { get; set; } = default!;

        [BindProperty]
        public Report Report { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(int id)
        {
            
            

            BlogPost = await ScopedData.DBContext.Blogs.FindAsync(id);
            
            //Comments = await ScopedData.DBContext.Comments.ToListAsync();
            //UserProfiles = await ScopedData.DBContext.UserProfiles.ToListAsync();



            if (BlogPost.Popularity == null)
            {
                BlogPost.Popularity = 0;
            }
            
            BlogPost.Popularity++;


            if (BlogPost == null)
            {
                return NotFound();
            }

           await ScopedData.DBContext.SaveChangesAsync();
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostSendCommentAsync()
        {
            //if (!ModelState.IsValid || ScopedData.DBContext.Comments == null || Comment == null)
            //{
            //    return Page();
            //}


            await ScopedData.DBContext.Comments.AddAsync(Comment);
            await ScopedData.DBContext.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostReportAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            ScopedData.DBContext.Reports.Add(Report);
            await ScopedData.DBContext.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostSendMessageAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            ScopedData.DBContext.Messages.Add(Message);
            await ScopedData.DBContext.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
