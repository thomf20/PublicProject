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

        public readonly UtilitiesToBeScoped ScopedData;
        
        public ViewForumPostModel(UtilitiesToBeScoped utilitiesToBeScoped) 
        {
            ScopedData = utilitiesToBeScoped;
        }

        
        [BindProperty]
        public Comment Comment { get; set; } = default!;

        [BindProperty]
        public Message Message { get; set; } = default!;

        [BindProperty]
        public Report Report { get; set; } = default!;

        static int blogpostid;

      

        public async Task<IActionResult> OnGetAsync(int id)
        {
           

            ScopedData.blog = await ScopedData.DBContext.Blogs.FindAsync(id);
           

            if (ScopedData.blog.Popularity == null)
            {
                ScopedData.blog.Popularity = 0;
            }

            ScopedData.blog.Popularity++;

            blogpostid = id;

            if (ScopedData.blog == null)
            {
                return NotFound();
            }

           await ScopedData.DBContext.SaveChangesAsync();


            return Page();
        }
        public async Task<IActionResult> OnPostSendCommentAsync()
        {
            //if (!ModelState.IsValid || ScopedData.DBContext.Comments == null || Comment == null)
            //{
            //    return Page();
            //}


            await ScopedData.DBContext.Comments.AddAsync(Comment);
            await ScopedData.DBContext.SaveChangesAsync();



            return RedirectToPage("/ViewForumPost", new { id = blogpostid });
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD


        public async Task<IActionResult> OnPostReportAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            ScopedData.DBContext.Reports.Add(Report);
            await ScopedData.DBContext.SaveChangesAsync();



            return RedirectToPage("/ViewForumPost", new { id = blogpostid });
        }

   
    }
}
