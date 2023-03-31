namespace VegDex.Application.Tests.Models;

[TestClass]
public class LinkModelTests
{
    [TestInitialize]
    public void Init()
    {
        _linkCategory = new LinkCategory
        {
            Name = "Local Organizations"
        };
    }
    private static LinkCategory _linkCategory;
    [TestMethod]
    public void Link_HasProperties()
    {
        // Arrange
        var obj = new Link();

        // Assert
        Assert.AreEqual(8, obj.PropertyCount());
        Assert.IsTrue(obj.HasProperty("Category"));
        Assert.IsTrue(obj.HasProperty("DateCreated"));
        Assert.IsTrue(obj.HasProperty("DateUpdated"));
        Assert.IsTrue(obj.HasProperty("Description"));
        Assert.IsTrue(obj.HasProperty("Id"));
        Assert.IsTrue(obj.HasProperty("Name"));
        Assert.IsTrue(obj.HasProperty("Slug"));
        Assert.IsTrue(obj.HasProperty("Website"));
    }
    [TestMethod]
    public void Link_ToString_Name()
    {
        // Arrange
        var obj = new Link{Name = "Animal Rights Coalition", Category = _linkCategory};
        var expected = "Animal Rights Coalition";

        // Assert
        Assert.AreEqual(expected, obj.ToString());
    }
}
