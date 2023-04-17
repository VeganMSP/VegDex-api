namespace VegDex.Core.Entities;

public class Restaurant : Entity
{
    public Restaurant() { }
    public bool AllVegan { get; set; }
    public City City { get; set; }
    public int CityId { get; set; }
    public string? Description { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string? Website { get; set; }
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
            City = city,
            Description = description,
            Website = website,
            AllVegan = allVegan
        };
        return restaurant;
    }
}
