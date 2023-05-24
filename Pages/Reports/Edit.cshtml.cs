using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PublicProject.Data;
using PublicProject.Models;

namespace PublicProject.Pages.Reports
{
    public class EditModel : PageModel
    {
        private readonly PublicProject.Data.ApplicationDbContext _context;

        public EditModel(PublicProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ReportMessage ReportMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ReportMessage = await _context.ReportMessages.FirstOrDefaultAsync(m => m.Id == id);

            if (ReportMessage == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ReportMessage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportMessageExists(ReportMessage.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ReportMessageExists(int id)
        {
            return _context.ReportMessages.Any(e => e.Id == id);
        }
    }
}
