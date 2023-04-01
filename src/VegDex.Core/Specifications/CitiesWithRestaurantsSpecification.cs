using VegDex.Core.Entities;
using VegDex.Core.Specifications.Base;

namespace VegDex.Core.Specifications;

public class CitiesWithRestaurantsSpecification : BaseSpecification<City>
{
    public CitiesWithRestaurantsSpecification() : base(c => c.Restaurants.Count > 0)
    {
        AddInclude(c => c.Restaurants);
    }
}
