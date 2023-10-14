using Microsoft.AspNetCore.Mvc;
using VegDex.Application.Interfaces;
using VegDex.Application.Models;
using VegDex.Web.API.Attributes;

namespace VegDex.Web.API.Controllers;

[ApiVersion("1")]
[Route("[controller]")]
[ApiController]
public class UsersController : Controller
{
    private IUserService _userService;
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpPost("authenticate")]
    public async Task<IActionResult> Authenticate(AuthenticateRequest model)
    {
        var response = await _userService.AuthenticateUser(model);

        if (response == null)
            return BadRequest(new
            { message = "Username or password is incorrect" });

        return Ok(response);
    }
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAll();
        return Ok(users);
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register(AuthRegistrationRequest model)
    {
        var response = await _userService.RegisterUser(model);

        if (response == null)
            return BadRequest();

        return Ok(response);
    }
}
