using VegDex.Core.Entities.Base;

namespace VegDex.Core.Entities;

public class LinkCategory : Entity
{
    public LinkCategory()
    {
        Links = new HashSet<Link>();
    }
    public string? Description { get; set; }
    public ICollection<Link> Links { get; private set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public static LinkCategory Create(int linkCategoryId, string name, string? description = null)
    {
        var linkCategory = new LinkCategory
        {
            Id = linkCategoryId,
            Name = name,
            Description = description
        };
        return linkCategory;
    }
}
