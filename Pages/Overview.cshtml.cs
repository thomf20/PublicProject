using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace PublicProject.Pages
{
    public class OverviewModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        IndexModel _indexmodel = new IndexModel(IndexModel._contexts);   
        public int MyProperty { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            var findid = IndexModel.Blogs.Where(b => b.UserId == user.Id).All();

            return null;
        }
        //public static FindBlogId()
        //{
        //    var findid = IndexModel.Blogs.Where(b => b.UserId == user.Id)


        //}
    }
}
