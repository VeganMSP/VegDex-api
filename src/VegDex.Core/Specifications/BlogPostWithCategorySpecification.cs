namespace VegDex.Core.Specifications;

public class BlogPostWithCategorySpecification : BaseSpecification<BlogPost>
{
    public BlogPostWithCategorySpecification() : base(null)
    {
        AddInclude(bp => bp.Category);
    }
}
