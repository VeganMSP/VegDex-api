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
public class ShoppingControllerTests
{
    [TestInitialize]
    public void Init()
    {
        _mockService = new Mock<IShoppingPageService>();
        _controller = new ShoppingController(_mockService.Object);
    }
    [TestCleanup]
    public void Cleanup()
    {
        _controller.Dispose();
    }
    private ShoppingController _controller;
    private Mock<IShoppingPageService> _mockService;
    [TestMethod]
    public void CreateFarmersMarket_fail()
    {
        // Arrange
        FarmersMarketModel farmersMarketModel = null!;

        _controller.ModelState.AddModelError("testError", "testError");

        // Act
        var result = _controller.CreateFarmersMarket(farmersMarketModel);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is StatusCodeResult);
        Assert.IsTrue(result.StatusCode is (int)HttpStatusCode.BadRequest);
    }
    [TestMethod]
    public void CreateFarmersMarket_success()
    {
        // Arrange
        FarmersMarketModel farmersMarketModel = null!;

        // Act
        var result = _controller.CreateFarmersMarket(farmersMarketModel);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is OkResult);
    }
    [TestMethod]
    public void CreateVeganCompany_fail()
    {
        // Arrange
        VeganCompanyModel veganCompanyModel = null!;

        _controller.ModelState.AddModelError("testError", "testError");

        // Act
        var result = _controller.CreateVeganCompany(veganCompanyModel);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is StatusCodeResult);
        Assert.IsTrue(result.StatusCode is (int)HttpStatusCode.BadRequest);
    }
    [TestMethod]
    public void CreateVeganCompany_success()
    {
        // Arrange
        VeganCompanyModel veganCompanyModel = null!;

        // Act
        var result = _controller.CreateVeganCompany(veganCompanyModel);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is OkResult);
    }
    [TestMethod]
    public void DeleteFarmersMarket_Null_Id_Returns_NotFound()
    {
        // Arrange
        int? id = null;

        // Act
        var result = _controller.DeleteFarmersMarketConfirmed(id);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is NotFoundResult);
    }
    [TestMethod]
    public void DeleteFarmersMarket_Null_Post_Returns_NotFound()
    {
        // Arrange
        int? id = 1;

        _mockService.Setup(x => x.GetFarmersMarketById(It.IsAny<int>())).ReturnsAsync((FarmersMarketModel)null!);

        // Act
        var result = _controller.DeleteFarmersMarketConfirmed(id);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is NotFoundResult);
    }
    [TestMethod]
    public void DeleteFarmersMarket_Success()
    {
        // Arrange
        int? id = 1;

        _mockService.Setup(x => x.GetFarmersMarketById(It.IsAny<int>())).ReturnsAsync(new FarmersMarketModel());

        // Act
        var result = _controller.DeleteFarmersMarketConfirmed(id);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is OkResult);
    }
    [TestMethod]
    public void DeleteVeganCompany_Null_Id_Returns_NotFound()
    {
        // Arrange
        int? id = null;

        // Act
        var result = _controller.DeleteVeganCompanyConfirmed(id);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is NotFoundResult);
    }
    [TestMethod]
    public void DeleteVeganCompany_Null_Post_Returns_NotFound()
    {
        // Arrange
        int? id = 1;

        _mockService.Setup(x => x.GetVeganCompanyById(It.IsAny<int>())).ReturnsAsync((VeganCompanyModel)null!);

        // Act
        var result = _controller.DeleteVeganCompanyConfirmed(id);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is NotFoundResult);
    }
    [TestMethod]
    public void DeleteVeganCompany_Success()
    {
        // Arrange
        int? id = 1;

        _mockService.Setup(x => x.GetVeganCompanyById(It.IsAny<int>())).ReturnsAsync(new VeganCompanyModel());

        // Act
        var result = _controller.DeleteVeganCompanyConfirmed(id);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is OkResult);
    }
    [TestMethod]
    public void EditFarmersMarket_Returns_BadRequest()
    {
        // Arrange
        int? id = 1;
        var ret = new FarmersMarketModel
        { Id = id.Value };

        _controller.ModelState.AddModelError("testError", "testError");

        // Act
        var result = _controller.EditFarmersMarket(id, ret);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is BadRequestResult);
    }
    [TestMethod]
    public void EditFarmersMarket_Returns_NotFound()
    {
        // Arrange
        int? id = 1;
        var ret = new FarmersMarketModel()
        { Id = 12 };

        // Act
        var result = _controller.EditFarmersMarket(id, ret);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is NotFoundResult);
    }
    [TestMethod]
    public void EditFarmersMarket_Success()
    {
        // Arrange
        int? id = 1;
        var ret = new FarmersMarketModel()
        { Id = id.Value };

        // Act
        var result = _controller.EditFarmersMarket(id, ret);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is OkResult);
    }
    [TestMethod]
    public void EditFarmersMarket_Throws_DbConcurrency_Exception_Returns_NotFound()
    {
        // Arrange
        int? id = 1;
        var ret = new FarmersMarketModel()
        { Id = id.Value };

        _mockService.Setup(x => x.UpdateFarmersMarket(It.IsAny<FarmersMarketModel>()))
            .Throws<DbUpdateConcurrencyException>();
        _mockService.Setup(x => x.GetFarmersMarketById(It.IsAny<int>())).ReturnsAsync((FarmersMarketModel)null!);

        // Act
        var result = _controller.EditFarmersMarket(id, ret);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is NotFoundResult);
    }
    [TestMethod]
    [ExpectedException(typeof(DbUpdateConcurrencyException))]
    public void EditFarmersMarket_Throws_DbConcurrency_Exception_Throws()
    {
        // Arrange
        int? id = 1;
        var ret = new FarmersMarketModel()
        { Id = id.Value };

        _mockService.Setup(x => x.UpdateFarmersMarket(It.IsAny<FarmersMarketModel>()))
            .Throws<DbUpdateConcurrencyException>();
        _mockService.Setup(x => x.GetFarmersMarketById(It.IsAny<int>())).ReturnsAsync(new FarmersMarketModel());

        // Act
        var result = _controller.EditFarmersMarket(id, ret);

        // Assert - Exception
    }
    [TestMethod]
    public void EditVeganCompany_Returns_BadRequest()
    {
        // Arrange
        int? id = 1;
        var ret = new VeganCompanyModel
        { Id = id.Value };

        _controller.ModelState.AddModelError("testError", "testError");

        // Act
        var result = _controller.EditVeganCompany(id, ret);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is BadRequestResult);
    }
    [TestMethod]
    public void EditVeganCompany_Returns_NotFound()
    {
        // Arrange
        int? id = 1;
        var ret = new VeganCompanyModel()
        { Id = 12 };

        // Act
        var result = _controller.EditVeganCompany(id, ret);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is NotFoundResult);
    }
    [TestMethod]
    public void EditVeganCompany_Success()
    {
        // Arrange
        int? id = 1;
        var ret = new VeganCompanyModel()
        { Id = id.Value };

        // Act
        var result = _controller.EditVeganCompany(id, ret);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is OkResult);
    }
    [TestMethod]
    public void EditVeganCompany_Throws_DbConcurrency_Exception_Returns_NotFound()
    {
        // Arrange
        int? id = 1;
        var ret = new VeganCompanyModel()
        { Id = id.Value };

        _mockService.Setup(x => x.UpdateVeganCompany(It.IsAny<VeganCompanyModel>()))
            .Throws<DbUpdateConcurrencyException>();
        _mockService.Setup(x => x.GetVeganCompanyById(It.IsAny<int>())).ReturnsAsync((VeganCompanyModel)null!);

        // Act
        var result = _controller.EditVeganCompany(id, ret);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is NotFoundResult);
    }
    [TestMethod]
    [ExpectedException(typeof(DbUpdateConcurrencyException))]
    public void EditVeganCompany_Throws_DbConcurrency_Exception_Throws()
    {
        // Arrange
        int? id = 1;
        var ret = new VeganCompanyModel()
        { Id = id.Value };

        _mockService.Setup(x => x.UpdateVeganCompany(It.IsAny<VeganCompanyModel>()))
            .Throws<DbUpdateConcurrencyException>();
        _mockService.Setup(x => x.GetVeganCompanyById(It.IsAny<int>())).ReturnsAsync(new VeganCompanyModel());

        // Act
        var result = _controller.EditVeganCompany(id, ret);

        // Assert - Exception
    }
    [TestMethod]
    public void Index_ZeroResults_success()
    {
        // Arrange
        _mockService.Setup(x => x.GetPageInformation()).ReturnsAsync(new ShoppingViewModel());

        // Act
        var result = _controller.Index();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is ShoppingViewModel);
    }
}
