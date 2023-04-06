using AutoMapper;
using VegDex.Application.Models;
using VegDex.Web.MVC.ViewModels;
using VegDex.Web.MVC.ViewModels.Meta;

namespace VegDex.Web.MVC.Mapper;

public class VegDexProfile : Profile
{
    public VegDexProfile()
    {
        CreateMap<RestaurantModel, RestaurantViewModel>();
        CreateMap<LinkModel, LinkViewModel>();
        CreateMap<LinkCategoryModel, LinkCategoryViewModel>();
        CreateMap<CityModel, CityViewModel>();
        CreateMap<AboutPageModel, AboutPageViewModel>();
        CreateMap<HomePageModel, HomePageViewModel>();
    }
    
}
