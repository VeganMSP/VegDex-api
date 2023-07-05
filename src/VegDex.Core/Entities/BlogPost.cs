namespace VegDex.Core.Entities;

public class BlogPost : Entity
{
    public BlogPost() { }
    public int BlogCategoryId { get; set; }
    public BlogCategory Category { get; set; }
    public string Content { get; set; }
    public string Slug { get; set; }
    public int Status { get; set; }
    public string Title { get; set; }
    public static BlogPost Create(int blogPostId, string title, string content, BlogCategory blogCategory, int status)
    {
        var blogPost = new BlogPost
        {
            Id = blogPostId,
            Title = title,
            Content = content,
            Category = blogCategory,
            Status = status
        };
        return blogPost;
    }
}
