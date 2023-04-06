using VegDex.Core.Entities;
using VegDex.Core.Specifications.Base;

namespace VegDex.Core.Specifications;

public class LinkCategoryWithLinksByIdSpecification : BaseSpecification<LinkCategory>
{
    public LinkCategoryWithLinksByIdSpecification(int id) : base(lc => lc.Id == id)
    {
        AddInclude(lc => lc.Links);
    }
}
