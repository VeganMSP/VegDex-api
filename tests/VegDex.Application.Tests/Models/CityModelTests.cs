namespace VegDex.Application.Tests.Models;

[TestClass]
public class CityModelTests
{
    [TestMethod]
    public void City_HasProperties()
    {
        // Arrange
        var obj = new City();

        // Assert
        Assert.AreEqual(5, obj.PropertyCount());
        Assert.IsTrue(obj.HasProperty("DateCreated"));
        Assert.IsTrue(obj.HasProperty("DateUpdated"));
        Assert.IsTrue(obj.HasProperty("Id"));
        Assert.IsTrue(obj.HasProperty("Name"));
        Assert.IsTrue(obj.HasProperty("Slug"));
    }
    [TestMethod]
    public void City_ToString_Name()
    {
        // Arrange
        var obj = new City{Name = "Hopkins"};
        var expected = "Hopkins";

        // Assert
        Assert.AreEqual(expected, obj.ToString());
    }
}
