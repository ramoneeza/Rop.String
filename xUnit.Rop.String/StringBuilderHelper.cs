using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rop.String;
using Xunit;

namespace xUnit.Rop.String
{
    public class StringBuilderHelper
    {
        [Fact]
        public void AppendUnixLineTest1()
        {
            var expected = "hola\n";
            var sb = new StringBuilder();
            sb.AppendUnixLine("hola");
            Assert.Equal(expected,sb.ToString());
        }
        [Fact]
        public void AppendUnixLineTest2()
        {
            var expected = "hola\n";
            var sb = new StringBuilder();
            sb.Append("hola");
            sb.AppendUnixLine();
            Assert.Equal(expected, sb.ToString());
        }
    }
}
