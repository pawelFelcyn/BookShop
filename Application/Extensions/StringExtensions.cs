namespace Application.Extensions
{
    public static class StringExtensions
    {
        public static bool ContainsOnlyDigits(this string value)
        {
            foreach (var c in value)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}
