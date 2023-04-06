using Serilog;
using VegDex.Application.Interfaces;
using VegDex.Application.Mapper;
using VegDex.Application.Models;
using VegDex.Core.Entities;
using VegDex.Core.Repositories;

namespace VegDex.Application.Services;

public class BlogCategoryService : IBlogCategoryService
{
    private static readonly ILogger _logger = Log.ForContext<BlogCategoryService>();
    private IBlogCategoryRepository _blogCategoryRepository;
    public BlogCategoryService(IBlogCategoryRepository blogCategoryRepository)
    {
        _blogCategoryRepository = blogCategoryRepository;
    }
    /// <inheritdoc />
    public async Task<IEnumerable<BlogCategoryModel>> GetBlogCategories()
    {
        var blogCategories = await _blogCategoryRepository.GetBlogCategories();
        var mapped = ObjectMapper.Mapper.Map<IEnumerable<BlogCategoryModel>>(blogCategories);
        return mapped;
    }
    /// <inheritdoc />
    public async Task<BlogCategoryModel> GetBlogCategoryById(int blogCategoryId)
    {
        var category = await _blogCategoryRepository.GetByIdAsync(blogCategoryId);
        var mapped = ObjectMapper.Mapper.Map<BlogCategoryModel>(category);
        return mapped;
    }
    /// <inheritdoc />
    public async Task<BlogCategoryModel> Create(BlogCategoryModel blogCategoryModel)
    {
        await ValidateBlogCategoryIfExist(blogCategoryModel);

        var mappedEntity = ObjectMapper.Mapper.Map<BlogCategory>(blogCategoryModel);
        if (mappedEntity == null)
            throw new ApplicationException("Entity could not be mapped");

        var newEntity = await _blogCategoryRepository.AddAsync(mappedEntity);
        _logger.Information("Tntiy successfully added: {@BlogCategory}", newEntity);

        var newMappedEntity = ObjectMapper.Mapper.Map<BlogCategoryModel>(newEntity);
        return newMappedEntity;
    }
    /// <inheritdoc />
    public async Task Update(BlogCategoryModel blogCategoryModel)
    {
        ValidateBlogCategoryIfNotExist(blogCategoryModel);
        var editBlogCategory = await _blogCategoryRepository.GetByIdAsync(blogCategoryModel.Id);
        if (editBlogCategory == null)
            throw new ApplicationException("Entity could not be loaded");
        ObjectMapper.Mapper.Map(blogCategoryModel, editBlogCategory);
        await _blogCategoryRepository.UpdateAsync(editBlogCategory);
        _logger.Information("Entity successfully updated");
    }
    /// <inheritdoc />
    public async Task Delete(BlogCategoryModel blogCategoryModel)
    {
        ValidateBlogCategoryIfNotExist(blogCategoryModel);
        var deletedBlogCategory = await _blogCategoryRepository.GetByIdAsync(blogCategoryModel.Id);
        if (deletedBlogCategory == null)
            throw new ApplicationException("Entity could not be loaded");
        await _blogCategoryRepository.DeleteAsync(deletedBlogCategory);
        _logger.Information("Entity successfully deleted");
    }
    async private Task ValidateBlogCategoryIfExist(BlogCategoryModel blogCategoryModel)
    {
        var existingEntity = await _blogCategoryRepository.GetByIdAsync(blogCategoryModel.Id);
        if (existingEntity != null)
            throw new ApplicationException($"{blogCategoryModel} with this Id exists already");
    }
    private void ValidateBlogCategoryIfNotExist(BlogCategoryModel blogCategoryModel)
    {
        var existingEntity = _blogCategoryRepository.GetByIdAsync(blogCategoryModel.Id);
        if (existingEntity == null)
            throw new ApplicationException($"{blogCategoryModel} with this Id does not exist");
    }
}
