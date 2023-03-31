using AutoMapper;
using Serilog;
using VegDex.Application.Interfaces;
using VegDex.Web.MVC.Interfaces;
using VegDex.Web.MVC.Models;
using ILogger = Serilog.ILogger;

namespace VegDex.Web.MVC.Services;

public class RestaurantPageService : IRestaurantPageService
{
    private readonly IRestaurantService _restaurantAppService;
    private readonly ICityService _cityAppService;
    private readonly IMapper _mapper;
    private readonly ILogger _logger = Log.ForContext<RestaurantPageService>();
    public RestaurantPageService(IRestaurantService restaurantAppService, ICityService cityAppService, IMapper mapper)
    {
        _restaurantAppService = restaurantAppService ?? throw new ArgumentNullException(nameof(restaurantAppService));
        _cityAppService = cityAppService ?? throw new ArgumentNullException(nameof(cityAppService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    /// <inheritdoc />
    public async Task<IEnumerable<RestaurantViewModel>> GetRestaurants(string restaurantName = null)
    {
        if (string.IsNullOrWhiteSpace(restaurantName))
        {
            var list = await _restaurantAppService.GetRestaurantList();
            var mapped = _mapper.Map<IEnumerable<RestaurantViewModel>>(list);
            return mapped;
        }
        var listByName = await _restaurantAppService.GetRestaurantByName(restaurantName);
        var mappedByName = _mapper.Map<IEnumerable<RestaurantViewModel>>(listByName);
        return mappedByName;
    }
}
