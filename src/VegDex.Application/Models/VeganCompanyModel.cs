namespace VegDex.Application.Models;

public class VeganCompanyModel : BaseModel
{
    public string? Description { get; set; }
    public string Name { get; set; }
    public string? Slug { get; set; }
    public string? Website { get; set; }
    /// <inheritdoc />
    public override string ToString() => Name;
}
