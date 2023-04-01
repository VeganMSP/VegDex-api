using AutoMapper;
using VegDex.Application.Models;
using VegDex.Core.Entities;
using VegDex.Web.MVC.ViewModels;

namespace VegDex.Web.MVC.Mapper;

public class VegDexProfile : Profile
{
    public VegDexProfile()
    {
        CreateMap<RestaurantModel, RestaurantViewModel>();
        CreateMap<LinkModel, LinkViewModel>();
        CreateMap<LinkCategoryModel, LinkCategoryViewModel>();
        CreateMap<CityModel, CityViewModel>();
    }
    
}
