using System.Net;
using Microsoft.AspNetCore.Mvc;
using Moq;
using VegDex.Web.API.Controllers;
using VegDex.Web.API.Interfaces;
using VegDex.Web.API.ViewModels.Meta;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace VegDex.Web.API.Tests.Controllers;

[TestClass]
public class MetaControllerTests
{
    [TestInitialize]
    public void Init()
    {
        _mockService = new Mock<IMetaPageService>();
        _controller = new MetaController(_mockService.Object);
    }
    [TestCleanup]
    public void Cleanup()
    {
        _controller.Dispose();
    }
    private MetaController _controller;
    private Mock<IMetaPageService> _mockService;
    [TestMethod]
    public void About_success()
    {
        // Arrange

        _mockService.Setup(x => x.GetAboutPage()).ReturnsAsync(new AboutPageViewModel());

        // Act
        var result = _controller.About();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is AboutPageViewModel);
    }
    [TestMethod]
    public void EditAboutPage_Returns_BadRequest()
    {
        // Arrange
        var ret = new AboutPageViewModel();

        _controller.ModelState.AddModelError("testError", "testError");

        // Act
        var result = _controller.EditAboutPage(ret);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is StatusCodeResult);
        Assert.AreEqual((int)HttpStatusCode.BadRequest, result.StatusCode);
    }
    [TestMethod]
    public void EditAboutPage_Success()
    {
        // Arrange
        var ret = new AboutPageViewModel();

        // Act
        var result = _controller.EditAboutPage(ret);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is StatusCodeResult);
        Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);
    }
    [TestMethod]
    public void EditHomePage_Returns_BadRequest()
    {
        // Arrange
        var ret = new HomePageViewModel();

        _controller.ModelState.AddModelError("testError", "testError");

        // Act
        var result = _controller.EditHomePage(ret);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is StatusCodeResult);
        Assert.AreEqual((int)HttpStatusCode.BadRequest, result.StatusCode);
    }
    [TestMethod]
    public void EditHomePage_Success()
    {
        // Arrange
        var ret = new HomePageViewModel();

        // Act
        var result = _controller.EditHomePage(ret);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is StatusCodeResult);
        Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);
    }
    [TestMethod]
    public void Index_success()
    {
        // Arrange

        _mockService.Setup(x => x.GetHomePage()).ReturnsAsync(new HomePageViewModel());

        // Act
        var result = _controller.Index();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is HomePageViewModel);
    }
};
