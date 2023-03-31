using VegDex.Application.Models;

namespace VegDex.Application.Interfaces;

public interface ILinkService
{
    Task<IEnumerable<LinkModel>> GetLinkList();
    Task<LinkModel> GetLinkById(int linkId);
    Task<LinkModel> Create(LinkModel link);
    Task Update(LinkModel link);
    Task Delete(LinkModel link);
}
