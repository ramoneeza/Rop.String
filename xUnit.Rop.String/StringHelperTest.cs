using System;
using Rop.String;
using Xunit;
namespace xUnit.Rop.String;

public class StringHelperTest
{
    [Fact]
    public void StartsWithTest()
    {
        var str1 = "El murciélago comía Pingüinos y Ñandú";
        var str2 = "el murciélago";
        var r = str1.StartsWith(str2, StringComparison.OrdinalIgnoreCase, out var index);
        Assert.True(r);
        Assert.Equal(str2.Length,index);
    }

    [Fact]
    public void EndsWithTest()
    {
        var str1 = "El murciélago comía Pingüinos y Ñandú";
        var str2 = "ñandú";
        var expected = "El murciélago comía Pingüinos y ";
        var r = str1.EndsWith(str2, StringComparison.OrdinalIgnoreCase, out var index);
        var expectedindex = str1.Length - str2.Length;
        Assert.True(r);
        Assert.Equal(expectedindex, index);
        Assert.Equal(expected,str1.Substring(0,index));
    }

    [Fact]
    public void StartsAndEndsWithTest()
    {
        var str1 = "El murciélago comía Pingüinos y Ñandú";
        var str2 = "el murciélago";
        var str3 = "ñandú";
        var expectedto = str1.Length - str3.Length;
        var expectedfrom = str2.Length;
        var expected = " comía Pingüinos y ";
        var r = str1.StartsAndEndsWith(str2,str3, StringComparison.OrdinalIgnoreCase, out var from,out var to);
        Assert.True(r);
        Assert.Equal(expectedfrom, from);
        Assert.Equal(expectedto,to);
        Assert.Equal(expected,str1.Substring(from,to-from));
    }
}