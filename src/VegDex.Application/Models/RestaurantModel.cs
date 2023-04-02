using System.ComponentModel.DataAnnotations;
using VegDex.Application.Models.Base;

namespace VegDex.Application.Models;

public class RestaurantModel : BaseModel
{
    public bool AllVegan { get; set; }
    public string Description { get; set; }
    [Required] public CityModel City { get; set; }
    public int CityId { get; set; }
    [Required] public string Name { get; set; }
    public string Slug { get; set; }
    public string Website { get; set; }
    /// <inheritdoc />
    public override string ToString() => Name;
}
