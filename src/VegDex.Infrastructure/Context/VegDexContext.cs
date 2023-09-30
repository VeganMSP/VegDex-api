namespace VegDex.Infrastructure.Context;

public class VegDexContext : DbContext
{
    public VegDexContext(DbContextOptions<VegDexContext> options) : base(options) { }
    public DbSet<Restaurant> Restaurant { get; set; }
    /// <inheritdoc/>
    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>().ToTable("City");
        modelBuilder.Entity<FarmersMarket>().ToTable("FarmersMarket");
        modelBuilder.Entity<LinkCategory>().ToTable("LinkCategory");
        modelBuilder.Entity<Link>().ToTable("Link");
        modelBuilder.Entity<Restaurant>().ToTable("Restaurant");
        modelBuilder.Entity<VeganCompany>().ToTable("VeganCompany");
        modelBuilder.Entity<BlogPost>().ToTable("BlogPost");
        modelBuilder.Entity<BlogCategory>().ToTable("BlogCategory");
        modelBuilder.Entity<User>().ToTable("Users")
            .HasIndex(u => u.Username).IsUnique();
        modelBuilder.Entity<HomePage>().ToTable("HomePage")
            .HasData(new HomePage
            { Id = 1,
              Content = """
                        It’s easy being vegan in Minneapolis and St. Paul, but it can be hard to
                        know where to start, or where to look for information and answers. We
                        aim to fix that.

                        At VeganMSP.com you will find restaurant and food guides, shopping
                        guides, and other information to help you on your vegan journey.
                        """,
              DateCreated = DateTime.Now,
              DateUpdated = DateTime.Now });
        modelBuilder.Entity<AboutPage>().ToTable("AboutPage")
            .HasData(new AboutPage
            { Id = 1,
              Content = """
                        VeganMSP.com is a new project from <a href="https://jrgnsn.net" target="_blank">Matthew Jorgensen</a>. Inspired
                        by <a href="https://veganmilwaukee.com/" target="_blank">VeganMKE.com</a>, this site aims to be a complete-as-possible
                        guide to being vegan in and around the Minneapolis/St. Paul area. But
                        we're always welcome to suggestions! Find something wrong? Feel free to
                        <a href="https://github.com/VeganMSP/VeganMSP.com/issues">open a ticket</a> on our tracker.
                        """,
              DateCreated = DateTime.Now,
              DateUpdated = DateTime.Now });
    }
}
