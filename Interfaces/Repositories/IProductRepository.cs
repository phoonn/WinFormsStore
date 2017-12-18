namespace Interfaces.Repositories
{
    public interface IProductRepository<T> : IRepository<T> where T:class,IBaseEntity,new()
    {
    }
}
