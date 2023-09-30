namespace VegDex.Application.Tests.Models;

[TestClass]
public class FarmersMarketModelTests
{
    [TestInitialize]
    public void Init() { }
    [TestMethod]
    public void FarmersMarket_HasProperties()
    {
        // Arrange
        var obj = new FarmersMarketModel();

        // Assert
        Assert.AreEqual(9, obj.PropertyCount());
        Assert.IsTrue(obj.HasProperty("Address"));
        Assert.IsTrue(obj.HasProperty("DateCreated"));
        Assert.IsTrue(obj.HasProperty("DateUpdated"));
        Assert.IsTrue(obj.HasProperty("Hours"));
        Assert.IsTrue(obj.HasProperty("Id"));
        Assert.IsTrue(obj.HasProperty("Name"));
        Assert.IsTrue(obj.HasProperty("Phone"));
        Assert.IsTrue(obj.HasProperty("Slug"));
        Assert.IsTrue(obj.HasProperty("Website"));
    }
    [TestMethod]
    public void FarmersMarket_ToString_Name()
    {
        // Arrange
        var obj = new FarmersMarketModel
        { Name = "Hopkins Winter Farmers Market",
          Address = "Hopkins" };
        var expected = "Hopkins Winter Farmers Market";

        // Assert
        Assert.AreEqual(expected, obj.ToString());
    }
}
