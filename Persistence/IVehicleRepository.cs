namespace aspnetcore_tutorial.Persistence
{
    public interface IVehicleRepository
    {
        Task<Vehicle?> GetVehicle(int id);
    }
}