namespace IbgeAPI.Data;

public class DataContext : DbContext
{
    public DbSet<Models.User> Users { get; set; }
    public DbSet<Models.Ibge> Ibge {  get; set; }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
    }
}
