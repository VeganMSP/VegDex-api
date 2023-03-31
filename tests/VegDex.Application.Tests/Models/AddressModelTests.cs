namespace VegDex.Application.Tests.Models;

[TestClass]
public class AddressModelTests
{
    [TestInitialize]
    public void Init()
    {
        _address = new AddressModel
        {
            City = new CityModel
            {
                Name = "Saint Paul"
            }
        };
    }
    private static AddressModel? _address;
    [TestMethod]
    public void Address_HasProperties()
    {
        // Arrange
        var obj = new AddressModel();

        // Assert
        Assert.AreEqual(9, obj.PropertyCount());
        Assert.IsTrue(obj.HasProperty("City"));
        Assert.IsTrue(obj.HasProperty("DateCreated"));
        Assert.IsTrue(obj.HasProperty("DateUpdated"));
        Assert.IsTrue(obj.HasProperty("Id"));
        Assert.IsTrue(obj.HasProperty("Name"));
        Assert.IsTrue(obj.HasProperty("State"));
        Assert.IsTrue(obj.HasProperty("Street1"));
        Assert.IsTrue(obj.HasProperty("Street2"));
        Assert.IsTrue(obj.HasProperty("ZipCode"));
    }
    [TestMethod]
    public void Address_ToString_City()
    {
        // Arrange
        var expected = "Saint Paul";

        // Assert
        Assert.AreEqual(expected, _address.ToString());
    }
    [TestMethod]
    public void Address_ToString_Name()
    {
        // Arrange
        _address.Name = "Home";
        var expected = "Home";

        // Assert
        Assert.AreEqual(expected, _address.ToString());
    }
    [TestMethod]
    public void Address_ToString_Street1()
    {
        // Arrange
        _address.Street1 = "1234 Summit Ave";
        var expected = "1234 Summit Ave";

        // Assert
        Assert.AreEqual(expected, _address.ToString());
    }
}
