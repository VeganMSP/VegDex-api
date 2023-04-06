using VegDex.Core.Entities;
using VegDex.Core.Specifications.Base;

namespace VegDex.Core.Specifications;

public class LinkCategoriesWithLinksSpecification : BaseSpecification<LinkCategory>
{
    public LinkCategoriesWithLinksSpecification() : base(lc => lc.Links.Count > 0)
    {
        AddInclude(lc => lc.Links);
    }
}
