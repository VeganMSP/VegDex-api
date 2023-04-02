using VegDex.Core.Entities.Base;

namespace VegDex.Core.Entities;

public class Link : Entity
{
    public Link() { }
    public int LinkCategoryId { get; set; }
    public LinkCategory Category { get; set; }
    public string? Description { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string Website { get; set; }
    public static Link Create(
        int linkId,
        string name,
        string website,
        LinkCategory linkCategory,
        string? description = null)
    {
        var link = new Link
        {
            Id = linkId,
            Category = linkCategory,
            Name = name,
            Website = website,
            Description = description
        };
        return link;
    }
}
