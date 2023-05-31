using PublicProject.Data;
using PublicProject.Models;

namespace PublicProject.Services
{
    public interface IUtilities
    {
        int AnyRandomNumber { get; set; }
        string Message { get; set; }
        DateTime TodayDate { get; set; }
        DateTime GetDate();
        int GetRandomInt();
        void Refresh();
    }
}