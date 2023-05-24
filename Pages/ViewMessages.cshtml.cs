using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PublicProject.Pages
{
    public class MessagesModel : PageModel
    {
        private readonly Data.ApplicationDbContext DBContext;
        public List<Models.Category> Categories { get; set; }
        public List<Models.SubCategory> Subcategories { get; set; }
        public List<Models.Blog> Blogs { get; set; }
        public Models.Message Message { get; set; }
        public List<Models.Message> Messages { get; set; }


        public MessagesModel(Data.ApplicationDbContext dbContext)
        {
            DBContext = dbContext;
        }


        public IActionResult OnGet(int id)
        {
            Messages = DBContext.Messages.ToList();
            Message = DBContext.Messages.Find(id);
            Blogs = DBContext.Blogs.ToList();
            Subcategories = DBContext.SubCategories.ToList();
            Categories = DBContext.Categories.ToList();


            DBContext.SaveChanges();
            return Page();

        }
       
    }
}
