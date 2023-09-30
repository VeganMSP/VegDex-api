namespace VegDex.Application.Tests.Models;

[TestClass]
public class BlogCategoryModelTests
{
    [TestMethod]
    public void BlogCategory_HasProperties()
    {
        // Arrange
        var obj = new BlogCategoryModel();

        // Assert
        Assert.AreEqual(5, obj.PropertyCount());
        Assert.IsTrue(obj.HasProperty("DateCreated"));
        Assert.IsTrue(obj.HasProperty("DateUpdated"));
        Assert.IsTrue(obj.HasProperty("Id"));
        Assert.IsTrue(obj.HasProperty("Name"));
        Assert.IsTrue(obj.HasProperty("Slug"));
    }
    [TestMethod]
    public void BlogCategory_ToString_Name()
    {
        // Arrange
        var obj = new BlogCategoryModel
        { Name = "Announcements" };
        var expected = "Announcements";

        // Assert
        Assert.AreEqual(expected, obj.ToString());
    }
}
