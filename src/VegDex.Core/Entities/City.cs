using VegDex.Core.Entities.Base;

namespace VegDex.Core.Entities;

public class City : Entity
{
    public City()
    {
        Restaurants = new HashSet<Restaurant>();
    }
    public string Name { get; set; }
    public ICollection<Restaurant> Restaurants { get; private set; }
    public string Slug { get; set; }
    public static City Create(int cityId, string name)
    {
        var city = new City
        {
            Id = cityId,
            Name = name
        };
        return city;
    }
}
