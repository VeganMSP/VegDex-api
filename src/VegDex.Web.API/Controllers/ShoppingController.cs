using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using VegDex.Application.Models;
using VegDex.Web.MVC.Interfaces;

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
    [Route("Shopping/FarmersMarket/Create")]
    public async Task<IActionResult> CreateFarmersMarket()
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        return View();
    }
    [HttpPost]
    [Route("Shopping/FarmersMarket/Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateFarmersMarket(FarmersMarketModel farmersMarketModel)
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        if (!ModelState.IsValid) return View(farmersMarketModel);
        _shoppingPageService.CreateFarmersMarket(farmersMarketModel);
        return RedirectToAction("Index");
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
    [Route("Shopping/FarmersMarket/Delete")]
    public async Task<IActionResult> DeleteFarmersMarket(int id)
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        if (id == null)
            return NotFound();
        var farmersMarket = await _shoppingPageService.GetFarmersMarketById(id);
        if (farmersMarket == null)
            return NotFound();
        return View(farmersMarket);
    }
    [HttpPost]
    [Route("Shopping/FarmersMarket/Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteFarmersMarketConfirmed(int id)
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        if (id == null)
            return NotFound();
        var farmersMarket = await _shoppingPageService.GetFarmersMarketById(id);
        if (farmersMarket == null)
            return NotFound();
        await _shoppingPageService.DeleteFarmersMarket(farmersMarket);
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
    [Route("Shopping/FarmersMarket/Edit")]
    public async Task<IActionResult> EditFarmersMarket(int id)
    {
        if (id == null)
            return NotFound();
        var farmersMarket = await _shoppingPageService.GetFarmersMarketById(id);
        if (farmersMarket == null)
            return NotFound();
        return View(farmersMarket);
    }
    [HttpPost]
    [Route("Shopping/FarmersMarket/Edit")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditFarmersMarket(int? id, FarmersMarketModel farmersMarketModel)
    {
        if (id != farmersMarketModel.Id)
            return NotFound();
        if (ModelState.IsValid)
        {
            try
            {
                await _shoppingPageService.UpdateFarmersMarket(farmersMarketModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FarmersMarketExists(farmersMarketModel.Id))
                    return NotFound();
                throw;
            }
            return RedirectToAction("Index");
        }
        return View(farmersMarketModel);
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
    private bool FarmersMarketExists(int id)
    {
        var farmersMarket = _shoppingPageService.GetFarmersMarketById(id);
        return farmersMarket != null;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        var viewModel = await _shoppingPageService.GetPageInformation();
        return View(viewModel);
    }
    private bool VeganCompanyExists(int id)
    {
        var veganCompany = _shoppingPageService.GetVeganCompanyById(id);
        return veganCompany != null;
    }
}
