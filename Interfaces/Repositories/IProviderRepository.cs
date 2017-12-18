namespace Interfaces.Repositories
{
    public interface IProviderRepository<T> : IRepository<T> where T : class, IBaseEntity, new()
    {
        T FindByName(string name);
    }
}
