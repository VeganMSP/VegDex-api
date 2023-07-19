using AutoMapper;
using VegDex.Application.Models;
using VegDex.Web.API.ViewModels;
using VegDex.Web.API.ViewModels.Meta;

namespace VegDex.Web.API.Mapper;

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
        CreateMap<BlogCategoryModel, BlogCategoryViewModel>();
    }
}
