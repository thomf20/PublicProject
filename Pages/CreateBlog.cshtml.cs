using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PublicProject.Models;

namespace PublicProject.Pages
{
    public class CreateBlogModel : PageModel
    {
        private readonly Data.ApplicationDbContext DBContext; // Byt ut "YourDbContext" med namnet på din databaskontext
        
        public Models.Category Category { get; set; }
        public Models.SubCategory Subcategory { get; set; }
        
        public List<Models.Blog> Blogs { get; set; }
        [BindProperty]
        public Blog Blog { get; set; } = default!;


        public CreateBlogModel(Data.ApplicationDbContext dbContext) // Byt ut "YourDbContext" med namnet på din databaskontext
        {
            DBContext = dbContext;
        }


        public IActionResult OnGet(int SubCategoryId)
        {

            Blogs = DBContext.Blogs.ToList();
            Subcategory = DBContext.SubCategories.Find(SubCategoryId);
            Category = DBContext.Categories.Find(Subcategory.CategoryId);


            DBContext.SaveChanges();
            return Page();

        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || DBContext.Blogs == null || Blogs == null)
            {
                return Page();
            }


            DBContext.Comments.Add(Blog);
            await DBContext.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
