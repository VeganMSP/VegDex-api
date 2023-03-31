using VegDex.Core.Entities.Base;

namespace VegDex.Core.Entities;

public class Restaurant : Entity
{
    public Restaurant() { }
    public bool AllVegan { get; set; }
    public string Description { get; set; }
    public City Location { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string Website { get; set; }
    public static Restaurant Create(
        int restaurantId,
        string name,
        City city,
        string description = null,
        string website = null,
        bool allVegan = false)
    {
        var restaurant = new Restaurant
        {
            Id = restaurantId,
            Name = name,
            Location = city,
            Description = description,
            Website = website,
            AllVegan = allVegan
        };
        return restaurant;
    }
}