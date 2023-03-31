using VegDex.Core.Entities;
using VegDex.Core.Specifications.Base;

namespace VegDex.Core.Specifications;

public class LinkCategoryWithLinksSpecification : BaseSpecification<LinkCategory>
{
    public LinkCategoryWithLinksSpecification(int linkCategoryId) : base(lc => lc.Id == linkCategoryId)
    {
        AddInclude(lc => lc.Links);
    }
}
