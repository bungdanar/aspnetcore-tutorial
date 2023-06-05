namespace aspnetcore_tutorial.Persistence
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly AppDbContext context;
        public PhotoRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Photo>> GetPhotos(int vehicleId)
        {
            return await context.Photos.Where(p => p.VehicleId == vehicleId).ToListAsync();
        }
    }
}