using VegDex.Core.Entities;
using VegDex.Core.Repositories.Base;

namespace VegDex.Core.Repositories;

public interface IAddressRepository : IRepository<Address>
{
    Task<IEnumerable<Address>> GetAddressByIdAsync(int addressId);
    Task<IEnumerable<Address>> GetAddressByNameAsync(string addressName);
    Task<IEnumerable<Address>> GetAddressListAsync();
}
