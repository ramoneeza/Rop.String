using System.Text;

namespace Rop.String
{
    /// <summary>
    /// Helper for StringBuilder
    /// </summary>
    public static class StringBuilderHelper
    {
        /// <summary>
        /// Append Line with linux end of line
        /// </summary>
        /// <param name="std"></param>
        /// <param name="value">Line to append</param>
        /// <returns></returns>
        public static StringBuilder AppendUnixLine(this StringBuilder std, string value)
        {
            std.Append(value);
            return std.Append('\n');
        }
        /// <summary>
        /// Append linux end of line
        /// </summary>
        /// <param name="std"></param>
        /// <returns></returns>
        public static StringBuilder AppendUnixLine(this StringBuilder std)
        {
            return std.Append('\n');
        }
    }
}