using Rop.String;
using Xunit;

namespace xUnit.Rop.String
{
    public class StringCaseHelperTest
    {
        [Fact]
        public void RemoveDiacriticsTest1()
        {
            var str = "El murciélago comía Pingüino y Ñandú... ¡Açucar!";
            var expected = "El murcielago comia Pinguino y Nandu... ¡Acucar!";
            var str2 = str.RemoveDiacritics();
            Assert.Equal(expected, str2);
        }
        [Fact]
        public void RemoveDiacriticsAndLowerTest1()
        {
            var str = "El murciélago comía Pingüino y Ñandú... ¡Açucar!";
            var expected = "el murcielago comia pinguino y nandu... ¡acucar!";
            var str2 = str.RemoveDiacriticsAndLower();
            Assert.Equal(expected, str2);
        }
        [Fact]
        public void StartsWithNoCaseTest1()
        {
            var str1 = "EL MURCIÉLAGO COMÍA PINGÜINO Y ÑANDÚ... ¡AÇUCAR! y sigo...";
            var str2 = "el murciélago comía pingüino y ñandú... ¡açucar!";
            var str3 = "el murcielago comia pinguino y ñandu... ¡açucar!";

            Assert.True(str1.StartsWithNoCase(str2));
            Assert.False(str1.StartsWithNoCase(str3));

        }
        [Fact]
        public void EndsWithNoCaseTest1()
        {
            var str1 = "ANTES EL MURCIÉLAGO COMÍA PINGÜINO Y ÑANDÚ... ¡AÇUCAR!";
            var str2 = "el murciélago comía pingüino y ñandú... ¡açucar!";
            var str3 = "el murcielago comia pinguino y ñandu... ¡açucar!";

            Assert.True(str1.EnsWithNoCase(str2));
            Assert.False(str1.EnsWithNoCase(str3));

        }
        [Fact]
        public void EqualsNoCaseTest1()
        {
            var str1 = "EL MURCIÉLAGO COMÍA PINGÜINO Y ÑANDÚ... ¡AÇUCAR!";
            var str2 = "el murciélago comía pingüino y ñandú... ¡açucar!";
            var str3 = "el murcielago comia pinguino y ñandu... ¡açucar!";

            Assert.True(str1.EqualsNoCase(str2));
            Assert.False(str1.EqualsNoCase(str3));

        }
    }
}