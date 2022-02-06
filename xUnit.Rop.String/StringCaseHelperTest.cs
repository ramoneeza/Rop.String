using Rop.String;
using Xunit;

namespace xUnit.Rop.String
{
    public class StringCaseHelperTest
    {
        [Fact]
        public void RemoveDiacriticsTest1()
        {
            var str = "El murci�lago com�a Ping�ino y �and�... �A�ucar!";
            var expected = "El murcielago comia Pinguino y Nandu... �Acucar!";
            var str2 = str.RemoveDiacritics();
            Assert.Equal(expected, str2);
        }
        [Fact]
        public void RemoveDiacriticsAndLowerTest1()
        {
            var str = "El murci�lago com�a Ping�ino y �and�... �A�ucar!";
            var expected = "el murcielago comia pinguino y nandu... �acucar!";
            var str2 = str.RemoveDiacriticsAndLower();
            Assert.Equal(expected, str2);
        }
        [Fact]
        public void StartsWithNoCaseTest1()
        {
            var str1 = "EL MURCI�LAGO COM�A PING�INO Y �AND�... �A�UCAR! y sigo...";
            var str2 = "el murci�lago com�a ping�ino y �and�... �a�ucar!";
            var str3 = "el murcielago comia pinguino y �andu... �a�ucar!";

            Assert.True(str1.StartsWithNoCase(str2));
            Assert.False(str1.StartsWithNoCase(str3));

        }
        [Fact]
        public void EndsWithNoCaseTest1()
        {
            var str1 = "ANTES EL MURCI�LAGO COM�A PING�INO Y �AND�... �A�UCAR!";
            var str2 = "el murci�lago com�a ping�ino y �and�... �a�ucar!";
            var str3 = "el murcielago comia pinguino y �andu... �a�ucar!";

            Assert.True(str1.EnsWithNoCase(str2));
            Assert.False(str1.EnsWithNoCase(str3));

        }
        [Fact]
        public void EqualsNoCaseTest1()
        {
            var str1 = "EL MURCI�LAGO COM�A PING�INO Y �AND�... �A�UCAR!";
            var str2 = "el murci�lago com�a ping�ino y �and�... �a�ucar!";
            var str3 = "el murcielago comia pinguino y �andu... �a�ucar!";

            Assert.True(str1.EqualsNoCase(str2));
            Assert.False(str1.EqualsNoCase(str3));

        }
    }
}