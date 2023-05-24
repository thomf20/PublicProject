using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PublicProject.Models;

namespace PublicProject.Pages
{
    public class CreateBlogModel : PageModel
    {
        private readonly Data.ApplicationDbContext DBContext;
        
        public Models.Category Category { get; set; }
        public Models.SubCategory Subcategory { get; set; }
        
        public List<Models.Blog> Blogs { get; set; }

        private readonly PublicProject.Data.ApplicationDbContext _context;
  


        public CreateBlogModel(Data.ApplicationDbContext dbContext)
        {
            DBContext = dbContext;
            _context = dbContext;
        }
        [BindProperty]
        public Blog Blog { get; set; } = default!;
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
            if (!ModelState.IsValid || _context.Blogs == null || Blog == null)
            {
                return Page();
            }


            _context.Blogs.Add(Blog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


    }

}

