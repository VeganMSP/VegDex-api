using Serilog;
using VegDex.Application.Interfaces;
using VegDex.Application.Mapper;
using VegDex.Application.Models;
using VegDex.Core.Entities;
using VegDex.Core.Repositories;

namespace VegDex.Application.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;
    private readonly ILogger _logger = Log.ForContext<AddressService>();
    public AddressService(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository ?? throw new ArgumentNullException(nameof(addressRepository));
    }
    /// <inheritdoc />
    public async Task<AddressModel> GetAddressById(int addressId)
    {
        var address = await _addressRepository.GetByIdAsync(addressId);
        var mapped = ObjectMapper.Mapper.Map<AddressModel>(address);
        return mapped;
    }
    /// <inheritdoc />
    public async Task<AddressModel> Create(AddressModel addressModel)
    {
        await ValidateAddressIfExist(addressModel);

        var mappedEntity = ObjectMapper.Mapper.Map<Address>(addressModel);
        if (mappedEntity == null)
            throw new ApplicationException("Entity could not be mapped.");

        var newEntity = await _addressRepository.AddAsync(mappedEntity);
        _logger.Information("Entity successfully added");

        var newMappedEntity = ObjectMapper.Mapper.Map<AddressModel>(newEntity);
        return newMappedEntity;
    }
    public async Task Update(AddressModel addressModel)
    {
        ValidateAddressIfNotExist(addressModel);

        var editAddress = await _addressRepository.GetByIdAsync(addressModel.Id);
        if (editAddress == null)
            throw new ApplicationException("Entity could not be loaded.");

        ObjectMapper.Mapper.Map<AddressModel, Address>(addressModel, editAddress);

        await _addressRepository.UpdateAsync(editAddress);
        _logger.Information("Entity successfully updated");
    }
    public async Task Delete(AddressModel addressModel)
    {
        ValidateAddressIfNotExist(addressModel);
        var deletedAddress = await _addressRepository.GetByIdAsync(addressModel.Id);
        if (deletedAddress == null)
            throw new ApplicationException("Entity could not be loaded.");

        await _addressRepository.DeleteAsync(deletedAddress);
        _logger.Information("Entity successfully deleted");
    }
    async private Task ValidateAddressIfExist(AddressModel addressModel)
    {
        var existingEntity = await _addressRepository.GetByIdAsync(addressModel.Id);
        if (existingEntity != null)
        {
            throw new ApplicationException($"{addressModel} with this Id already exists");
        }
    }
    async private Task ValidateAddressIfNotExist(AddressModel addressModel)
    {
        var existingEntity = await _addressRepository.GetByIdAsync(addressModel.Id);
        if (existingEntity == null)
            throw new ApplicationException($"{addressModel} with this id is not exists");
    }
}
