namespace VegDex.Application.Services;

public class VeganCompanyService : IVeganCompanyService
{
    private static readonly ILogger _logger = Log.ForContext<VeganCompanyService>();
    private IVeganCompanyRepository _veganCompanyRepository;
    public VeganCompanyService(IVeganCompanyRepository veganCompanyRepository)
    {
        _veganCompanyRepository = veganCompanyRepository;
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<VeganCompanyModel>> GetVeganCompanies()
    {
        var veganCompanies = await _veganCompanyRepository.GetVeganCompanies();
        var mapped = ObjectMapper.Mapper.Map<IEnumerable<VeganCompanyModel>>(veganCompanies);
        return mapped;
    }
    /// <inheritdoc/>
    public async Task<VeganCompanyModel> GetVeganCompanyById(int veganCompanyId)
    {
        var veganCompany = await _veganCompanyRepository.GetByIdAsync(veganCompanyId);
        var mapped = ObjectMapper.Mapper.Map<VeganCompanyModel>(veganCompany);
        return mapped;
    }
    /// <inheritdoc/>
    public async Task<VeganCompanyModel> Create(VeganCompanyModel veganCompanyModel)
    {
        await ValidateVeganCompanyIfExist(veganCompanyModel);
        var mappedEntity = ObjectMapper.Mapper.Map<VeganCompany>(veganCompanyModel);
        if (mappedEntity == null)
            throw new ApplicationException("Entity could not be mapped");
        var newEntity = await _veganCompanyRepository.AddAsync(mappedEntity);
        _logger.Information("Entity successfully added: {@VeganCompany}", newEntity);

        var newMappedEntity = ObjectMapper.Mapper.Map<VeganCompanyModel>(newEntity);
        return newMappedEntity;
    }
    /// <inheritdoc/>
    public async Task Update(VeganCompanyModel veganCompanyModel)
    {
        ValidateVeganCompanyIfNotExist(veganCompanyModel);
        var editVeganCompany = await _veganCompanyRepository.GetByIdAsync(veganCompanyModel.Id);
        if (editVeganCompany == null)
            throw new ApplicationException("Entity could not be loaded");
        ObjectMapper.Mapper.Map(veganCompanyModel, editVeganCompany);
        await _veganCompanyRepository.UpdateAsync(editVeganCompany);
        _logger.Information("Entity successfully updated");
    }
    /// <inheritdoc/>
    public async Task Delete(VeganCompanyModel veganCompanyModel)
    {
        ValidateVeganCompanyIfNotExist(veganCompanyModel);
        var deletedVeganCompany = await _veganCompanyRepository.GetByIdAsync(veganCompanyModel.Id);
        if (deletedVeganCompany == null)
            throw new ApplicationException("Entity could not be loaded");
        await _veganCompanyRepository.DeleteAsync(deletedVeganCompany);
        _logger.Information("Entity successfully deleted");
    }
    async private Task ValidateVeganCompanyIfExist(VeganCompanyModel veganCompany)
    {
        var existingEntity = await _veganCompanyRepository.GetByIdAsync(veganCompany.Id);
        if (existingEntity != null)
            throw new ApplicationException($"{veganCompany} with this Id exists already");
    }
    private void ValidateVeganCompanyIfNotExist(VeganCompanyModel veganCompanyModel)
    {
        var existingEntity = _veganCompanyRepository.GetByIdAsync(veganCompanyModel.Id);
        if (existingEntity == null)
            throw new ApplicationException($"{veganCompanyModel} with this Id does not exist");
    }
}
