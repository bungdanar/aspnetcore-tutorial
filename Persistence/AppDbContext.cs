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
                .UsingEntity(
                    "VehiclesFeatures",
                    l => l.HasOne(typeof(Feature)).WithMany().HasForeignKey("FeatureId").HasPrincipalKey(nameof(Feature.Id)),
                    r => r.HasOne(typeof(Vehicle)).WithMany().HasForeignKey("VehicleId").HasPrincipalKey(nameof(Vehicle.Id)),
                    j => j.HasKey("VehicleId", "FeatureId")
                );
        }
    }
}