using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PublicProject.Data;
using PublicProject.Models;

namespace PublicProject.Pages.Reports
{
    public class CreateModel : PageModel
    {
        private readonly PublicProject.Data.ApplicationDbContext _context;

        public CreateModel(PublicProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ReportMessage ReportMessage { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ReportMessages.Add(ReportMessage);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
