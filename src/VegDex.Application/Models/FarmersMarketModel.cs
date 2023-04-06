using System.ComponentModel.DataAnnotations;
using VegDex.Application.Models.Base;

namespace VegDex.Application.Models;

public class FarmersMarketModel : BaseModel
{
    [Required] public AddressModel Address { get; set; }
    public string Hours { get; set; }
    [Required] public string Name { get; set; }
    public string Phone { get; set; }
    public string Slug { get; set; }
    public string Website { get; set; }
    /// <inheritdoc />
    public override string ToString() => Name;
}
