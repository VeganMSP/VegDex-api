namespace VegDex.Core.Specifications;

public sealed class LinkCategoriesWithLinksSpecification : BaseSpecification<LinkCategory>
{
    public LinkCategoriesWithLinksSpecification() : base(lc => lc.Links.Count > 0)
    {
        AddInclude(lc => lc.Links);
    }
}
