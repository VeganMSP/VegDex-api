using AutoMapper;
using VegDex.Application.Models;
using VegDex.Core.Entities;

namespace VegDex.Application.Mapper;

public static class ObjectMapper
{
    private static readonly Lazy<IMapper> Lazy = new(() =>
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
            cfg.AddProfile<VegDexDtoMapper>();
        });
        var mapper = config.CreateMapper();
        return mapper;
    });
    public static IMapper Mapper = Lazy.Value;
}
public class VegDexDtoMapper : Profile
{
    public VegDexDtoMapper()
    {
        CreateMap<BlogCategory, BlogCategoryModel>().ReverseMap();
        CreateMap<BlogPost, BlogPostModel>().ReverseMap();
        CreateMap<City, CityModel>().ReverseMap();
        CreateMap<FarmersMarket, FarmersMarketModel>().ReverseMap();
        CreateMap<LinkCategory, LinkCategoryModel>().ReverseMap();
        CreateMap<Link, LinkModel>().ReverseMap();
        CreateMap<Restaurant, RestaurantModel>().ReverseMap();
        CreateMap<VeganCompany, VeganCompanyModel>().ReverseMap();
        CreateMap<AboutPage, AboutPageModel>();
        CreateMap<HomePage, HomePageModel>();
    }
}
