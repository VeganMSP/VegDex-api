using VegDex.Application.Interfaces;
using VegDex.Application.Models;

namespace VegDex.Application.Services;

public class LinkCategoryService : ILinkCategoryService
{
    /// <inheritdoc />
    public Task<IEnumerable<LinkCategoryModel>> GetLinkCategoryList() => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<LinkCategoryModel> GetLinkCategoryById(int linkCategoryId) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<LinkCategoryModel> Create(LinkCategoryModel linkCategory) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task Update(LinkCategoryModel linkCategory) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task Delete(LinkCategoryModel linkCategory) => throw new NotImplementedException();
}
