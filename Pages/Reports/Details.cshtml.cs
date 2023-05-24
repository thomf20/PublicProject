using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PublicProject.Data;
using PublicProject.Models;

namespace PublicProject.Pages.Reports
{
    public class DetailsModel : PageModel
    {
        private readonly PublicProject.Data.ApplicationDbContext _context;

        public DetailsModel(PublicProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
