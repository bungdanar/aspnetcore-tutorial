namespace aspnetcore_tutorial.Persistence
{
    public class MakeRepository : IMakeRepository
    {
        private readonly AppDbContext context;
        public MakeRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Make>> GetMakes()
        {
            return await context.Makes.Include(m => m.Models).ToListAsync();
        }
    }
}