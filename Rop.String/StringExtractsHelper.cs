using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rop.String
{
    /// <summary>
    /// Helper to extract substrings
    /// </summary>
    public static class StringExtractsHelper
    {
        /// <summary>
        /// Try extract substring from string
        /// </summary>
        /// <param name="a">String to parse</param>
        /// <param name="prefix">Desired prefix</param>
        /// <param name="suffix">Desired suffix</param>
        /// <param name="trim">Trim result</param>
        /// <param name="comparer">String comparer</param>
        /// <param name="result">Substring</param>
        /// <returns>True if match</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool TryExtract(this string a, string prefix, string suffix,bool trim, StringComparison comparer,out string result)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            result = string.Empty;
            if (!a.StartsAndEndsWith(prefix, suffix, comparer, out var from, out var to)) return false;
            a = a.Substring(from, to - from);
            result =(trim)?a.Trim():a;
            return true;
        }
        /// <summary>
        /// Try extract substring from string
        /// </summary>
        /// <param name="a">String to parse</param>
        /// <param name="prefix">Desired prefix</param>
        /// <param name="suffix">Desired suffix</param>
        /// <param name="result">Substring</param>
        /// <returns>True if match</returns>
        public static bool TryExtract(this string a, string prefix, string suffix, out string result)
        {
            return TryExtract(a, prefix, suffix, false, StringComparison.Ordinal, out result);
        }
        /// <summary>
        /// Try extract substring from string
        /// </summary>
        /// <param name="a">String to parse</param>
        /// <param name="prefix">Desired prefix</param>
        /// <param name="suffix">Desired suffix</param>
        /// <param name="trim">Trim result</param>
        /// <param name="result">Substring</param>
        /// <returns>True if match</returns>
        public static bool TryExtract(this string a, string prefix, string suffix, bool trim, out string result)
        {
            return TryExtract(a, prefix, suffix, trim, StringComparison.Ordinal, out result);
        }
        /// <summary>
        /// Try extract substring from string
        /// </summary>
        /// <param name="a">String to parse</param>
        /// <param name="prefix">Desired prefix</param>
        /// <param name="suffix">Desired suffix</param>
        /// <param name="comparer">String comparer</param>
        /// <param name="result">Substring</param>
        /// <returns>True if match</returns>
        public static bool TryExtract(this string a, string prefix, string suffix, StringComparison comparer,
            out string result)
        {
            return TryExtract(a, prefix, suffix, false, comparer, out result);
        }
        /// <summary>
        /// Try extract substring from string (no case)
        /// </summary>
        /// <param name="a">String to parse</param>
        /// <param name="prefix">Desired prefix</param>
        /// <param name="suffix">Desired suffix</param>
        /// <param name="trim">Trim result</param>
        /// <param name="result">Substring</param>
        /// <returns>True if match</returns>
        public static bool TryExtractNoCase(this string a, string prefix, string suffix, bool trim, out string result)
        {
            return TryExtract(a, prefix, suffix,trim, StringComparison.OrdinalIgnoreCase, out result);
        }
        /// <summary>
        /// Try extract substring from string (no case)
        /// </summary>
        /// <param name="a">String to parse</param>
        /// <param name="prefix">Desired prefix</param>
        /// <param name="suffix">Desired suffix</param>
        /// <param name="result">Substring</param>
        /// <returns>True if match</returns>
        public static bool TryExtractNoCase(this string a, string prefix, string suffix, out string result)
        {
            return TryExtract(a, prefix, suffix, StringComparison.OrdinalIgnoreCase, out result);
        }
        /// <summary>
        /// Try extract substring from strins between two strings
        /// </summary>
        /// <param name="cad">String to parse</param>
        /// <param name="left">Desired prefix</param>
        /// <param name="right">Desired suffix</param>
        /// <param name="ignorecase">Ignore case</param>
        /// <returns>Substring beetween left and right. Empty string if no match</returns>

        public static string Between(this string cad, string left, string right,bool ignorecase = false)
        {
            var sc = ignorecase.ToIgnoreCase();
            var p = cad.IndexOf(left, sc);
            if (p < 0) return "";
            var p2 = cad.IndexOf(right, p + 1,sc);
            if (p2 < 0) return "";
            return cad.Between(p + 1, p2 - 1);
        }
        /// <summary>
        /// Get left part of a string
        /// </summary>
        /// <param name="cad">String</param>
        /// <param name="sep">Separator</param>
        /// <param name="ignorecase">Ignore case</param>
        /// <returns>Left part if match. Complete cad if no match</returns>
        public static string LeftTo(this string cad, string sep, bool ignorecase = false)
        {
            var sc = ignorecase.ToIgnoreCase();
            var p = cad.IndexOf(sep,sc);
            return (p < 0) ? cad : cad.Substring(0, p);
        }
        /// <summary>
        /// Get right part of a string
        /// </summary>
        /// <param name="cad">String</param>
        /// <param name="sep">Separator</param>
        /// <param name="ignorecase">Ignore case</param>
        /// <returns>Right part if match. Complete cad if no match</returns>
        public static string RightTo(this string cad, string sep, bool ignorecase = false)
        {
            var sc = ignorecase.ToIgnoreCase();
            var p = cad.IndexOf(sep, sc);
            return (p < 0) ? cad : cad.Substring(p + sep.Length);
        }
        /// <summary>
        /// Breaks a string in two parts
        /// </summary>
        /// <param name="cad">String</param>
        /// <param name="separator">Separator</param>
        /// <param name="ignorecase">Ignore case</param>
        /// <returns>A tuple with string broken in two parts</returns>
        public static (string, string) Break(this string cad, string separator, bool ignorecase = false)
        {
            var sc = ignorecase.ToIgnoreCase();
            var p = cad.IndexOf(separator, sc);
            return (p < 0) ? (cad, "") : (cad.Substring(0, p), cad.Substring(p + 1));
        }
        /// <summary>
        /// Break a string representing a domain account
        /// </summary>
        /// <param name="cad">String</param>
        /// <returns>Domain, user tuple</returns>
        public static (string Domain, string User) StripDomain(this string cad)
        {
            var r = cad.Break("\\");
            if (r.Item2!="") return r;
            r = cad.Break("@");
            if (r.Item2 == "") return ("","");
            return (r.Item2, r.Item1);
        }
        /// <summary>
        /// Get user part of a string representing a domain account ensuring domain name
        /// </summary>
        /// <param name="cad">String</param>
        /// <param name="ensuredomain">Domain to ensure</param>
        /// <returns>Account name or empty if not match</returns>
        public static string StripDomain(this string cad,string ensuredomain)
        {
            var r = StripDomain(cad);
            if (!r.Item1.StartsWithNoCase(ensuredomain)) return "";
            return r.Item2;
        }
    }
}
