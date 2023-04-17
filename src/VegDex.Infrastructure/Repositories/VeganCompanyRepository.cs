namespace VegDex.Infrastructure.Repositories;

public class VeganCompanyRepository : Repository<VeganCompany>, IVeganCompanyRepository
{
    private static readonly ILogger _logger = Log.ForContext<VeganCompanyRepository>();
    private VegDexContext _dbContext;
    /// <inheritdoc />
    public VeganCompanyRepository(VegDexContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    /// <inheritdoc />
    public async Task<IEnumerable<VeganCompany>> GetVeganCompanies()
    {
        var veganCompanies = await _dbContext.Set<VeganCompany>()
            .ToListAsync();
        return veganCompanies;
    }
}
