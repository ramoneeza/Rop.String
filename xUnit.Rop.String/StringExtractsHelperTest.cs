using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rop.String;
using Xunit;

namespace xUnit.Rop.String
{
    public class StringExtractsHelperTest
    {
        [Fact]
        public void TryExtractsHelper()
        {
            var str = "El murciélago comía Pingüino y Ñandú... ¡Açucar!";
            var str2 = "el murciélago";
            var expected = " comía Pingüino y Ñandú... ¡Açucar!";
            var res = str.TryExtract(str2,null,StringComparison.OrdinalIgnoreCase,out var resstr);
            Assert.True(res);
            Assert.Equal(expected, resstr);
        }
        [Fact]
        public void TryExtractsHelper2()
        {
            var str = "El murciélago comía Pingüino y Ñandú... ¡Açucar!";
            var str2 = "el murciélago";
            var str3 = "¡açucar!";
            var expected = " comía Pingüino y Ñandú... ";
            var res = str.TryExtract(str2, str3, StringComparison.OrdinalIgnoreCase, out var resstr);
            Assert.True(res);
            Assert.Equal(expected, resstr);
        }
        [Fact]
        public void TryExtractsHelper3()
        {
            var str = "El murciélago comía Pingüino y Ñandú... ¡Açucar!";
            var str2 = "el murciélago";
            var str3 = "¡açucar!";
            var expected = "comía Pingüino y Ñandú...";
            var res = str.TryExtract(str2, str3,true, StringComparison.OrdinalIgnoreCase, out var resstr);
            Assert.True(res);
            Assert.Equal(expected, resstr);
        }
        [Fact]
        public void TryExtractsNoCaseHelper()
        {
            var str = "El murciélago comía Pingüino y Ñandú... ¡Açucar!";
            var str2 = "EL MURCIÉLAGO";
            var str3 = "¡açucar!";
            var expected = " comía Pingüino y Ñandú... ";
            var res = str.TryExtractNoCase(str2, str3, out var resstr);
            Assert.True(res);
            Assert.Equal(expected, resstr);
        }
        [Fact]
        public void TryExtractsNoCaseHelper2()
        {
            var str = "El murciélago comía Pingüino y Ñandú... ¡Açucar!";
            var str2 = "EL MURCIÉLAGO";
            var str3 = "¡açucar!";
            var expected = "comía Pingüino y Ñandú...";
            var res = str.TryExtractNoCase(str2, str3,true, out var resstr);
            Assert.True(res);
            Assert.Equal(expected, resstr);
        }
    }
}
