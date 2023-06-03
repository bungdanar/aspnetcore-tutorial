namespace aspnetcore_tutorial.Core.Models
{
    [Table("Vehicles")]
    public class Vehicle
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public bool IsRegistered { get; set; }
        public Contact Contact { get; set; }
        public DateTime LastUpdated { get; set; }
        public ICollection<Feature> Features { get; set; }
        public ICollection<VehicleFeature> VehicleFeatures { get; set; }

        public Vehicle()
        {
            Features = new Collection<Feature>();
            VehicleFeatures = new Collection<VehicleFeature>();
        }
    }
}