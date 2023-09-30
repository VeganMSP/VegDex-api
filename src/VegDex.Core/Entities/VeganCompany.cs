namespace VegDex.Core.Entities;

public class VeganCompany : Entity
{
    public string? Description { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string? Website { get; set; }
    public static VeganCompany Create(
        int veganCompanyId,
        string name,
        string? description = null,
        string? website = null)
    {
        var veganCompany = new VeganCompany
        { Id = veganCompanyId,
          Name = name,
          Description = description,
          Website = website };
        return veganCompany;
    }
}
