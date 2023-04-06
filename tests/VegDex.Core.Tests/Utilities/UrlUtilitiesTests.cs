using VegDex.Core.Utilities;

namespace VegDex.Application.Tests.Utilities;

[TestClass]
public class UrlUtilitiesTests
{
    [DataTestMethod]
    [DataRow("St. Paul", "st-paul")]
    [DataRow("Hopkins", "hopkins")]
    [DataRow("O'Fallon", "ofallon")]
    [DataRow("Dover-Foxcroft", "dover-foxcroft")]
    public void ToUrlSlug(string input, string expected)
    {
        Assert.AreEqual(expected, input.ToUrlSlug());
    }
}
