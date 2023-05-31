using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PublicProject.Models;
using PublicProject.Services;
using System.Security.Claims;

namespace PublicProject.Pages
{
    public class IndexModel : PageModel
    {
        public readonly UtilitiesToBeScoped ScopedData;

        public IndexModel(UtilitiesToBeScoped utilitiesToBeScoped)
        {
            ScopedData = utilitiesToBeScoped;
        }
    }
}