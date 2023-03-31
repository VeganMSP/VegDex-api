using VegDex.Application.Models;

namespace VegDex.Application.Interfaces;

public interface IAddressService
{
    Task<AddressModel> GetAddressById(int addressId);
    Task<AddressModel> Create(AddressModel address);
    Task Update(AddressModel address);
    Task Delete(AddressModel address);
}
