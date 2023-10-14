using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using VegDex.Application.Models;
using VegDex.Web.API.Controllers;
using VegDex.Web.API.Interfaces;
using VegDex.Web.API.ViewModels;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace VegDex.Web.API.Tests.Controllers;

[TestClass]
public class BlogControllerTests
{
    [TestInitialize]
    public void Init()
    {
        _mockService = new Mock<IBlogPageService>();
        _controller = new BlogController(_mockService.Object);
    }
    [TestCleanup]
    public void Cleanup()
    {
        _controller.Dispose();
    }
    private BlogController _controller;
    private Mock<IBlogPageService> _mockService;
    [TestMethod]
    public void BlogCategoryIndex_Results_success()
    {
        // Arrange
        var ret = new[]
        { new BlogCategoryViewModel
          { Name = "Local",
            Slug = "local" } };

        _mockService.Setup(x => x.GetBlogCategories()).ReturnsAsync(ret);

        // Act
        var result = _controller.BlogCategoriesIndex();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is BlogCategoryViewModel[]);
        Assert.IsTrue(result.Any());
    }
    [TestMethod]
    public void BlogCategoryIndex_ZeroResults_success()
    {
        // Arrange

        // Act
        var result = _controller.BlogCategoriesIndex();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is BlogCategoryViewModel[]);
    }
    [TestMethod]
    public void Create_fail()
    {
        // Arrange
        BlogPostModel blogPostModel = null!;

        _controller.ModelState.AddModelError("testError", "testError");

        // Act
        var result = _controller.Create(blogPostModel);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is StatusCodeResult);
        Assert.IsTrue(result.StatusCode is (int)HttpStatusCode.BadRequest);
    }
    [TestMethod]
    public void Create_success()
    {
        // Arrange
        BlogPostModel blogPostModel = null!;

        // Act
        var result = _controller.Create(blogPostModel);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is OkResult);
    }
    [TestMethod]
    public void CreateBlogCategory_fail()
    {
        // Arrange
        BlogCategoryModel blogCategoryModel = null!;

        _controller.ModelState.AddModelError("testError", "testError");

        // Act
        var result = _controller.CreateBlogCategory(blogCategoryModel);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is StatusCodeResult);
        Assert.IsTrue(result.StatusCode is (int)HttpStatusCode.BadRequest);
    }
    [TestMethod]
    public void CreateBlogCategory_success()
    {
        // Arrange
        BlogCategoryModel blogCategoryModel = null!;

        // Act
        var result = _controller.CreateBlogCategory(blogCategoryModel);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is OkResult);
    }
    [TestMethod]
    public void Delete_Null_Id_Returns_NotFound()
    {
        // Arrange
        int? id = null;

        // Act
        var result = _controller.DeleteConfirmed(id);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is NotFoundResult);
    }
    [TestMethod]
    public void Delete_Null_Post_Returns_NotFound()
    {
        // Arrange
        int? id = 1;

        _mockService.Setup(x => x.GetBlogPostById(It.IsAny<int>())).ReturnsAsync((BlogPostModel)null!);

        // Act
        var result = _controller.DeleteConfirmed(id);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is NotFoundResult);
    }
    [TestMethod]
    public void Delete_Success()
    {
        // Arrange
        int? id = 1;

        _mockService.Setup(x => x.GetBlogPostById(It.IsAny<int>())).ReturnsAsync(new BlogPostModel());

        // Act
        var result = _controller.DeleteConfirmed(id);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is OkResult);
    }
    [TestMethod]
    public void DeleteBlogCategory_Null_BlogCategory_Returns_NotFound()
    {
        // Arrange
        int? id = 1;

        _mockService.Setup(x => x.GetBlogCategoryById(It.IsAny<int>())).ReturnsAsync((BlogCategoryModel)null!);

        // Act
        var result = _controller.DeleteBlogCategoryConfirmed(id);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is NotFoundResult);
    }
    [TestMethod]
    public void DeleteBlogCategory_Null_Id_Returns_NotFound()
    {
        // Arrange
        int? id = null;

        // Act
        var result = _controller.DeleteBlogCategoryConfirmed(id);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is NotFoundResult);
    }
    [TestMethod]
    public void DeleteBlogCategory_Success()
    {
        // Arrange
        int? id = 1;

        _mockService.Setup(x => x.GetBlogCategoryById(It.IsAny<int>())).ReturnsAsync(new BlogCategoryModel());

        // Act
        var result = _controller.DeleteBlogCategoryConfirmed(id);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is OkResult);
    }
    [TestMethod]
    public void Edit_Returns_BadRequest()
    {
        // Arrange
        int? id = 1;
        var ret = new BlogPostModel
        { Id = id.Value };

        _controller.ModelState.AddModelError("testError", "testError");

        // Act
        var result = _controller.Edit(id, ret);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is BadRequestResult);
    }
    [TestMethod]
    public void Edit_Returns_NotFound()
    {
        // Arrange
        int? id = 1;
        var ret = new BlogPostModel
        { Id = 12 };

        // Act
        var result = _controller.Edit(id, ret);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is NotFoundResult);
    }
    [TestMethod]
    public void Edit_Success()
    {
        // Arrange
        int? id = 1;
        var ret = new BlogPostModel
        { Id = id.Value };

        // Act
        var result = _controller.Edit(id, ret);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is OkResult);
    }
    [TestMethod]
    public void Edit_Throws_DbConcurrency_Exception_Returns_NotFound()
    {
        // Arrange
        int? id = 1;
        var ret = new BlogPostModel
        { Id = id.Value };

        _mockService.Setup(x => x.UpdateBlogPost(It.IsAny<BlogPostModel>())).Throws<DbUpdateConcurrencyException>();
        _mockService.Setup(x => x.GetBlogPostById(It.IsAny<int>())).ReturnsAsync((BlogPostModel)null!);

        // Act
        var result = _controller.Edit(id, ret);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is NotFoundResult);
    }
    [TestMethod]
    [ExpectedException(typeof(DbUpdateConcurrencyException))]
    public void Edit_Throws_DbConcurrency_Exception_Throws()
    {
        // Arrange
        int? id = 1;
        var ret = new BlogPostModel
        { Id = id.Value };

        _mockService.Setup(x => x.UpdateBlogPost(It.IsAny<BlogPostModel>())).Throws<DbUpdateConcurrencyException>();
        _mockService.Setup(x => x.GetBlogPostById(It.IsAny<int>())).ReturnsAsync(new BlogPostModel());

        // Act
        var result = _controller.Edit(id, ret);

        // Assert - Exception
    }
    [TestMethod]
    public void EditBlogCategory_Id_Mismatch_Returns_NotFound()
    {
        // Arrange
        int? id = 1;
        var ret = new BlogCategoryModel
        { Id = 12 };

        // Act
        var result = _controller.EditBlogCategory(id, ret);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is NotFoundResult);
    }
    [TestMethod]
    public void EditBlogCategory_Returns_BadRequest()
    {
        // Arrange
        int? id = 1;
        var ret = new BlogCategoryModel
        { Id = id.Value };

        _controller.ModelState.AddModelError("testError", "testError");

        // Act
        var result = _controller.EditBlogCategory(id, ret);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is BadRequestResult);
    }
    [TestMethod]
    public void EditBlogCategory_Success()
    {
        // Arrange
        int? id = 1;
        var ret = new BlogCategoryModel
        { Id = id.Value };

        // Act
        var result = _controller.EditBlogCategory(id, ret);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is OkResult);
    }
    [TestMethod]
    public void EditBlogCategory_Throws_DbConcurrency_Exception_Returns_NotFound()
    {
        // Arrange
        int? id = 1;
        var ret = new BlogCategoryModel
        { Id = id.Value };

        _mockService.Setup(x => x.UpdateBlogCategory(It.IsAny<BlogCategoryModel>()))
            .Throws<DbUpdateConcurrencyException>();
        _mockService.Setup(x => x.GetBlogCategoryById(It.IsAny<int>())).ReturnsAsync((BlogCategoryModel)null!);

        // Act
        var result = _controller.EditBlogCategory(id, ret);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is NotFoundResult);
    }
    [TestMethod]
    [ExpectedException(typeof(DbUpdateConcurrencyException))]
    public void EditBlogCategory_Throws_DbConcurrency_Exception_Throws()
    {
        // Arrange
        int? id = 1;
        var ret = new BlogCategoryModel
        { Id = id.Value };

        _mockService.Setup(x => x.UpdateBlogCategory(It.IsAny<BlogCategoryModel>()))
            .Throws<DbUpdateConcurrencyException>();
        _mockService.Setup(x => x.GetBlogCategoryById(It.IsAny<int>())).ReturnsAsync(new BlogCategoryModel());

        // Act
        var result = _controller.EditBlogCategory(id, ret);

        // Assert - Exception
    }
    [TestMethod]
    public void Index_ZeroResults_success()
    {
        // Arrange

        // Act
        var result = _controller.Index();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is BlogViewModel);
    }
}
