using System.ComponentModel.DataAnnotations;
using VegDex.Application.Models.Base;

namespace VegDex.Application.Models.Blog;

public class BlogPost : BaseModel
{
    // public User Author { get; set; }
    [Required] public BlogCategory Category { get; set; }
    [Required] public string Content { get; set; }
    public string Slug { get; set; }
    [Required] public int Status { get; set; }
    [Required] public string Title { get; set; }
}
