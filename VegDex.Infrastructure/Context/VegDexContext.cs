using Microsoft.EntityFrameworkCore;

namespace VegDex.Infrastructure.Context;

public class VegDexContext : DbContext
{
    public VegDexContext(DbContextOptions options) : base(options) { }
}
