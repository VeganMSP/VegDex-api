using System.ComponentModel.DataAnnotations;
using VegDex.Application.Models.Base;

namespace VegDex.Application.Models;

public class BlogPostModel : BaseModel
{
    // public User Author { get; set; }
    [Required] public BlogCategoryModel Category { get; set; }
    [Required] public string Content { get; set; }
    public string Slug { get; set; }
    [Required] public int Status { get; set; }
    [Required] public string Title { get; set; }
}
