using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Rop.String;
using Xunit;

namespace xUnit.Rop.String
{
    public class StringTokenHelper
    {
        [Fact]
        public void SymbolInPosTest()
        {
            var cad = "5!=4";
            var s = cad.SymbolInPos(1, "==", "!=", "<>");
            Assert.Equal("!=",s);
            var s2= cad.SymbolInPos(1, "$%", "&&", "||");
            Assert.True(s2=="");
        }
        [Fact]
        public void GetTokenTest()
        {
            var cad = "<DIV>Hola</DIV>";
            var t = StringToken.GetToken(new []{"<i>", "<div>", "<span>"}, ref cad, true);
            Assert.Equal("<div>",t);
            Assert.Equal("Hola</DIV>",cad);
        }
        [Fact]
        public void ContainsCaseTest()
        {
            var cad = "<DIV>HOLA</DIV>";
            var t = cad.ContainsCase("hola", true);
            Assert.True(t);
        }
    }
}
