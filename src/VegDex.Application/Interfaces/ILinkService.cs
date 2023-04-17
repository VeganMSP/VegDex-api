namespace VegDex.Application.Interfaces;

public interface ILinkService
{
    Task<LinkModel> Create(LinkModel link);
    Task Delete(LinkModel link);
    Task<LinkModel> GetLinkById(int? linkId);
    Task<LinkModel> GetLinkByName(string linkName);
    Task<IEnumerable<LinkModel>> GetLinkList();
    Task Update(LinkModel link);
}
