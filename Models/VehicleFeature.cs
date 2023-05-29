namespace aspnetcore_tutorial.Models
{
    [Table("VehiclesFeatures")]
    public class VehicleFeature
    {
        public int VehicleId { get; set; }
        public int FeatureId { get; set; }
    }
}