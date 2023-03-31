namespace VegDex.Application.Tests.Models;

[TestClass]
public class RestaurantModelTests
{
    [TestInitialize]
    public void Init()
    {
        _city = new City
        {
            Name = "Vadnais Heights"
        };
    }
    private static City _city;
    [TestMethod]
    public void Restaurant_HasProperties()
    {
        // Arrange
        var obj = new Restaurant();

        // Assert
        Assert.AreEqual(9, obj.PropertyCount());
        Assert.IsTrue(obj.HasProperty("AllVegan"));
        Assert.IsTrue(obj.HasProperty("DateCreated"));
        Assert.IsTrue(obj.HasProperty("DateUpdated"));
        Assert.IsTrue(obj.HasProperty("Description"));
        Assert.IsTrue(obj.HasProperty("Id"));
        Assert.IsTrue(obj.HasProperty("Location"));
        Assert.IsTrue(obj.HasProperty("Name"));
        Assert.IsTrue(obj.HasProperty("Slug"));
        Assert.IsTrue(obj.HasProperty("Website"));
    }
    [TestMethod]
    public void Restaurant_ToString_Name()
    {
        // Arrange
        var obj = new Restaurant
        {
            Name = "Piggy Bank",
            Location = _city
        };
        var expected = "Piggy Bank";

        // Assert
        Assert.AreEqual(expected, obj.ToString());
    }
}
