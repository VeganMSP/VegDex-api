using AutoMapper;
using Serilog;
using VegDex.Application.Interfaces;
using VegDex.Web.MVC.Interfaces;
using VegDex.Web.MVC.ViewModels;
using ILogger = Serilog.ILogger;

namespace VegDex.Web.MVC.Services;

public class ShoppingPageService : IShoppingPageService
{
    private readonly IFarmersMarketService _farmersMarketAppService;
    private readonly ILogger _logger = Log.ForContext<RestaurantPageService>();
    private readonly IMapper _mapper;
    private readonly IVeganCompanyService _veganCompanyAppService;
    public ShoppingPageService(
        IFarmersMarketService farmersMarketAppService,
        IVeganCompanyService veganCompanyAppService,
        IMapper mapper)
    {
        _farmersMarketAppService =
            farmersMarketAppService ?? throw new ArgumentNullException(nameof(farmersMarketAppService));
        _veganCompanyAppService =
            veganCompanyAppService ?? throw new ArgumentNullException(nameof(veganCompanyAppService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    /// <inheritdoc />
    public async Task<ShoppingViewModel> GetPageInformation()
    {
        var farmersMarkets = await _farmersMarketAppService.GetFarmersMarkets();
        var veganCompanies = await _veganCompanyAppService.GetVeganCompanies();
        var viewModel = new ShoppingViewModel
        {
            FarmersMarkets = farmersMarkets,
            VeganCompanies = veganCompanies
        };
        return viewModel;
    }
}
