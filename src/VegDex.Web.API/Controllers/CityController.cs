using System.Net;
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
public class CityController : Controller
{
    private static readonly ILogger _logger = Log.ForContext<CityController>();
    private readonly ICityPageService _cityPageService;
    public CityController(ICityPageService cityPageService)
    {
        _cityPageService =
            cityPageService ?? throw new ArgumentNullException(nameof(cityPageService));
    }
    private bool CityExists(int? id)
    {
        var city = _cityPageService.GetCityById(id);
        return city != null;
    }
    [HttpPost]
    public StatusCodeResult Create(CityModel city)
    {
        if (ModelState.IsValid)
        {
            _cityPageService.CreateCity(city);
            return Ok();
        }
        return BadRequest();
    }
    [HttpDelete]
    [ActionName("Delete")]
    public StatusCodeResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var city = _cityPageService.GetCityById(id).Result;
        if (city == null)
        {
            return NotFound();
        }
        _cityPageService.DeleteCity(city);
        return Ok();
    }
    [HttpPatch]
    [ValidateAntiForgeryToken]
    public StatusCodeResult Edit(int? id, CityModel city)
    {
        if (id != city.Id)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            try
            {
                _cityPageService.UpdateCity(city);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(city.Id))
                {
                    return NotFound();
                }
                throw;
            }
            return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
        }
        return Ok();
    }
    [HttpGet]
    public IEnumerable<CityViewModel> Index()
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        var cities = _cityPageService.GetCities().Result;
        return cities;
    }
}
