using System.Reflection;
using AutoMapper;
using Serilog;
using VegDex.Application.Interfaces;
using VegDex.Application.Models;
using VegDex.Core.Utilities;
using VegDex.Web.MVC.Interfaces;
using VegDex.Web.MVC.ViewModels;
using ILogger = Serilog.ILogger;

namespace VegDex.Web.MVC.Services;

public class CityPageService : ICityPageService
{
    private readonly ICityService _cityAppService;
    private readonly ILogger _logger = Log.ForContext<CityPageService>();
    private readonly IMapper _mapper;
    public CityPageService(ICityService cityAppService, IMapper mapper)
    {
        _cityAppService = cityAppService ?? throw new ArgumentNullException(nameof(cityAppService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    /// <inheritdoc />
    public async Task<IEnumerable<CityViewModel>> GetCitys(string? cityName)
    {
        if (string.IsNullOrWhiteSpace(cityName))
        {
            var list = await _cityAppService.GetCities();
            var mapped = _mapper.Map<IEnumerable<CityViewModel>>(list);
            return mapped;
        }
        _logger.Debug("{Method} with term {CityName}", MethodBase.GetCurrentMethod()?.Name, cityName);
        var listByName = await _cityAppService.GetCityByName(cityName);
        var mappedByName = _mapper.Map<IEnumerable<CityViewModel>>(listByName);
        return mappedByName;
    }
    /// <inheritdoc />
    public async Task<IEnumerable<CityViewModel>> GetCities()
    {
        var list = await _cityAppService.GetCities();
        var mapped = _mapper.Map<IEnumerable<CityViewModel>>(list);
        return mapped;
    }
    /// <inheritdoc />
    public async Task<CityModel> CreateCity(CityModel city)
    {
        var mapped = _mapper.Map<CityModel>(city);
        if (mapped == null)
            throw new Exception("Entity could not be mapped");
        mapped.Slug = mapped.Name.ToUrlSlug();
        var entityDto = await _cityAppService.Create(mapped);
        _logger.Information("Entity successfully added: {City}", city);

        var mappedModel = _mapper.Map<CityModel>(entityDto);
        return mappedModel;
    }
    /// <inheritdoc />
    public async Task<CityModel> GetCityById(int? id)
    {
        var city = await _cityAppService.GetCityById(id.Value);
        var mapped = _mapper.Map<CityModel>(city);
        return mapped;
    }
    /// <inheritdoc />
    public async Task DeleteCity(CityModel city)
    {
        var mapped = _mapper.Map<CityModel>(city);
        if (mapped == null)
            throw new Exception("Entity could not be mapped");

        await _cityAppService.Delete(mapped);
        _logger.Information("Entity successfully deleted: {City}", mapped);
    }
    /// <inheritdoc />
    public async Task UpdateCity(CityModel cityModel)
    {
        var mapped = _mapper.Map<CityModel>(cityModel);
        if (mapped == null)
            throw new Exception("Entity could not be mapped");

        await _cityAppService.Update(mapped);
        _logger.Information("Entity successfully updated: {City}", mapped);
    }
}