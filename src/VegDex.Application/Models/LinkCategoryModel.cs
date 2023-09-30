namespace VegDex.Application.Models;

public class LinkCategoryModel : BaseModel
{
    public string? Description { get; set; }
    public IEnumerable<LinkModel>? Links { get; set; }
    public string Name { get; set; }
    public string? Slug { get; set; }
    /// <inheritdoc/>
    public override string ToString() => Name;
}
