namespace VegDex.Core.Repositories;

public interface ILinkRepository : IRepository<Link>
{
    Task<IEnumerable<Link>> GetLinkListAsync();
}
