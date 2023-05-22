using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PublicProject.Data;
using PublicProject.Models;

namespace PublicProject.Pages.SubCategory
{
    public class IndexModel : PageModel
    {
        private readonly PublicProject.Data.ApplicationDbContext _context;

        public IndexModel(PublicProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.SubCategory> SubCategory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.SubCategories != null)
            {
                SubCategory = await _context.SubCategories.ToListAsync();
            }
        }
    }
}
