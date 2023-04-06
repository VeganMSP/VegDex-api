using VegDex.Application.Models;

namespace VegDex.Application.Interfaces;

public interface IAddressService
{
    Task<AddressModel> Create(AddressModel address);
    Task Delete(AddressModel address);
    Task<AddressModel> GetAddressById(int addressId);
    Task Update(AddressModel address);
}
