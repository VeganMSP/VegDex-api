using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using VegDex.Application.Models;
using VegDex.Web.API.Interfaces;
using VegDex.Web.API.ViewModels;

namespace VegDex.Web.API.Controllers;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ShoppingController : Controller
{
    private static readonly ILogger _logger = Log.ForContext<ShoppingController>();
    private readonly IShoppingPageService _shoppingPageService;
    public ShoppingController(IShoppingPageService shoppingPageService)
    {
        _shoppingPageService =
            shoppingPageService ?? throw new ArgumentNullException(nameof(shoppingPageService));
    }
    [HttpPost]
    [Route("FarmersMarket/Create")]
    public StatusCodeResult CreateFarmersMarket(FarmersMarketModel farmersMarketModel)
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        if (!ModelState.IsValid) return BadRequest();
        _shoppingPageService.CreateFarmersMarket(farmersMarketModel);
        return Ok();
    }
    [HttpPost]
    [Route("VeganCompany/Create")]
    public StatusCodeResult CreateVeganCompany(VeganCompanyModel veganCompanyModel)
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        if (!ModelState.IsValid) return BadRequest();
        _shoppingPageService.CreateVeganCompany(veganCompanyModel);
        return Ok();
    }
    [HttpDelete]
    [Route("FarmersMarket/Delete")]
    public StatusCodeResult DeleteFarmersMarketConfirmed(int? id)
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        if (id == null)
            return NotFound();
        var farmersMarket = _shoppingPageService.GetFarmersMarketById(id).Result;
        if (farmersMarket == null)
            return NotFound();
        _shoppingPageService.DeleteFarmersMarket(farmersMarket);
        return Ok();
    }
    [HttpDelete]
    [Route("VeganCompany/Delete")]
    public StatusCodeResult DeleteVeganCompanyConfirmed(int? id)
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        if (id == null)
            return NotFound();
        var veganCompany = _shoppingPageService.GetVeganCompanyById(id).Result;
        if (veganCompany == null)
            return NotFound();
        _shoppingPageService.DeleteVeganCompany(veganCompany);
        return Ok();
    }
    [HttpPost]
    [Route("FarmersMarket/Edit")]
    public StatusCodeResult EditFarmersMarket(int? id, FarmersMarketModel farmersMarketModel)
    {
        if (id != farmersMarketModel.Id)
            return NotFound();
        if (ModelState.IsValid)
        {
            try
            {
                _shoppingPageService.UpdateFarmersMarket(farmersMarketModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FarmersMarketExists(farmersMarketModel.Id))
                    return NotFound();
                throw;
            }
            return Ok();
        }
        return BadRequest();
    }
    [HttpPut]
    [Route("VeganCompany/Edit")]
    [ValidateAntiForgeryToken]
    public StatusCodeResult EditVeganCompany(int? id, VeganCompanyModel veganCompanyModel)
    {
        if (id != veganCompanyModel.Id)
            return NotFound();
        if (ModelState.IsValid)
        {
            try
            {
                _shoppingPageService.UpdateVeganCompany(veganCompanyModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeganCompanyExists(veganCompanyModel.Id))
                    return NotFound();
                throw;
            }
            return Ok();
        }
        return BadRequest();
    }
    private bool FarmersMarketExists(int id)
    {
        var farmersMarket = _shoppingPageService.GetFarmersMarketById(id).Result;
        return farmersMarket != null;
    }
    // GET
    [HttpGet]
    public ShoppingViewModel Index()
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        var viewModel = _shoppingPageService.GetPageInformation().Result;
        return viewModel;
    }
    private bool VeganCompanyExists(int id)
    {
        var veganCompany = _shoppingPageService.GetVeganCompanyById(id).Result;
        return veganCompany != null;
    }
}
