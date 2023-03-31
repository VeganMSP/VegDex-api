using VegDex.Application.Interfaces;
using VegDex.Application.Models;

namespace VegDex.Application.Services;

public class LinkService : ILinkService
{
    /// <inheritdoc />
    public Task<IEnumerable<LinkModel>> GetLinkList() => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<LinkModel> GetLinkById(int linkId) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<LinkModel> Create(LinkModel link) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task Update(LinkModel link) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task Delete(LinkModel link) => throw new NotImplementedException();
}
