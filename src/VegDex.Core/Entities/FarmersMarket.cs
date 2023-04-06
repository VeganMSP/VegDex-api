using VegDex.Core.Entities.Base;

namespace VegDex.Core.Entities;

public class FarmersMarket : Entity
{
    public FarmersMarket() { }
    public string? Address { get; set; }
    public string? Hours { get; set; }
    public string Name { get; set; }
    public string? Phone { get; set; }
    public string Slug { get; set; }
    public string? Website { get; set; }
    public static FarmersMarket Create(
        int farmersMarketId,
        string name,
        string? address,
        string? hours = null,
        string? phone = null,
        string? website = null)
    {
        var farmersMarket = new FarmersMarket
        {
            Id = farmersMarketId,
            Name = name,
            Address = address,
            Hours = hours,
            Phone = phone,
            Website = website
        };
        return farmersMarket;
    }
}
