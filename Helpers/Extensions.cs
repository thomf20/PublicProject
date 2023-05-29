namespace PublicProject.Extensions
{
    public class Extensions
    {
        public static string LimitLength(string source, int maxLength)
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
