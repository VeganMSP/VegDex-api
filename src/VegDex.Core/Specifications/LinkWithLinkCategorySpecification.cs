using VegDex.Core.Entities;
using VegDex.Core.Specifications.Base;

namespace VegDex.Core.Specifications;

public class LinkWithLinkCategorySpecification : BaseSpecification<Link>
{
    public LinkWithLinkCategorySpecification(string linkName) : base(l => l.Name.ToLower().Contains(linkName.ToLower()))
    {
        AddInclude(l => l.Category);
    }
    public LinkWithLinkCategorySpecification() : base(null)
    {
        AddInclude(l => l.Category);
    }
}
