using System.ComponentModel.DataAnnotations;
using VegDex.Application.Models.Base;

namespace VegDex.Application.Models;

public class City : BaseModel
{
    [Required] public string Name { get; set; }
    public string Slug { get; set; }
    /// <inheritdoc />
    public override string ToString() => Name;
}
