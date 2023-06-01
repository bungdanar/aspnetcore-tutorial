namespace aspnetcore_tutorial.Models
{
    [Table("Features")]
    public class Feature
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<VehicleFeature> VehicleFeatures { get; set; }

        public Feature()
        {
            Vehicles = new Collection<Vehicle>();
            VehicleFeatures = new Collection<VehicleFeature>();
        }
    }
}