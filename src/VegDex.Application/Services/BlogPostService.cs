namespace VegDex.Application.Services;

public class BlogPostService : IBlogPostService
{
    private static readonly ILogger _logger = Log.ForContext<BlogPostService>();
    private readonly IBlogPostRepository _blogPostRepository;
    public BlogPostService(IBlogPostRepository blogPostRepository)
    {
        _blogPostRepository = blogPostRepository;
    }
    /// <inheritdoc/>
    public Task<IEnumerable<BlogPostModel>> GetBlogCategoryList() => throw new NotImplementedException();
    /// <inheritdoc/>
    public Task<BlogPostModel> GetBlogCategoryById(int blogCategoryId) => throw new NotImplementedException();
    /// <inheritdoc/>
    public async Task<BlogPostModel> Create(BlogPostModel blogPostModel)
    {
        await ValidateBlogPostIfExist(blogPostModel);
        var mappedEntity = ObjectMapper.Mapper.Map<BlogPost>(blogPostModel);
        if (mappedEntity == null)
            throw new ApplicationException("Entity could not be mapped");
        var newEntity = await _blogPostRepository.AddAsync(mappedEntity);
        _logger.Information("Entity successfully added: {@BlogPost}", newEntity);

        var newMappedEntity = ObjectMapper.Mapper.Map<BlogPostModel>(newEntity);
        return newMappedEntity;
    }
    /// <inheritdoc/>
    public async Task Update(BlogPostModel blogPostModel)
    {
        ValidateBlogPostIfNotExist(blogPostModel);
        var editBlogPost = await _blogPostRepository.GetByIdAsync(blogPostModel.Id);
        if (editBlogPost == null)
            throw new ApplicationException("Entity could not be loaded");
        ObjectMapper.Mapper.Map(blogPostModel, editBlogPost);
        await _blogPostRepository.UpdateAsync(editBlogPost);
        _logger.Information("Entity successfully updated");
    }
    /// <inheritdoc/>
    public async Task<BlogPostModel> GetBlogPostById(int id)
    {
        var blogPost = await _blogPostRepository.GetByIdAsync(id);
        var mapped = ObjectMapper.Mapper.Map<BlogPostModel>(blogPost);
        return mapped;
    }
    /// <inheritdoc/>
    public async Task Delete(BlogPostModel blogPostModel)
    {
        ValidateBlogPostIfNotExist(blogPostModel);
        var deletedBlogPost = await _blogPostRepository.GetByIdAsync(blogPostModel.Id);
        if (deletedBlogPost == null)
            throw new ApplicationException("Entity could not be loaded");
        await _blogPostRepository.DeleteAsync(deletedBlogPost);
        _logger.Information("Entity successfully deleted");
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<BlogPostModel>> GetBlogPosts()
    {
        var blogPosts = await _blogPostRepository.GetBlogPosts();
        var mapped = ObjectMapper.Mapper.Map<IEnumerable<BlogPostModel>>(blogPosts);
        return mapped;
    }
    async private Task ValidateBlogPostIfExist(BlogPostModel blogPostModel)
    {
        var existingEntity = await _blogPostRepository.GetByIdAsync(blogPostModel.Id);
        if (existingEntity != null)
            throw new ApplicationException($"{blogPostModel} with this Id exists already");
    }
    private void ValidateBlogPostIfNotExist(BlogPostModel blogPostModel)
    {
        var existingEntity = _blogPostRepository.GetByIdAsync(blogPostModel.Id);
        if (existingEntity == null)
            throw new ApplicationException($"{blogPostModel} with this Id does not exist");
    }
}
