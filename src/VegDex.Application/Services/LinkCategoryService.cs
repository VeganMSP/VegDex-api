using Serilog;
using VegDex.Application.Interfaces;
using VegDex.Application.Mapper;
using VegDex.Application.Models;
using VegDex.Core.Entities;
using VegDex.Core.Repositories;

namespace VegDex.Application.Services;

public class LinkCategoryService : ILinkCategoryService
{
    private static readonly ILogger _logger = Log.ForContext<LinkCategoryService>();
    private ILinkCategoryRepository _linkCategoryRepository;
    public LinkCategoryService(ILinkCategoryRepository linkCategoryRepository)
    {
        _linkCategoryRepository = linkCategoryRepository;
    }
    /// <inheritdoc />
    public async Task<IEnumerable<LinkCategoryModel>> GetLinkCategoryList()
    {
        var linkCategories = await _linkCategoryRepository.GetLinkCategories();
        var mapped = ObjectMapper.Mapper.Map<IEnumerable<LinkCategoryModel>>(linkCategories);
        return mapped;
    }
    /// <inheritdoc />
    public async Task<LinkCategoryModel> GetLinkCategoryById(int linkCategoryId)
    {
        var linkCategory = await _linkCategoryRepository.GetByIdAsync(linkCategoryId);
        var mapped = ObjectMapper.Mapper.Map<LinkCategoryModel>(linkCategory);
        return mapped;
    }
    /// <inheritdoc />
    public async Task<LinkCategoryModel> Create(LinkCategoryModel linkCategoryModel)
    {
        await ValidateLinkCategoryIfExist(linkCategoryModel);

        var mappedEntity = ObjectMapper.Mapper.Map<LinkCategory>(linkCategoryModel);
        if (mappedEntity == null)
            throw new ApplicationException("Entity could not be mapped");

        var newEntity = await _linkCategoryRepository.AddAsync(mappedEntity);
        _logger.Information("Entity successfully added: {@LinkCategory}", newEntity);

        var newMappedEntity = ObjectMapper.Mapper.Map<LinkCategoryModel>(newEntity);
        return newMappedEntity;
    }
    async private Task ValidateLinkCategoryIfExist(LinkCategoryModel linkCategoryModel)
    {
        var existingEntity = await _linkCategoryRepository.GetByIdAsync(linkCategoryModel.Id);
        if (existingEntity != null)
            throw new ApplicationException($"{linkCategoryModel} with this Id exists already");
    }
    /// <inheritdoc />
    public async Task Update(LinkCategoryModel linkCategoryModel)
    {
        ValidateLinkCategoryIfNotExist(linkCategoryModel);
        var editLinkCategory = await _linkCategoryRepository.GetByIdAsync(linkCategoryModel.Id);
        if (editLinkCategory == null)
            throw new ApplicationException("Entity could not be loaded");
        ObjectMapper.Mapper.Map(linkCategoryModel, editLinkCategory);
        await _linkCategoryRepository.UpdateAsync(editLinkCategory);
        _logger.Information("Entity successfully updated");
    }
    private void ValidateLinkCategoryIfNotExist(LinkCategoryModel linkCategoryModel)
    {
        var existingEntity = _linkCategoryRepository.GetByIdAsync(linkCategoryModel.Id);
        if (existingEntity == null)
            throw new ApplicationException($"{linkCategoryModel} with this Id does not exist");
    }
    /// <inheritdoc />
    public async Task Delete(LinkCategoryModel linkCategoryModel)
    {
        ValidateLinkCategoryIfNotExist(linkCategoryModel);
        var deletedLinkCategory = await _linkCategoryRepository.GetByIdAsync(linkCategoryModel.Id);
        if (deletedLinkCategory == null)
            throw new ApplicationException("Entity could not be loaded");
        await _linkCategoryRepository.DeleteAsync(deletedLinkCategory);
        _logger.Information("Entity successfully deleted");
    }
    /// <inheritdoc />
    public async Task<IEnumerable<LinkCategoryModel>> GetLinkCategoriesWithLinks()
    {
        var linkCategoriesWithLinks = await _linkCategoryRepository.GetLinkCategoriesWithLinks();
        var mapped = ObjectMapper.Mapper.Map<IEnumerable<LinkCategoryModel>>(linkCategoriesWithLinks);
        return mapped;
    }
    /// <inheritdoc />
    public async Task<LinkCategoryModel> GetLinkCategoryWithLinksById(int id)
    {
        var linkCategoryWithLinks = await _linkCategoryRepository.GetLinkCategoryWithLinksById(id);
        var mapped = ObjectMapper.Mapper.Map<LinkCategoryModel>(linkCategoryWithLinks);
        return mapped;
    }
}
