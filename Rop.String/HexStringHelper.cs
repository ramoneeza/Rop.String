using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rop.String
{
    /// <summary>
    /// Helper classes for Hexadecimal Strings
    /// </summary>
    public static class HexStringHelper
    {
        /// <summary>
        /// Unicode string to Hex (WideChar)
        /// </summary>
        /// <param name="str">Unicode string to encode</param>
        /// <returns>Hex string</returns>
        public static string ToHexStringW(this string str)
        {
            var sb = new StringBuilder();
            var bytes = Encoding.Unicode.GetBytes(str);
            foreach (var t in bytes)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }
        /// <summary>
        /// Hex to Unicode String (Wide)
        /// </summary>
        /// <param name="hexString">Hex String</param>
        /// <returns>Unicode string</returns>
        public static string FromHexStringW(this string hexString)
        {
            if (hexString.StartsWithNoCase("0x")) hexString = hexString.Substring(2);
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return Encoding.Unicode.GetString(bytes);
        }
        /// <summary>
        /// Ascii String to Hex (Byte char)
        /// </summary>
        /// <param name="str">Ascii String</param>
        /// <returns>Hex String</returns>
        public static string ToHexString(this string str)
        {
            var sb = new StringBuilder();

            var bytes = Encoding.ASCII.GetBytes(str);
            foreach (var t in bytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString();
        }
        /// <summary>
        /// Hex String to Ascii String
        /// </summary>
        /// <param name="hexString">Hex String</param>
        /// <returns>Ascii String</returns>
        public static string FromHexString(this string hexString)
        {
            if (hexString.StartsWithNoCase("0x")) hexString = hexString.Substring(2);
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return Encoding.ASCII.GetString(bytes);
        }
    }
}
