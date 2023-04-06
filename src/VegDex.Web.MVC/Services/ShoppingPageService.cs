using AutoMapper;
using Serilog;
using VegDex.Application.Interfaces;
using VegDex.Application.Models;
using VegDex.Core.Utilities;
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
        var farmersMarkets = await _farmersMarketAppService.GetFarmersMarketList();
        var veganCompanies = await _veganCompanyAppService.GetVeganCompanies();
        var viewModel = new ShoppingViewModel
        {
            FarmersMarkets = farmersMarkets,
            VeganCompanies = veganCompanies
        };
        return viewModel;
    }
    /// <inheritdoc />
    public async Task<VeganCompanyModel> GetVeganCompanyById(int id)
    {
        var veganCompany = await _veganCompanyAppService.GetVeganCompanyById(id);
        var mapped = _mapper.Map<VeganCompanyModel>(veganCompany);
        return mapped;
    }
    /// <inheritdoc />
    public async Task UpdateVeganCompany(VeganCompanyModel veganCompany)
    {
        var mapped = _mapper.Map<VeganCompanyModel>(veganCompany);
        if (mapped == null)
            throw new Exception("Entity could not be mapped");
        await _veganCompanyAppService.Update(mapped);
        _logger.Information("Entity successfully updated: {VeganCompany}", mapped);
    }
    /// <inheritdoc />
    public async Task DeleteVeganCompany(VeganCompanyModel veganCompanyModel)
    {
        var mapped = _mapper.Map<VeganCompanyModel>(veganCompanyModel);
        if (mapped == null)
            throw new Exception("Entity could not be mapped");
        await _veganCompanyAppService.Delete(mapped);
        _logger.Information("Entity successfully deleted: {VeganCompany}", mapped);
    }
    /// <inheritdoc />
    public async Task<VeganCompanyModel> CreateVeganCompany(VeganCompanyModel veganCompanyModel)
    {
        var mapped = _mapper.Map<VeganCompanyModel>(veganCompanyModel);
        if (mapped == null)
            throw new Exception("Entity could not be mapped");
        mapped.Slug = mapped.Name.ToUrlSlug();
        var entityDto = await _veganCompanyAppService.Create(mapped);
        _logger.Information("Entity successfully created: {VeganCompany}", veganCompanyModel);

        var mappedModel = _mapper.Map<VeganCompanyModel>(entityDto);
        return mappedModel;
    }
}
