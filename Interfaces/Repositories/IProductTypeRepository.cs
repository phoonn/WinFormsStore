namespace Interfaces.Repositories
{
    public interface IProductTypeRepository<T> : IRepository<T> where T : class, IBaseEntity, new()
    {
        T FindByName(string name);
    }
}
