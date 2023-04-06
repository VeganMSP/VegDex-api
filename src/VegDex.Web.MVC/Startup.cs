using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using VegDex.Application.Interfaces;
using VegDex.Application.Services;
using VegDex.Core;
using VegDex.Core.Configuration;
using VegDex.Core.Repositories;
using VegDex.Core.Repositories.Base;
using VegDex.Infrastructure.Context;
using VegDex.Infrastructure.Repositories;
using VegDex.Infrastructure.Repositories.Base;
using VegDex.Web.MVC.Interfaces;
using VegDex.Web.MVC.Services;

namespace VegDex.Web.MVC;

public class Startup
{
    private readonly IConfiguration _configuration;
    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        _configuration = configuration;
        Env = env;
    }
    private IWebHostEnvironment Env { get; }
    public void Configure(IApplicationBuilder app)
    {
        if (Env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
        }
        if (_configuration.GetValue<bool>("HttpRedirection"))
        {
            app.UseHttpsRedirection();
            if (Env.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
        }
        app.UseStatusCodePages();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.UseSession();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                "default",
                "{controller=Meta}/{action=Index}");
        });
    }
    public void ConfigureDatabase(IServiceCollection services)
    {
        // use sqlite
        string connectionString = _configuration.GetConnectionString("Default") ??
                                  throw new InvalidOperationException("No default connection string found");
        services.AddDbContext<VegDexContext>(c =>
            c.UseSqlite(connectionString)
        );
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<VegDexSettings>(_configuration);

        // Set up database
        ConfigureDatabase(services);
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IBlogCategoryRepository, BlogCategoryRepository>();
        services.AddScoped<IBlogPostRepository, BlogPostRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<IFarmersMarketRepository, FarmersMarketRepository>();
        services.AddScoped<ILinkCategoryRepository, LinkCategoryRepository>();
        services.AddScoped<ILinkRepository, LinkRepository>();
        services.AddScoped<IRestaurantRepository, RestaurantRepository>();
        services.AddScoped<IVeganCompanyRepository, VeganCompanyRepository>();
        services.AddScoped<IMetaRepository, MetaRepository>();

        // Application Layer
        services.AddScoped<IBlogCategoryService, BlogCategoryService>();
        services.AddScoped<IBlogPostService, BlogPostService>();
        services.AddScoped<ICityService, CityService>();
        services.AddScoped<IFarmersMarketService, FarmersMarketService>();
        services.AddScoped<ILinkCategoryService, LinkCategoryService>();
        services.AddScoped<ILinkService, LinkService>();
        services.AddScoped<IRestaurantService, RestaurantService>();
        services.AddScoped<IVeganCompanyService, VeganCompanyService>();
        services.AddScoped<IMetaService, MetaService>();

        // Web Layer
        services.AddAutoMapper(typeof(Startup));
        services.AddScoped<IRestaurantsPageService, RestaurantPageService>();
        services.AddScoped<ILinksPageService, LinksPageService>();
        services.AddScoped<IShoppingPageService, ShoppingPageService>();
        services.AddScoped<IBlogPageService, BlogPageService>();
        services.AddScoped<IMetaPageService, MetaPageService>();
        // services.AddScoped<IRestaurantsPageService, RestaurantPageService>();
        // services.AddScoped<IRestaurantsPageService, RestaurantPageService>();
        // services.AddScoped<IRestaurantsPageService, RestaurantPageService>();
        // services.AddScoped<IRestaurantsPageService, RestaurantPageService>();
        // services.AddScoped<IRestaurantsPageService, RestaurantPageService>();

        services.AddSingleton(_configuration);

        services.AddHttpContextAccessor();
        services.AddControllersWithViews();
        services.AddSession();

        services.AddDbContext<AppKeysContext>(c =>
            c.UseSqlite("Data Source=../keys.sqlite3")
        );

        services.AddDataProtection()
            .PersistKeysToDbContext<AppKeysContext>();

        if (Env.IsDevelopment())
        {
            services.AddDatabaseDeveloperPageExceptionFilter();
        }
    }
}
