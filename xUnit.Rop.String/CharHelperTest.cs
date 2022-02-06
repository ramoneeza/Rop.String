using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rop.String;
using Xunit;

namespace xUnit.Rop.String
{
    public class CharHelperTest
    {
        [Fact]
        public void IsEqualCaseTest()
        {
            Assert.True('a'.IsEqualCase('a'));
            Assert.True('b'.IsEqualCase('B', true));
            Assert.True('ñ'.IsEqualCase('Ñ',true));
            Assert.True('á'.IsEqualCase('Á', true));
        }
        [Fact]
        public void InRangeTest()
        {
            var lst1 = "abcdeáéíóúñ";
            Assert.True('b'.InRange(lst1));
            Assert.True('í'.InRange(lst1));
            Assert.True('ñ'.InRange(lst1));

            Assert.True('B'.InRange(lst1,true));
            Assert.True('Í'.InRange(lst1,true));
            Assert.True('Ñ'.InRange(lst1,true));

        }
        [Fact]
        public void NotInRangeTest()
        {
            var lst1 = "abcdeáéíóúñ";
            Assert.True('z'.NotInRange(lst1));

            Assert.False('b'.NotInRange(lst1));
            Assert.False('í'.NotInRange(lst1));
            Assert.False('ñ'.NotInRange(lst1));
            Assert.False('B'.NotInRange(lst1, true));
            Assert.False('Í'.NotInRange(lst1, true));
            Assert.False('Ñ'.NotInRange(lst1, true));
        }
        [Fact]
        public void RangeCharTest()
        {
            var expected = "abcdefg";
            var lst = CharHelper.RangeChar('a', 'g');
            Assert.Equal(expected.ToCharArray(),lst);
        }
        [Fact]
        public void RangeCharTest2()
        {
            var expected = "abcdefg";
            var lst = CharHelper.RangeChar('a', 7);
            Assert.Equal(expected.ToCharArray(), lst);
        }
        [Fact]
        public void TrimBlanksTest()
        {
            var str = "\n\rhola\t ";
            Assert.Equal("hola",str.TrimBlanks());
        }
        [Fact]
        public void TrimControlTest()
        {
            var str = "\x03\x04hola\t ";
            Assert.Equal("hola", str.TrimControl());
        }

    }
}
