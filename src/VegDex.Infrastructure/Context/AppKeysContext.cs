using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VegDex.Infrastructure.Context;

public class AppKeysContext : DbContext, IDataProtectionKeyContext
{
    public AppKeysContext(DbContextOptions<AppKeysContext> options) : base(options) { }
    /// <inheritdoc />
    public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }
}
