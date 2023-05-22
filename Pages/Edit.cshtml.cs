//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using PublicProject.Data;
//using PublicProject.Models;

//namespace PublicProject.Pages.CRUD
//{
//    public class EditModel : PageModel
//    {
//        private readonly PublicProject.Data.ApplicationDbContext _context;

//        public EditModel(PublicProject.Data.ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        [BindProperty]
//        public Category Category { get; set; }

//        public async Task<IActionResult> OnGetAsync(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            Category = await _context.Category.FirstOrDefaultAsync(m => m.Id == id);

//            if (Blog == null)
//            {
//                return NotFound();
//            }
//            return Page();
//        }

//        public async Task<IActionResult> OnPostAsync()
//        {
//            if (!ModelState.IsValid)
//            {
//                return Page();
//            }

//            _context.Attach(Blog).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!BlogExists(Blog.Id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return RedirectToPage("/Overview", new { id = Category.UserId });
//        }

//        private bool BlogExists(int id)
//        {
//            return _context.Blog.Any(e => e.Id == id);
//        }
//    }
//}
