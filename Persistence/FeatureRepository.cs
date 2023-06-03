namespace aspnetcore_tutorial.Persistence
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly AppDbContext context;
        public FeatureRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Feature>> GetFeatures()
        {
            return await context.Features.ToListAsync();
        }
    }
}