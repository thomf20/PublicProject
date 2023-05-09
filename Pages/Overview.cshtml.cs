using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace PublicProject.Pages
{
    public class OverviewModel : PageModel
    {
        IndexModel _indexmodel = new IndexModel(IndexModel._contexts);   
        public int MyProperty { get; set; }

        [BindProperty]
        public Models.Blogg Blog { get; set; }

        public List<Models.Blogg> Blogsunique { get; set; }



        public void Onget(string id )
        {
            if (_indexmodel.Blog != null)
            {
                var findid = _indexmodel.Blogs.Where(b => b.UserId == id);

                foreach (var x in findid)
                    Blogsunique.Add(x);

            }
        }

        //public async Task<IActionResult> OnGetAsync(string id)
        //{

          


            //    return RedirectToPage("./Index");
            //}
            //public static FindBlogId()
            //{
            //    var findid = IndexModel.Blogs.Where(b => b.UserId == user.Id)


            //}
        }
}
