using VegDex.Core.Entities;
using VegDex.Core.Specifications.Base;

namespace VegDex.Core.Specifications;

public class BlogPostWithCategorySpecification : BaseSpecification<BlogPost>
{
    public BlogPostWithCategorySpecification() : base(null)
    {
        AddInclude(bp => bp.Category);
    }
}
