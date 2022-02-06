using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rop.String;
using Xunit;

namespace xUnit.Rop.String
{
    public class HexStringTest
    {
        [Fact]
        public void FromToHexStringTest()
        {
            var cad = "hola";
            var hexcad = cad.ToHexString();
            var back = hexcad.FromHexString();
            Assert.Equal(cad,back);
        }
        [Fact]
        public void FromToHexStringWTest()
        {
            var cad = "hola cántaro";
            var hexcad = cad.ToHexStringW();
            var back = hexcad.FromHexStringW();
            Assert.Equal(cad, back);
        }

    }
}
