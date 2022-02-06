using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rop.String
{
    /// <summary>
    /// Extension class for enhanced char type
    /// </summary>
    public static class CharHelper
    {
        /// <summary>
        /// Is Equal with case option
        /// </summary>
        /// <param name="a">first char</param>
        /// <param name="b">secondchar</param>
        /// <param name="ignoreCase">enable case comparison</param>
        /// <returns>true is both chars are equal</returns>
        public static bool IsEqualCase(this char a, char b, bool ignoreCase = true)
        {
            return !ignoreCase ? a.Equals(b) : char.ToLower(a).Equals(char.ToLower(b));
        }
        /// <summary>
        /// Check if a char is included in a char range with case option
        /// </summary>
        /// <param name="a">Char to check</param>
        /// <param name="range">Char range to compare</param>
        /// <param name="ignoreCase">enable case comparison</param>
        /// <returns>true if char is present in range</returns>
        public static bool InRange(this char a, IEnumerable<char> range, bool ignoreCase = false)
        {
            return range.Any(c => c.IsEqualCase(a, ignoreCase));
        }
        /// <summary>
        /// Check if a char is NOT included in a char range with case option
        /// </summary>
        /// <param name="a">Char to check</param>
        /// <param name="range">Range to compare</param>
        /// <param name="ignoreCase">enable case comparison</param>
        /// <returns>true if char is NOT present in range</returns>
        public static bool NotInRange(this char a, IEnumerable<char> range, bool ignoreCase = false)
        {
            return !a.InRange(range,ignoreCase);
        }
        /// <summary>
        /// Create a char range from a char to another
        /// </summary>
        /// <param name="from">First char in range</param>
        /// <param name="to">Last char in range (included)</param>
        /// <returns>A IEnumerable char with the range</returns>
        public static IEnumerable<char> RangeChar(char from, char to) => RangeChar(from, ((int)to) - ((int)(from)) + 1);
        /// <summary>
        /// Create a char range from a char and count elements
        /// </summary>
        /// <param name="from">First char in range</param>
        /// <param name="count">Number o chars to include</param>
        /// <returns>A IEnumerable char with the range</returns>
        public static IEnumerable<char> RangeChar(char from, int count)
        {
            var c = from;
            for (var f = 0; f < count; f++)
            {
                yield return c;
                c++;
            }
        }
        private static readonly char[] Ctrimblanks = { ' ', '\r', '\n', '\t' };
        /// <summary>
        /// Trim blank characters (includes carriage returns)
        /// </summary>
        /// <param name="s">String to trim</param>
        /// <returns>string trimmed</returns>
        public static string TrimBlanks(this string s)
        {
            return s.Trim(Ctrimblanks);
        }
        private static readonly char[] Ctrimcontrol = { (char)1, (char)2, (char)3, (char)4, (char)5, (char)6, (char)7, (char)8,
            (char)9, (char)10, (char)11, (char)12, (char)13, (char)14, (char)15, (char)16,
            (char)17, (char)18, (char)19, (char)20, (char)21, (char)22, (char)23, (char)24,
            (char)25, (char)26, (char)27, (char)28, (char)29, (char)30, (char)31, (char)32 };
        /// <summary>
        /// Trim control characters
        /// </summary>
        /// <param name="s">String to trim</param>
        /// <returns>string trimmed</returns>
        public static string TrimControl(this string s) => s.Trim(Ctrimcontrol);
    }
}
