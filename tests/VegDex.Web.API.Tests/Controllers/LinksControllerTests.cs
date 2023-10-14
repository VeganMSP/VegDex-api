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
public class LinksControllerTests
{
    [TestInitialize]
    public void Init()
    {
        _mockService = new Mock<ILinksPageService>();
        _controller = new LinksController(_mockService.Object);
    }
    [TestCleanup]
    public void Cleanup()
    {
        _controller.Dispose();
    }
    private LinksController _controller;
    private Mock<ILinksPageService> _mockService;
    [TestMethod]
    public void Create_fail()
    {
        // Arrange
        LinkModel linkModel = null!;

        _controller.ModelState.AddModelError("testError", "testError");

        // Act
        var result = _controller.Create(linkModel);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is StatusCodeResult);
        Assert.IsTrue(result.StatusCode is (int)HttpStatusCode.BadRequest);
    }
    [TestMethod]
    public void Create_success()
    {
        // Arrange
        LinkModel linkModel = null!;

        // Act
        var result = _controller.Create(linkModel);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is OkResult);
    }
    [TestMethod]
    public void CreateLinkCategory_fail()
    {
        // Arrange
        LinkCategoryModel linkCategoryModel = null!;

        _controller.ModelState.AddModelError("testError", "testError");

        // Act
        var result = _controller.CreateLinkCategory(linkCategoryModel);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is StatusCodeResult);
        Assert.IsTrue(result.StatusCode is (int)HttpStatusCode.BadRequest);
    }
    [TestMethod]
    public void CreateLinkCategory_success()
    {
        // Arrange
        LinkCategoryModel linkCategoryModel = null!;

        // Act
        var result = _controller.CreateLinkCategory(linkCategoryModel);

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

        _mockService.Setup(x => x.GetLinkById(It.IsAny<int>())).ReturnsAsync((LinkModel)null!);

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

        _mockService.Setup(x => x.GetLinkById(It.IsAny<int>())).ReturnsAsync(new LinkModel());

        // Act
        var result = _controller.DeleteConfirmed(id);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is OkResult);
    }
    [TestMethod]
    public void DeleteLinkCategory_Null_Id_Returns_NotFound()
    {
        // Arrange
        int? id = null;

        // Act
        var result = _controller.DeleteLinkCategoryConfirmed(id);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is NotFoundResult);
    }
    [TestMethod]
    public void DeleteLinkCategory_Null_LinkCategory_Returns_NotFound()
    {
        // Arrange
        int? id = 1;

        _mockService.Setup(x => x.GetLinkCategoryById(It.IsAny<int>())).ReturnsAsync((LinkCategoryModel)null!);

        // Act
        var result = _controller.DeleteLinkCategoryConfirmed(id);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is NotFoundResult);
    }
    [TestMethod]
    public void DeleteLinkCategory_Success()
    {
        // Arrange
        int? id = 1;

        _mockService.Setup(x => x.GetLinkCategoryById(It.IsAny<int>())).ReturnsAsync(new LinkCategoryModel());

        // Act
        var result = _controller.DeleteLinkCategoryConfirmed(id);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is OkResult);
    }
    [TestMethod]
    public void Edit_Returns_BadRequest()
    {
        // Arrange
        int? id = 1;
        var ret = new LinkModel
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
        var ret = new LinkModel
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
        var ret = new LinkModel
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
        var ret = new LinkModel
        { Id = id.Value };

        _mockService.Setup(x => x.UpdateLink(It.IsAny<LinkModel>())).Throws<DbUpdateConcurrencyException>();
        _mockService.Setup(x => x.GetLinkById(It.IsAny<int>())).ReturnsAsync((LinkModel)null!);

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
        var ret = new LinkModel
        { Id = id.Value };

        _mockService.Setup(x => x.UpdateLink(It.IsAny<LinkModel>())).Throws<DbUpdateConcurrencyException>();
        _mockService.Setup(x => x.GetLinkById(It.IsAny<int>())).ReturnsAsync(new LinkModel());

        // Act
        var result = _controller.Edit(id, ret);

        // Assert - Exception
    }
    [TestMethod]
    public void EditLinkCategory_Id_Mismatch_Returns_NotFound()
    {
        // Arrange
        int? id = 1;
        var ret = new LinkCategoryModel
        { Id = 12 };

        // Act
        var result = _controller.EditLinkCategory(id, ret);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is NotFoundResult);
    }
    [TestMethod]
    public void EditLinkCategory_Returns_BadRequest()
    {
        // Arrange
        int? id = 1;
        var ret = new LinkCategoryModel
        { Id = id.Value };

        _controller.ModelState.AddModelError("testError", "testError");

        // Act
        var result = _controller.EditLinkCategory(id, ret);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is BadRequestResult);
    }
    [TestMethod]
    public void EditLinkCategory_Success()
    {
        // Arrange
        int? id = 1;
        var ret = new LinkCategoryModel
        { Id = id.Value };

        // Act
        var result = _controller.EditLinkCategory(id, ret);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is OkResult);
    }
    [TestMethod]
    public void EditLinkCategory_Throws_DbConcurrency_Exception_Returns_NotFound()
    {
        // Arrange
        int? id = 1;
        var ret = new LinkCategoryModel
        { Id = id.Value };

        _mockService.Setup(x => x.UpdateLinkCategory(It.IsAny<LinkCategoryModel>()))
            .Throws<DbUpdateConcurrencyException>();
        _mockService.Setup(x => x.GetLinkCategoryById(It.IsAny<int>())).ReturnsAsync((LinkCategoryModel)null!);

        // Act
        var result = _controller.EditLinkCategory(id, ret);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is NotFoundResult);
    }
    [TestMethod]
    [ExpectedException(typeof(DbUpdateConcurrencyException))]
    public void EditLinkCategory_Throws_DbConcurrency_Exception_Throws()
    {
        // Arrange
        int? id = 1;
        var ret = new LinkCategoryModel
        { Id = id.Value };

        _mockService.Setup(x => x.UpdateLinkCategory(It.IsAny<LinkCategoryModel>()))
            .Throws<DbUpdateConcurrencyException>();
        _mockService.Setup(x => x.GetLinkCategoryById(It.IsAny<int>())).ReturnsAsync(new LinkCategoryModel());

        // Act
        var result = _controller.EditLinkCategory(id, ret);

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
        Assert.IsTrue(result is LinkViewModel);
    }
    [TestMethod]
    public void LinkCategoryIndex_Results_success()
    {
        // Arrange
        var ret = new[]
        { new LinkCategoryViewModel
          { Name = "Local",
            Slug = "local" } };

        _mockService.Setup(x => x.GetLinkCategories()).ReturnsAsync(ret);

        // Act
        var result = _controller.LinkCategoriesIndex();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is LinkCategoryViewModel[]);
        Assert.IsTrue(result.Any());
    }
    [TestMethod]
    public void LinkCategoryIndex_ZeroResults_success()
    {
        // Arrange

        // Act
        var result = _controller.LinkCategoriesIndex();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is LinkCategoryViewModel[]);
    }
}
