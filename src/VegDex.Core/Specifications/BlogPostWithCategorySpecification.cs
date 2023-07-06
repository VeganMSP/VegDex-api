namespace VegDex.Core.Specifications;

public sealed class BlogPostWithCategorySpecification : BaseSpecification<BlogPost>
{
    public BlogPostWithCategorySpecification() : base(null)
    {
        AddInclude(bp => bp.Category);
    }
}
