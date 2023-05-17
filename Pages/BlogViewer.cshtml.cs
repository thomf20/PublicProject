using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PublicProject.Pages
{
    public static class BlogViewerModel 
    {
        public static string LimitLength(this string source, int maxLength)
        {
            if (source != null)
            {
                if (source.Length <= maxLength)
                {
                    return source;
                }

                return source.Substring(0, maxLength);
            }
            return source;
        }
    }
}
