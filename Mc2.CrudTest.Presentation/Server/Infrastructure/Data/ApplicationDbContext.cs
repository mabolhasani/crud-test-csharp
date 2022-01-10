using Mc2.CrudTest.Presentation.Server.Core.Domain;

namespace Mc2.CrudTest.Presentation.Server.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State.Equals(EntityState.Added))
            {
                entry.Entity.Created = DateTime.UtcNow;
            }

            if (entry.State.Equals(EntityState.Modified))
            {
                entry.Entity.LastModified = DateTime.UtcNow;
            }
        }

        int result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}

