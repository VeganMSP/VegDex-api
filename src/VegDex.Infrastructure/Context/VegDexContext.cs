using Microsoft.EntityFrameworkCore;
using VegDex.Application.Models;

namespace VegDex.Infrastructure.Context;

public class VegDexContext : DbContext
{
    public VegDexContext(DbContextOptions options) : base(options) { }
    /// <inheritdoc />
    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddressModel>().ToTable("Address");
        modelBuilder.Entity<CityModel>().ToTable("City");
        modelBuilder.Entity<FarmersMarketModel>().ToTable("FarmersMarket");
        modelBuilder.Entity<LinkCategoryModel>().ToTable("LinkCategory");
        modelBuilder.Entity<LinkModel>().ToTable("Link");
        modelBuilder.Entity<RestaurantModel>().ToTable("Restaurant");
        modelBuilder.Entity<VeganCompanyModel>().ToTable("VeganCompany");
        modelBuilder.Entity<BlogPostModel>().ToTable("BlogPost");
        modelBuilder.Entity<BlogCategoryModel>().ToTable("BlogCategory");
    }
}
