using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace Rop.String
{
    /// <summary>
    /// Helper classes for CASE and Diacritics
    /// </summary>
    public static class StringCaseHelper
    {
        /// <summary>
        /// Remove Diacritics from text
        /// </summary>
        /// <param name="text">Text with diacritics</param>
        /// <returns>Text without diacritics</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string RemoveDiacritics(this string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            ReadOnlySpan<char> normalizedString = text.Normalize(NormalizationForm.FormD).ToCharArray();
            var i = 0;
            Span<char> span = text.Length < 1000
                ? stackalloc char[text.Length]
                : new char[text.Length];

            foreach (var c in normalizedString)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    span[i++] = c;
            }
            return new string(span.ToArray()).Normalize(NormalizationForm.FormC);
        }
        /// <summary>
        /// Remove diacritics and Lower string
        /// </summary>
        /// <param name="text">Text to remove diacritics and lower string</param>
        /// <returns>Text lowercase without diacritics</returns>
        public static string RemoveDiacriticsAndLower(this string text) => RemoveDiacritics(text).ToLowerInvariant();

        /// <summary>
        /// String starts with (no case)
        /// </summary>
        /// <param name="a">String to compare</param>
        /// <param name="b">Start expected</param>
        /// <returns>True if starts</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool StartsWithNoCase(this string a, string b)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            return a.StartsWith(b, StringComparison.OrdinalIgnoreCase);
        }
        /// <summary>
        /// String ends with (no case)
        /// </summary>
        /// <param name="a">String to compare</param>
        /// <param name="b">End expected</param>
        /// <returns>True if ends</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool EnsWithNoCase(this string a, string b)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            return a.EndsWith(b, StringComparison.OrdinalIgnoreCase);
        }
        /// <summary>
        /// Equals no case
        /// </summary>
        /// <param name="a">First string</param>
        /// <param name="b">Second string</param>
        /// <returns>True if equals (no case)</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool EqualsNoCase(this string a, string b)
        {
            if (a == null && b == null) return true;
            if (a == null || b == null) return false;
            return a.Equals(b, StringComparison.OrdinalIgnoreCase);
        }

    }
}