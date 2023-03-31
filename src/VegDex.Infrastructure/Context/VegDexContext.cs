using Microsoft.EntityFrameworkCore;
using VegDex.Application.Models;

namespace VegDex.Infrastructure.Context;

public class VegDexContext : DbContext
{
    public VegDexContext(DbContextOptions options) : base(options) { }
    /// <inheritdoc />
    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>().ToTable("Address");
        modelBuilder.Entity<City>().ToTable("City");
        modelBuilder.Entity<FarmersMarket>().ToTable("FarmersMarket");
        modelBuilder.Entity<LinkCategory>().ToTable("LinkCategory");
        modelBuilder.Entity<Link>().ToTable("Link");
        modelBuilder.Entity<Restaurant>().ToTable("Restaurant");
        modelBuilder.Entity<VeganCompany>().ToTable("VeganCompany");
        modelBuilder.Entity<BlogPost>().ToTable("BlogPost");
        modelBuilder.Entity<BlogCategory>().ToTable("BlogCategory");
    }
}
