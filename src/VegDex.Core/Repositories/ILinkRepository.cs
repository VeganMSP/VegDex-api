using VegDex.Core.Entities;
using VegDex.Core.Repositories.Base;

namespace VegDex.Core.Repositories;

public interface ILinkRepository : IRepository<Link>
{
    Task<IEnumerable<Link>> GetLinkListAsync();
}
