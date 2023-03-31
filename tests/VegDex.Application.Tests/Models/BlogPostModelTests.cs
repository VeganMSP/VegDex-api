namespace VegDex.Application.Tests.Models;

[TestClass]
public class BlogPostModelTests
{
    [TestInitialize]
    public void Init()
    {
        _blogCategory = new BlogCategoryModel
        {
            Name = "Announcements"
        };
    }
    private static BlogCategoryModel? _blogCategory;
    [TestMethod]
    public void BlogPost_HasProperties()
    {
        // Arrange
        var obj = new BlogPostModel();

        // Assert
        Assert.AreEqual(8, obj.PropertyCount());
        Assert.IsTrue(obj.HasProperty("Category"));
        Assert.IsTrue(obj.HasProperty("Content"));
        Assert.IsTrue(obj.HasProperty("DateCreated"));
        Assert.IsTrue(obj.HasProperty("DateUpdated"));
        Assert.IsTrue(obj.HasProperty("Id"));
        Assert.IsTrue(obj.HasProperty("Slug"));
        Assert.IsTrue(obj.HasProperty("Status"));
        Assert.IsTrue(obj.HasProperty("Title"));
    }
}
