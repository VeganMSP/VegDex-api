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
public class RestaurantsController : Controller
{
    private static readonly ILogger _logger = Log.ForContext<RestaurantsController>();
    private readonly IRestaurantsPageService _restaurantsPageService;
    public RestaurantsController(IRestaurantsPageService restaurantsPageService)
    {
        _restaurantsPageService =
            restaurantsPageService ?? throw new ArgumentNullException(nameof(restaurantsPageService));
    }
    [HttpPost]
    public StatusCodeResult Create(RestaurantModel restaurant)
    {
        if (ModelState.IsValid)
        {
            _restaurantsPageService.CreateRestaurant(restaurant);
            return Ok();
        }
        return BadRequest();
    }
    [HttpDelete]
    [ActionName("Delete")]
    public StatusCodeResult DeleteConfirmed(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var restaurant = _restaurantsPageService.GetRestaurantById(id).Result;
        if (restaurant == null)
        {
            return NotFound();
        }
        _restaurantsPageService.DeleteRestaurant(restaurant);
        return Ok();
    }
    [HttpPut]
    [ValidateAntiForgeryToken]
    public StatusCodeResult Edit(int? id, RestaurantModel restaurant)
    {
        if (id != restaurant.Id)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            try
            {
                _restaurantsPageService.UpdateRestaurant(restaurant);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(restaurant.Id))
                {
                    return NotFound();
                }
                throw;
            }
            return Ok();
        }
        return BadRequest();
    }
    [HttpGet]
    public RestaurantViewModel Index()
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        var citiesWithRestaurants = _restaurantsPageService.GetCitiesWithRestaurants().Result;
        var viewModel = new RestaurantViewModel
        { Cities = citiesWithRestaurants };
        return viewModel;
    }
    private bool RestaurantExists(int? id)
    {
        var restaurant = _restaurantsPageService.GetRestaurantById(id).Result;
        return restaurant != null;
    }
}
