namespace aspnetcore_tutorial.Persistence
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly AppDbContext context;
        public VehicleRepository(AppDbContext context)
        {
            this.context = context;

        }

        public async Task<Vehicle?> GetVehicle(int id)
        {
            return await context.Vehicles
                                .Include(v => v.Features)
                                .Include(v => v.Model)
                                    .ThenInclude(m => m.Make)
                                .SingleOrDefaultAsync(v => v.Id == id);
        }
    }
}