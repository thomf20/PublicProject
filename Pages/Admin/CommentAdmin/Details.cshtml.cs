﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PublicProject.Data;
using PublicProject.Models;

namespace PublicProject.Pages.CommentAdmin
{
    public class DetailsModel : PageModel
    {
        private readonly PublicProject.Data.ApplicationDbContext _context;

        public DetailsModel(PublicProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Comment Comment { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Comments == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments.FirstOrDefaultAsync(m => m.Id == id);
            if (comment == null)
            {
                return NotFound();
            }
            else 
            {
                Comment = comment;
            }
            return Page();
        }
    }
}
