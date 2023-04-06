using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using VegDex.Application.Models;
using VegDex.Web.MVC.Interfaces;
using ILogger = Serilog.ILogger;

namespace VegDex.Web.MVC.Controllers;

public class ShoppingController : Controller
{
    private static readonly ILogger _logger = Log.ForContext<ShoppingController>();
    private readonly IShoppingPageService _shoppingPageService;
    public ShoppingController(IShoppingPageService shoppingPageService)
    {
        _shoppingPageService =
            shoppingPageService ?? throw new ArgumentNullException(nameof(shoppingPageService));
    }
    [Route("Shopping/VeganCompany/Create")]
    public async Task<IActionResult> CreateVeganCompany()
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        return View();
    }
    [HttpPost]
    [Route("Shopping/VeganCompany/Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateVeganCompany(VeganCompanyModel veganCompanyModel)
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        if (!ModelState.IsValid) return View(veganCompanyModel);
        _shoppingPageService.CreateVeganCompany(veganCompanyModel);
        return RedirectToAction("Index");
    }
    [Route("Shopping/VeganCompany/Delete")]
    public async Task<IActionResult> DeleteVeganCompany(int id)
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        if (id == null)
            return NotFound();
        var veganCompany = await _shoppingPageService.GetVeganCompanyById(id);
        if (veganCompany == null)
            return NotFound();
        return View(veganCompany);
    }
    [HttpPost]
    [Route("Shopping/VeganCompany/Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteVeganCompanyConfirmed(int id)
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        if (id == null)
            return NotFound();
        var veganCompany = await _shoppingPageService.GetVeganCompanyById(id);
        if (veganCompany == null)
            return NotFound();
        await _shoppingPageService.DeleteVeganCompany(veganCompany);
        return RedirectToAction("Index");
    }
    [Route("Shopping/VeganCompany/Edit")]
    public async Task<IActionResult> EditVeganCompany(int id)
    {
        if (id == null)
            return NotFound();
        var veganCompany = await _shoppingPageService.GetVeganCompanyById(id);
        if (veganCompany == null)
            return NotFound();
        return View(veganCompany);
    }
    [HttpPost]
    [Route("Shopping/VeganCompany/Edit")]
    [ValidateAntiForgeryToken]

    public async Task<IActionResult> EditVeganCompany(int? id, VeganCompanyModel veganCompanyModel)
    {
        if (id != veganCompanyModel.Id)
            return NotFound();
        if (ModelState.IsValid)
        {
            try
            {
                await _shoppingPageService.UpdateVeganCompany(veganCompanyModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeganCompanyExists(veganCompanyModel.Id))
                    return NotFound();
                throw;
            }
            return RedirectToAction("Index");
        }
        return View(veganCompanyModel);
    }
    private bool VeganCompanyExists(int id)
    {
        var veganCompany = _shoppingPageService.GetVeganCompanyById(id);
        return veganCompany != null;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        var viewModel = await _shoppingPageService.GetPageInformation();
        return View(viewModel);
    }
}
