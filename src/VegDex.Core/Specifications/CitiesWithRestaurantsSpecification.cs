namespace VegDex.Core.Specifications;

public sealed class CitiesWithRestaurantsSpecification : BaseSpecification<City>
{
    public CitiesWithRestaurantsSpecification() : base(c => c.Restaurants.Count > 0)
    {
        AddInclude(c => c.Restaurants);
    }
}
