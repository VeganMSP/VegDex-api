using System.ComponentModel.DataAnnotations;
using VegDex.Application.Models.Base;

namespace VegDex.Application.Models;

public class CityModel : BaseModel
{
    [Required] public string Name { get; set; }
    public string Slug { get; set; }
    public IEnumerable<RestaurantModel> Restaurants { get; set; }

    /// <inheritdoc />
    public override string ToString() => Name;
}
