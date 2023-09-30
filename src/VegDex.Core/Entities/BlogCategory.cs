namespace VegDex.Core.Entities;

public class BlogCategory : Entity
{
    public ICollection<BlogPost> BlogPosts;
    public BlogCategory()
    {
        BlogPosts = new HashSet<BlogPost>();
    }
    public string Name { get; set; }
    public string Slug { get; set; }
    public static BlogCategory Create(int blogCategoryId, string name)
    {
        var blogCategory = new BlogCategory
        { Id = blogCategoryId,
          Name = name };
        return blogCategory;
    }
}
