using System.ComponentModel;

namespace VegDex.Application.Models;

public enum PostStatus
{
    Draft,
    Published
}
public class BlogPostModel : BaseModel
{
    // public User Author { get; set; }
    [DisplayName("Blog Category")] public int BlogCategoryId { get; set; }
    public BlogCategoryModel? Category { get; set; }
    public string Content { get; set; }
    public string? Slug { get; set; }
    public PostStatus Status { get; set; }
    public string Title { get; set; }
}
