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

public class RestaurantsController : Controller
{
    private static readonly ILogger _logger = Log.ForContext<RestaurantsController>();
    private readonly IRestaurantsPageService _restaurantsPageService;
    public RestaurantsController(IRestaurantsPageService restaurantsPageService)
    {
        _restaurantsPageService =
            restaurantsPageService ?? throw new ArgumentNullException(nameof(restaurantsPageService));
    }
    public async Task<IActionResult> Create()
    {
        var cities = await _restaurantsPageService.GetCities();
        ViewData["CityId"] = new SelectList(cities, "Id", "Name");
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(RestaurantModel restaurant)
    {
        if (ModelState.IsValid)
        {
            _restaurantsPageService.CreateRestaurant(restaurant);
            return RedirectToAction("Index");
        }
        var cities = await _restaurantsPageService.GetCities();
        ViewData["CityId"] = new SelectList(cities, "Id", "Name");
        return View(restaurant);
    }
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var restaurant = await _restaurantsPageService.GetRestaurantById(id.Value);
        if (restaurant == null)
        {
            return NotFound();
        }
        return View(restaurant);
    }
    [HttpPost]
    [ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var restaurant = await _restaurantsPageService.GetRestaurantById(id);
        if (restaurant == null)
        {
            return NotFound();
        }
        await _restaurantsPageService.DeleteRestaurant(restaurant);
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var restaurant = await _restaurantsPageService.GetRestaurantById(id);
        if (restaurant == null)
        {
            return NotFound();
        }
        ViewData["CityId"] = new SelectList(
            await _restaurantsPageService.GetCities(), "Id", "Name", restaurant.CityId);
        return View(restaurant);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, RestaurantModel restaurant)
    {
        if (id != restaurant.Id)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            try
            {
                await _restaurantsPageService.UpdateRestaurant(restaurant);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(restaurant.Id))
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
        ViewData["LocationId"] = new SelectList(
            await _restaurantsPageService.GetCities(), "Id", "Name", restaurant.CityId);
        return View(restaurant);
    }
    public async Task<IActionResult> Index()
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        IEnumerable<CityViewModel> citiesWithRestaurants = await _restaurantsPageService.GetCitiesWithRestaurants();
        var viewModel = new RestaurantViewModel
        {
            Cities = citiesWithRestaurants
        };
        return View(viewModel);
    }
    private bool RestaurantExists(int? id)
    {
        var restaurant = _restaurantsPageService.GetRestaurantById(id);
        return restaurant != null;
    }
}
