using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Serilog;
using VegDex.Application.Models;
using VegDex.Web.MVC.Interfaces;
using VegDex.Web.MVC.ViewModels;
using ILogger = Serilog.ILogger;

namespace VegDex.Web.MVC.Controllers;

public class CityController : Controller
{
    private static readonly ILogger _logger = Log.ForContext<CityController>();
    private readonly ICityPageService _cityPageService;
    public CityController(ICityPageService cityPageService)
    {
        _cityPageService =
            cityPageService ?? throw new ArgumentNullException(nameof(cityPageService));
    }
    public async Task<IActionResult> Create()
    {
        var cities = await _cityPageService.GetCities();
        ViewData["CityId"] = new SelectList(cities, "Id", "Name");
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CityModel city)
    {
        if (ModelState.IsValid)
        {
            _cityPageService.CreateCity(city);
            return RedirectToAction("Index");
        }
        var cities = await _cityPageService.GetCities();
        ViewData["CityId"] = new SelectList(cities, "Id", "Name");
        return View(city);
    }
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var city = await _cityPageService.GetCityById(id.Value);
        if (city == null)
        {
            return NotFound();
        }
        return View(city);
    }
    [HttpPost]
    [ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var city = await _cityPageService.GetCityById(id);
        if (city == null)
        {
            return NotFound();
        }
        await _cityPageService.DeleteCity(city);
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var city = await _cityPageService.GetCityById(id);
        if (city == null)
        {
            return NotFound();
        }
        return View(city);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, CityModel city)
    {
        if (id != city.Id)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            try
            {
                await _cityPageService.UpdateCity(city);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(city.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index");
        }
        return View(city);
    }
    public async Task<IActionResult> Index()
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        var cities = await _cityPageService.GetCities();
        return View(cities);
    }
    private bool CityExists(int? id)
    {
        var city = _cityPageService.GetCityById(id);
        return city != null;
    }
}
