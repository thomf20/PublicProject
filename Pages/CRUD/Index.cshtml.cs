using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PublicProject.Data;
using PublicProject.Models;

namespace PublicProject.Pages.CRUD
{
    public class IndexModel : PageModel
    {
        private readonly PublicProject.Data.ApplicationDbContext _context;

        public IndexModel(PublicProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Blog> Blog { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Blog != null)
            {
                Blog = await _context.Blog.ToListAsync();
            }
        }
    }
}
