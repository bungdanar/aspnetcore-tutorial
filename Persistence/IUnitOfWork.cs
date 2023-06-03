namespace aspnetcore_tutorial.Persistence
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}