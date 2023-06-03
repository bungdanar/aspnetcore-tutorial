namespace aspnetcore_tutorial.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}