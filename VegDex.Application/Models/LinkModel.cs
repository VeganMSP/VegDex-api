using System.ComponentModel.DataAnnotations;
using VegDex.Application.Models.Base;

namespace VegDex.Application.Models;

public class Link : BaseModel
{
    [Required] public LinkCategory Category { get; set; }
    public string Description { get; set; }
    [Required] public string Name { get; set; }
    public string Slug { get; set; }
    [Required] public string Website { get; set; }
    /// <inheritdoc />
    public override string ToString() => Name;
}
