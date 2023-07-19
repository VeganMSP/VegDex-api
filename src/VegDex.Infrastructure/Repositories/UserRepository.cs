namespace VegDex.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly VegDexContext _dbContext;
    public UserRepository(VegDexContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }
    /// <inheritdoc />
    public async Task<IEnumerable<User>> GetAll() => await _dbContext.Set<User>().ToListAsync();
    /// <inheritdoc />
    public async Task<User?> GetById(int id) => await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.Id == id);
}
