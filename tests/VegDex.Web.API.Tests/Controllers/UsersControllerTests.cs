using System.Net;
using Microsoft.AspNetCore.Mvc;
using Moq;
using VegDex.Application.Interfaces;
using VegDex.Application.Models;
using VegDex.Core.Entities;
using VegDex.Web.API.Controllers;

namespace VegDex.Web.API.Tests.Controllers;

[TestClass]
public class UsersControllerTests
{
    [TestInitialize]
    public void Init()
    {
        _mockService = new Mock<IUserService>();
        _controller = new UsersController(_mockService.Object);
    }
    [TestCleanup]
    public void Cleanup()
    {
        _controller.Dispose();
    }
    private Mock<IUserService> _mockService;
    private UsersController _controller;
    [TestMethod]
    public void Authenticate_failure()
    {
        // Arrange
        _mockService.Setup(x => x.AuthenticateUser(It.IsAny<AuthenticateRequest>()))
            .ReturnsAsync((AuthenticateResponse)null!);

        // Act
        var result = _controller.Authenticate(new AuthenticateRequest()).Result;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is BadRequestObjectResult);
        var objResult = (ObjectResult)result;
        Assert.AreEqual((int)HttpStatusCode.BadRequest, objResult.StatusCode);
        Assert.IsNotNull(objResult.Value);
        object? objResultValue = objResult.Value;
        Assert.IsNotNull(objResultValue);
    }
    [TestMethod]
    public void Authenticate_success()
    {
        // Arrange
        User user = new("daria", "hunter2");
        const string token = "token123456";
        _mockService.Setup(x => x.AuthenticateUser(It.IsAny<AuthenticateRequest>()))
            .ReturnsAsync(new AuthenticateResponse(user, token));

        // Act
        var result = _controller.Authenticate(new AuthenticateRequest()).Result;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is OkObjectResult);
        var objResult = (ObjectResult)result;
        Assert.AreEqual((int)HttpStatusCode.OK, objResult.StatusCode);
        Assert.IsNotNull(objResult.Value);
        var authResponse = (AuthenticateResponse)objResult.Value;
        Assert.AreEqual(user.Username, authResponse.Username);
        Assert.AreEqual(token, authResponse.Token);
    }
    [TestMethod]
    public void GetAll_ZeroResults_success()
    {
        // Arrange

        // Act
        var result = _controller.GetAll().Result;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is OkObjectResult);
        var objResult = (ObjectResult)result;
        Assert.AreEqual((int)HttpStatusCode.OK, objResult.StatusCode);
        Assert.IsNotNull(objResult.Value);
    }
    [TestMethod]
    public void Register_failure()
    {
        // Arrange
        _mockService.Setup(x => x.RegisterUser(It.IsAny<AuthRegistrationRequest>()))
            .ReturnsAsync((AuthRegistrationResponse)null!);

        // Act
        var result = _controller.Register(new AuthRegistrationRequest()).Result;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is BadRequestResult);
        var statusCodeResult = (StatusCodeResult)result;
        Assert.AreEqual((int)HttpStatusCode.BadRequest, statusCodeResult.StatusCode);
    }
    [TestMethod]
    public void Register_success()
    {
        // Arrange
        User user = new("daria", "hunter2");
        const string token = "token123456";
        _mockService.Setup(x => x.RegisterUser(It.IsAny<AuthRegistrationRequest>()))
            .ReturnsAsync(new AuthRegistrationResponse(user, token));

        // Act
        var result = _controller.Register(new AuthRegistrationRequest()).Result;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result is OkObjectResult);
        var objResult = (ObjectResult)result;
        Assert.AreEqual((int)HttpStatusCode.OK, objResult.StatusCode);
        Assert.IsNotNull(objResult.Value);
        var authRegResponse = (AuthRegistrationResponse)objResult.Value;
        Assert.AreEqual(user.Username, authRegResponse.Username);
        Assert.AreEqual(token, authRegResponse.Token);
    }
}
