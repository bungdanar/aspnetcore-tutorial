namespace aspnetcore_tutorial.Core
{
    public interface IMakeRepository
    {
        Task<List<Make>> GetMakes();
    }
}