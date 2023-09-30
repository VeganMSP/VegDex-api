using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using VegDex.Application.Interfaces;
using VegDex.Application.Services;
using VegDex.Core.Configuration;
using VegDex.Core.Repositories;
using VegDex.Core.Repositories.Base;
using VegDex.Infrastructure.Context;
using VegDex.Infrastructure.Repositories;
using VegDex.Infrastructure.Repositories.Base;
using VegDex.Web.API.Interfaces;
using VegDex.Web.API.Middlewares;
using VegDex.Web.API.Services;
using VegDex.Web.API.Setup;

namespace VegDex.Web.API;

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

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("v1/swagger.json", "VegDex API V1"); });
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
        app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:8080"));
        app.UseMiddleware<JwtMiddleware>();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                "default",
                "{controller=Home}/{action=Index}/{id?}");
            endpoints.MapRazorPages();
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
        IConfigManager configManager = new ConfigManager(_configuration);
        services.AddSingleton(configManager);

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
        services.AddScoped<IUserRepository, UserRepository>();

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

        // User Service
        services.AddScoped<IUserService, UserService>();

        // Web Layer
        services.AddAutoMapper(typeof(Startup));
        services.AddScoped<IRestaurantsPageService, RestaurantPageService>();
        services.AddScoped<ILinksPageService, LinksPageService>();
        services.AddScoped<IShoppingPageService, ShoppingPageService>();
        services.AddScoped<IBlogPageService, BlogPageService>();
        services.AddScoped<IMetaPageService, MetaPageService>();
        services.AddScoped<ICityPageService, CityPageService>();
        // services.AddScoped<IRestaurantsPageService, RestaurantPageService>();
        // services.AddScoped<IRestaurantsPageService, RestaurantPageService>();
        // services.AddScoped<IRestaurantsPageService, RestaurantPageService>();
        // services.AddScoped<IRestaurantsPageService, RestaurantPageService>();

        services.AddSingleton(_configuration);

        services.AddHttpContextAccessor();
        services.AddControllersWithViews();

        services.AddSingleton<IConfigureOptions<JsonOptions>, ConfigureJsonOptions>();

        services.AddApiVersioning(opt =>
        {
            opt.DefaultApiVersion = new ApiVersion(1, 0);
            opt.AssumeDefaultVersionWhenUnspecified = true;
            opt.ReportApiVersions = true;
            opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("x-api-version"),
                new MediaTypeApiVersionReader("x-api-version"));
        });
        // Add ApiExplorer to discover versions
        services.AddVersionedApiExplorer(opt =>
        {
            opt.GroupNameFormat = "'v'V";
            opt.SubstituteApiVersionInUrl = true;
        });
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "VegDex API",
                Description = "The API for the VegDex application.",
                Version = "v1"
            });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "JWT Token",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[]
                        { }
                }
            });
        });
        services.AddSession();
        services.AddCors();

        if (Env.IsDevelopment())
        {
            services.AddDatabaseDeveloperPageExceptionFilter();
        }
    }
}
