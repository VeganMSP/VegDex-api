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
public class RestaurantsControllerTests
{
    [TestInitialize]
    public void Init()
    {
        _mockService = new Mock<IRestaurantsPageService>();
        _controller = new RestaurantsController(_mockService.Object);
    }
    [TestCleanup]
    public void Cleanup()
    {
        _controller.Dispose();
    }
    private RestaurantsController _controller;
    private Mock<IRestaurantsPageService> _mockService;
    [TestMethod]
    public void Create_fail()
    {
        // Arrange
        RestaurantModel restaurantModel = null!;

        _controller.ModelState.AddModelError("testError", "testError");

        // Act
        var result = _controller.Create(restaurantModel);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is StatusCodeResult);
        Assert.IsTrue(result.StatusCode is (int)HttpStatusCode.BadRequest);
    }
    [TestMethod]
    public void Create_success()
    {
        // Arrange
        RestaurantModel restaurantModel = null!;

        // Act
        var result = _controller.Create(restaurantModel);

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

        _mockService.Setup(x => x.GetRestaurantById(It.IsAny<int>())).ReturnsAsync((RestaurantModel)null!);

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

        _mockService.Setup(x => x.GetRestaurantById(It.IsAny<int>())).ReturnsAsync(new RestaurantModel());

        // Act
        var result = _controller.DeleteConfirmed(id);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is OkResult);
    }
    [TestMethod]
    public void Edit_Returns_BadRequest()
    {
        // Arrange
        int? id = 1;
        var ret = new RestaurantModel
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
        var ret = new RestaurantModel
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
        var ret = new RestaurantModel
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
        var ret = new RestaurantModel
        { Id = id.Value };

        _mockService.Setup(x => x.UpdateRestaurant(It.IsAny<RestaurantModel>())).Throws<DbUpdateConcurrencyException>();
        _mockService.Setup(x => x.GetRestaurantById(It.IsAny<int>())).ReturnsAsync((RestaurantModel)null!);

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
        var ret = new RestaurantModel
        { Id = id.Value };

        _mockService.Setup(x => x.UpdateRestaurant(It.IsAny<RestaurantModel>())).Throws<DbUpdateConcurrencyException>();
        _mockService.Setup(x => x.GetRestaurantById(It.IsAny<int>())).ReturnsAsync(new RestaurantModel());

        // Act
        var result = _controller.Edit(id, ret);

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
        Assert.IsTrue(result is RestaurantViewModel);
    }
}
