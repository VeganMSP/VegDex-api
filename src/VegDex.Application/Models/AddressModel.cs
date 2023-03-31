using System.ComponentModel.DataAnnotations;
using VegDex.Application.Models.Base;

namespace VegDex.Application.Models;

public class AddressModel : BaseModel
{
    [Required] public CityModel City { get; set; }
    public string Name { get; set; }
    public string State { get; set; }
    public string Street1 { get; set; }
    public string Street2 { get; set; }
    public string ZipCode { get; set; }
    /// <inheritdoc />
    public override string ToString() => !string.IsNullOrWhiteSpace(Name) ? Name
        : !string.IsNullOrWhiteSpace(Street1) ? Street1
        : City.Name;
}
