using System;
using System.Linq;

namespace PropertyMatcher.Utilities
{
    public static class Extensions
    {
        public static string RemovePunctuation(this string value)
        {
            return new string(value.Where(c => !char.IsPunctuation(c)).ToArray());
        }
        public static string ReverseWords(this string value)
        {
            var strArray = value.Split(' ');
            Array.Reverse(strArray);
            var strRev = strArray.Aggregate((i, j) => i + " " + j);
            return strRev;
        }



    }
}
