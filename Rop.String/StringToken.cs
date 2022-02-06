using System.Collections.Generic;
using System.Linq;

namespace Rop.String
{
    /// <summary>
    /// Helper class to Parsing String
    /// </summary>
    public static class StringToken
    {
        /// <summary>
        /// Check if a symbol is present in a position
        /// </summary>
        /// <param name="cad">String to check</param>
        /// <param name="pos">Position to check</param>
        /// <param name="symbols">Desired symbols to check</param>
        /// <param name="ignorecase">Ignore case</param>
        /// <returns>Symbol that match</returns>
        public static string SymbolInPos(this string cad, int pos, IEnumerable<string> symbols, bool ignorecase = false)
        {
            if ((pos < 0) || (pos >= cad.Length)) return "";
            cad = cad.Substring(pos);
            var sc = ignorecase.ToIgnoreCase();
            var sep = symbols.OrderByDescending(ss => ss.Length);
            return sep.FirstOrDefault(s => cad.StartsWith(s, sc)) ?? "";
        }
        /// <summary>
        /// Check if a symbol is present in a position
        /// </summary>
        /// <param name="cad">String to check</param>
        /// <param name="pos">Position to check</param>
        /// <param name="symbols">Desired symbols to check</param>
        /// <returns>Symbol that match</returns>
        public static string SymbolInPos(this string cad, int pos, params string[] symbols) =>
            cad.SymbolInPos(pos, symbols, false);
        /// <summary>
        /// Extract token from string
        /// </summary>
        /// <param name="separator">Alowed tokens symbols</param>
        /// <param name="cad">String to check. Return cad without token</param>
        /// <param name="ignorecase">Ignore case</param>
        /// <returns>Token extracted or empty</returns>
        public static string GetToken(string[] separator, ref string cad, bool ignorecase = false)
        {
            if (string.IsNullOrEmpty(cad)) return "";
            var sep = separator.OrderByDescending(ss => ss.Length).ToList();
            var sc = ignorecase.ToIgnoreCase();
            foreach (var s in sep)
            {
                if (cad.StartsWith(s, sc))
                {
                    cad = cad.Substring(s.Length);
                    return s;
                }
            }

            var pf = int.MaxValue;
            foreach (var s in sep)
            {
                var p = cad.IndexOf(s, sc);
                if (p < 0) continue;
                if (p < pf) pf = p;
            }

            if (pf >= cad.Length)
            {
                var res = cad;
                cad = "";
                return res;
            }

            var token = cad.Substring(0,pf);
            cad = cad.Substring(pf);
            return token;
        }
        /// <summary>
        /// Check if a string contains a substring
        /// </summary>
        /// <param name="cad">String to check</param>
        /// <param name="search">Substring to check</param>
        /// <param name="ignorecase">Ignore case</param>
        /// <returns>True if substring are into string</returns>
        public static bool ContainsCase(this string cad, string search, bool ignorecase = false)
        {
            var p = cad.IndexOf(search, ignorecase.ToIgnoreCase());
            return p >= 0;
        }

    }
}