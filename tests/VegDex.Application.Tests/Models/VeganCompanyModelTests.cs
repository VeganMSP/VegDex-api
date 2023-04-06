namespace VegDex.Application.Tests.Models;

[TestClass]
public class VeganCompanyModelTests
{
    [TestMethod]
    public void VeganCompany_HasProperties()
    {
        // Arrange
        var obj = new VeganCompanyModel();

        // Assert
        Assert.AreEqual(7, obj.PropertyCount());
        Assert.IsTrue(obj.HasProperty("DateCreated"));
        Assert.IsTrue(obj.HasProperty("DateUpdated"));
        Assert.IsTrue(obj.HasProperty("Description"));
        Assert.IsTrue(obj.HasProperty("Id"));
        Assert.IsTrue(obj.HasProperty("Name"));
        Assert.IsTrue(obj.HasProperty("Slug"));
        Assert.IsTrue(obj.HasProperty("Website"));
    }
    [TestMethod]
    public void VeganCompany_ToString_Name()
    {
        // Arrange
        var obj = new VeganCompanyModel
        {
            Name = "PLNT BSD"
        };
        var expected = "PLNT BSD";

        // Assert
        Assert.AreEqual(expected, obj.ToString());
    }
}
