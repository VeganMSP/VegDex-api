using System.ComponentModel.DataAnnotations;
using VegDex.Application.Models.Base;

namespace VegDex.Application.Models;

public class LinkCategory : BaseModel
{
    public string Description { get; set; }
    [Required] public string Name { get; set; }
    public string Slug { get; set; }
}
