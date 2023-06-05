using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PublicProject.Services;

namespace PublicProject.Pages
{
    public class ShowAllMyBlogsModel : PageModel
    {
        public readonly UtilitiesToBeScoped ScopedData;
        public List<Models.Blog> Blogs { get; set; }
        public ShowAllMyBlogsModel(UtilitiesToBeScoped utilitiesToBeScoped)
        {
            ScopedData = utilitiesToBeScoped;
        }
        public void OnGet(string id)
        {
            Blogs = ScopedData.Blogs.Where(x => x.UserId == id).ToList();
        }
    }
}
