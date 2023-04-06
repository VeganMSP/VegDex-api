using Serilog;
using VegDex.Application.Interfaces;
using VegDex.Application.Mapper;
using VegDex.Application.Models;
using VegDex.Core.Entities;
using VegDex.Core.Repositories;

namespace VegDex.Application.Services;

public class LinkService : ILinkService
{
    private static readonly ILogger _logger = Log.ForContext<LinkService>();
    private readonly ILinkRepository _linkRepository;
    public LinkService(ILinkRepository linkRepository)
    {
        _linkRepository = linkRepository;
    }
    /// <inheritdoc />
    public Task<LinkModel> GetLinkByName(string linkName) => throw new NotImplementedException();
    /// <inheritdoc />
    public async Task<IEnumerable<LinkModel>> GetLinkList()
    {
        var linkList = await _linkRepository.GetLinkListAsync();
        var mapped = ObjectMapper.Mapper.Map<IEnumerable<LinkModel>>(linkList);
        return mapped;
    }
    /// <inheritdoc />
    public async Task<LinkModel> GetLinkById(int? linkId)
    {
        var link = await _linkRepository.GetByIdAsync(linkId);
        var mapped = ObjectMapper.Mapper.Map<LinkModel>(link);
        return mapped;
    }
    /// <inheritdoc />
    public async Task<LinkModel> Create(LinkModel linkModel)
    {
        await ValidateLinkIfExist(linkModel);

        var mappedEntity = ObjectMapper.Mapper.Map<Link>(linkModel);
        if (mappedEntity == null)
            throw new ApplicationException("Entity could not be mapped");

        var newEntity = await _linkRepository.AddAsync(mappedEntity);
        _logger.Information("Entity successfully added: {@Link}", newEntity);

        var newMappedEntity = ObjectMapper.Mapper.Map<LinkModel>(newEntity);
        return newMappedEntity;
    }
    /// <inheritdoc />
    public async Task Update(LinkModel linkModel)
    {
        ValidateLinkIfNotExist(linkModel);
        var editLink = await _linkRepository.GetByIdAsync(linkModel.Id);
        if (editLink == null)
            throw new ApplicationException("Entity could not be loaded.");
        ObjectMapper.Mapper.Map(linkModel, editLink);
        await _linkRepository.UpdateAsync(editLink);
        _logger.Information("Entity successfully updated");
    }
    /// <inheritdoc />
    public async Task Delete(LinkModel linkModel)
    {
        ValidateLinkIfNotExist(linkModel);
        var deletedLink = await _linkRepository.GetByIdAsync(linkModel.Id);
        if (deletedLink == null)
            throw new ApplicationException("Entity could not be loaded.");
        await _linkRepository.DeleteAsync(deletedLink);
        _logger.Information("Entity successfully deleted");
    }
    async private Task ValidateLinkIfExist(LinkModel linkModel)
    {
        var existingEntity = await _linkRepository.GetByIdAsync(linkModel.Id);
        if (existingEntity != null)
            throw new ApplicationException($"{linkModel} with this Id exists already");
    }
    private void ValidateLinkIfNotExist(LinkModel linkModel)
    {
        var existingEntity = _linkRepository.GetByIdAsync(linkModel.Id);
        if (existingEntity == null)
            throw new ApplicationException($"{linkModel} with this Id does not exist");
    }
}
