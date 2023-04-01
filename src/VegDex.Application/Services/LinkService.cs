using Serilog;
using VegDex.Application.Interfaces;
using VegDex.Application.Mapper;
using VegDex.Application.Models;
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
    public Task<LinkModel> GetLinkById(int linkId) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<LinkModel> Create(LinkModel link) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task Update(LinkModel link) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task Delete(LinkModel link) => throw new NotImplementedException();
}
