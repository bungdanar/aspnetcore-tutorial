namespace aspnetcore_tutorial.Core
{
    public interface IFeatureRepository
    {
        Task<List<Feature>> GetFeatures();
    }
}