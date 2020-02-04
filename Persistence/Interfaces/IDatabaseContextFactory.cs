namespace Persistence.Interfaces
{
    public interface IDatabaseContextFactory<TContext>
    {
        public TContext CreateDatabaseContext();
    }
}