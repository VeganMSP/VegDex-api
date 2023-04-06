using VegDex.Application.Models.Base;

namespace VegDex.Application.Models;

public class LinkModel : BaseModel
{
    public int LinkCategoryId { get; set; }
    public LinkCategoryModel? Category { get; set; }
    public string? Description { get; set; }
    public string Name { get; set; }
    public string? Slug { get; set; }
    public string Website { get; set; }
    /// <inheritdoc />
    public override string ToString() => Name;
}
