namespace VegDex.Application.Tests.Models;

[TestClass]
public class LinkCategoryModelTests
{
    [TestMethod]
    public void LinkCategory_HasProperties()
    {
        // Arrange
        var obj = new LinkCategoryModel();

        // Assert
        Assert.AreEqual(7, obj.PropertyCount());
        Assert.IsTrue(obj.HasProperty("DateCreated"));
        Assert.IsTrue(obj.HasProperty("DateUpdated"));
        Assert.IsTrue(obj.HasProperty("Description"));
        Assert.IsTrue(obj.HasProperty("Id"));
        Assert.IsTrue(obj.HasProperty("Name"));
        Assert.IsTrue(obj.HasProperty("Slug"));
        Assert.IsTrue(obj.HasProperty("Links"));
    }
    [TestMethod]
    public void LinkCategory_ToString_Name()
    {
        // Arrange
        var obj = new LinkCategoryModel
        {
            Name = "Other Information Sites"
        };
        var expected = "Other Information Sites";

        // Assert
        Assert.AreEqual(expected, obj.ToString());
    }
}
