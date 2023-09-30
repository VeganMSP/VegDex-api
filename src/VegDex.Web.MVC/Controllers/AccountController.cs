using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace VegDex.Web.MVC.Controllers;

public class AccountController : Controller
{
    private IUserService _userService;
    public AccountController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        try
        {
            // Authenticate
            var user = new UserDbModel
            {
                Username = model.Username,
                Password = model.Password
            };
            _userService.SupportsUserAuthenticatorKey(this.HttpContext, user);
            return RedirectToAction("Index", "Home");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Summary", ex.Message);
            return View(model);
        }
    }
}
