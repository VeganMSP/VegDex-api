namespace VegDex.Application.Models;

public class FarmersMarketModel : BaseModel
{
    public string Address { get; set; }
    public string Hours { get; set; }
    public string Name { get; set; }
    public string? Phone { get; set; }
    public string? Slug { get; set; }
    public string? Website { get; set; }
    /// <inheritdoc/>
    public override string ToString() => Name;
}
