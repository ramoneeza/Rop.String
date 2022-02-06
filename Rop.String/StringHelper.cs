using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rop.String
{
    /// <summary>
    /// String helper class
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// StartsWith including end index
        /// </summary>
        /// <param name="a">String</param>
        /// <param name="b">desired start</param>
        /// <param name="comparer">case comparer</param>
        /// <param name="endindex">End Index of match</param>
        /// <returns></returns>
        public static bool StartsWith(this string a,string b, StringComparison comparer, out int endindex)
        {
            b ??= string.Empty;
            if (!a.StartsWith(b, comparer))
            {
                endindex = -1;
                return false;
            }
            else
            {
                endindex = b.Length;
                return true;
            }
        }
        /// <summary>
        /// EndsWith including begin index
        /// </summary>
        /// <param name="a">String</param>
        /// <param name="b">Desired end</param>
        /// <param name="comparer">Case comparer</param>
        /// <param name="beginindex">Begin index of end. -1 if not match</param>
        /// <returns>True if match</returns>
        public static bool EndsWith(this string a, string b, StringComparison comparer, out int beginindex)
        {
            b ??= string.Empty;
            var desiredindex = a.Length - b.Length;
            beginindex = a.LastIndexOf(b, comparer);
            if (beginindex!=desiredindex)
            {
                beginindex = -1;
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Check if string starts and ends with a prefix and a suffix and returns index of both
        /// </summary>
        /// <param name="a">String</param>
        /// <param name="b">Prefix</param>
        /// <param name="c">Suffix</param>
        /// <param name="comparer">Case comparer</param>
        /// <param name="from">End index of prefix</param>
        /// <param name="to">Start index of suffix</param>
        /// <returns>True if match</returns>
        public static bool StartsAndEndsWith(this string a, string b,string c, StringComparison comparer, out int from,out int to)
        {
            b ??= string.Empty;
            c ??= string.Empty;
            from = 0;
            to = a.Length;
            if (b == string.Empty && c == string.Empty){ return true;}
            if (c == string.Empty) return a.StartsWith(b, comparer, out from);
            if (b == string.Empty) return a.EndsWith(c, comparer, out to);
            a.StartsWith(b, comparer, out from);
            a.EndsWith(c, comparer, out to);
            if (from == -1 || to == -1) return false;
            if (to <= from) return false;
            return true;
        }
        /// <summary>
        /// Return a substring or empty if parameters out of index
        /// </summary>
        /// <param name="cad">String</param>
        /// <param name="from">start index</param>
        /// <returns></returns>
        public static string SafeSubstring(this string cad, int from)
        {
            var len = cad.Length;
            return (from <= len) ? cad.Substring(@from) : "";
        }
        /// <summary>
        /// Return a substring or empty if parameters out of index
        /// </summary>
        /// <param name="cad">String</param>
        /// <param name="from">Start index</param>
        /// <param name="length">Length</param>
        /// <param name="spaces">Fill string with spaces to the desired length</param>
        /// <returns></returns>
        public static string SafeSubstring(this string cad, int from, int length, bool spaces = false)
        {
            var len = cad.Length;
            if ((len <= 0) || (length <= 0) || (from >= len)) return "";
            var res = cad.Substring(from, Math.Min(length, len - from));
            if (spaces) res = res.PadRight(length);
            return res;
        }
        /// <summary>
        /// Append all strings in a array
        /// </summary>
        /// <param name="cads">Array of string</param>
        /// <returns>Concatenated string</returns>
        public static string ConcatLines(params string[] cads)
        {
            var sb = new StringBuilder();
            foreach (var line in cads)
            {
                sb.AppendLine(line ?? "");
            }
            return sb.ToString();
        }
        /// <summary>
        /// Return another string if string is null or empty
        /// </summary>
        /// <param name="cad">String to compare</param>
        /// <param name="value">Another string</param>
        /// <returns>Original string or other if null or empty</returns>
        public static string IfNullOrEmpty(this string cad, string value) => (string.IsNullOrEmpty(cad)) ? value : cad;
        /// <summary>
        /// Return another string if string is null or empty or whitespace
        /// </summary>
        /// <param name="cad">String to compare</param>
        /// <param name="value">Another string</param>
        /// <returns>Original string or other if null or empty or whitespace</returns>
        public static string IfNullOrWhiteSpace(this string cad, string value) => (string.IsNullOrWhiteSpace(cad)) ? value : cad;
        /// <summary>
        /// Create a dummy string with maximun value
        /// </summary>
        public static string StringMax { get; } = new string(char.MaxValue, 8);
        /// <summary>
        /// Check if string is digit only
        /// </summary>
        /// <param name="cad">String to check</param>
        /// <returns>True if string is digit only</returns>
        public static bool IsDigitOnly(this string cad)
        {
            if (string.IsNullOrEmpty(cad)) return false;
            return cad.All(char.IsDigit);
        }
        private static readonly char[] FirstInt ="+-0123456789".ToCharArray();
        /// <summary>
        /// Check if cad represents a integer
        /// </summary>
        /// <param name="cad">string to check</param>
        /// <returns>True if string is a integer</returns>
        public static bool IsInteger(this string cad)
        {
            if (string.IsNullOrEmpty(cad)) return false;
            if (cad.Length == 1)
            {
                return char.IsDigit(cad[0]);
            }
            if (!FirstInt.Contains(cad[0])) return false;
            return cad.Substring(1).All(char.IsDigit);
        }
        /// <summary>
        /// Get substring beetween two positions.
        /// </summary>
        /// <param name="cad">String to parse</param>
        /// <param name="left">Left index</param>
        /// <param name="right">Right index</param>
        /// <param name="spaces">Fill with spaces if cad is shorten</param>
        /// <returns></returns>
        public static string Between(this string cad, int left, int right, bool spaces = false)
        {
            return cad.SafeSubstring(left, right - left + 1, spaces);
        }
        /// <summary>
        /// Conver bool value into StringComparison value
        /// </summary>
        /// <param name="c">Bool value (Case)</param>
        /// <returns>OrdinalIgnorecase or Ordinal string comparison</returns>
        public static StringComparison ToIgnoreCase(this bool c) =>
            c ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
    }
}
