namespace aspnetcore_tutorial.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .HasMany(e => e.Features)
                .WithMany(e => e.Vehicles)
                .UsingEntity<VehicleFeature>(
                    l => l.HasOne<Feature>().WithMany().HasForeignKey(vf => vf.FeatureId),
                    r => r.HasOne<Vehicle>().WithMany().HasForeignKey(vf => vf.VehicleId)
                );
        }
    }
}