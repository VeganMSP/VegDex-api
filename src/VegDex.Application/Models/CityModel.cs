namespace VegDex.Application.Models;

public class CityModel : BaseModel
{
    public string Name { get; set; }
    public IEnumerable<RestaurantModel>? Restaurants { get; set; }
    public string? Slug { get; set; }
    /// <inheritdoc/>
    public override string ToString() => Name;
}
