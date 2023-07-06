namespace VegDex.Core.Specifications;

public sealed class LinkCategoryWithLinksByIdSpecification : BaseSpecification<LinkCategory>
{
    public LinkCategoryWithLinksByIdSpecification(int id) : base(lc => lc.Id == id)
    {
        AddInclude(lc => lc.Links);
    }
}
