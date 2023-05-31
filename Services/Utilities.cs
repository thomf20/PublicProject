using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Licenses;
using PublicProject.Data;
using PublicProject.Models;
using System.Collections.Generic;

namespace PublicProject.Services
{
    public class Utilities : IUtilities
    {
        public DateTime TodayDate { get; set; }
        public int AnyRandomNumber { get; set; }
        public string Message { get; set; }

        public readonly Data.ApplicationDbContext DBContext;
        
        public Utilities(Data.ApplicationDbContext dbContext)
        {
            DBContext = dbContext;
            Refresh();
        }
        public DateTime GetDate()
        {
            return TodayDate;
        }
        public int GetRandomInt()
        {
            return AnyRandomNumber;
        }
        public void Refresh()
        {
            TodayDate = DateTime.Now;
            AnyRandomNumber = Random.Shared.Next(1000, 10000);
        }
    }
}
