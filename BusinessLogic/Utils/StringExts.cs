using System;
using System.Text;
using static System.Security.Cryptography.HashAlgorithm;

namespace BusinessLogic.Utils
{
    public static class StringExts
    {
        public static string SafeTrim(this string str)
        {
            return string.IsNullOrWhiteSpace(str) ? string.Empty : str.Trim();
        }
        
        public static bool SameAs(this string str, string another, bool ignoreCase = true)
        {
            if (string.IsNullOrWhiteSpace(str) && string.IsNullOrWhiteSpace(another))
            {
                return true;
            }

            str = str.SafeTrim();
            another = another.SafeTrim();

            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (ignoreCase)
            {
                return string.Equals(str, another, StringComparison.OrdinalIgnoreCase);
            }

            return string.Equals(str, another);
        }

        public static bool NotSameAs(this string str, string another, bool ignoreCase = true)
        {
            return !str.SameAs(another, ignoreCase);
        }
        
        private const string Prefix = "B889TUPCZep4zeuL";

        public  static string Encode(this string password)
        {
            var bytes = Encoding.Unicode.GetBytes(Prefix + password);
            // ReSharper disable once PossibleNullReferenceException
            var inArray = Create("SHA1").ComputeHash(bytes);
            
            return Convert.ToBase64String(inArray);
        }

        public static bool Verify(this string current, string encrypted)
        {
            return string.Equals(current.Encode(), encrypted);
        }
    }
}