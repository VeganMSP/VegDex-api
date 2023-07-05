namespace VegDex.Application.Models;

public class BlogCategoryModel : BaseModel
{
    public string Name { get; set; }
    public string? Slug { get; set; }
    /// <inheritdoc />
    public override string ToString() => Name;
}
