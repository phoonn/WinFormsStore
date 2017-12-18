namespace Interfaces.Repositories
{
    public interface ISerialNumberRepository<T> : IRepository<T> where T : class, IBaseEntity, new()
    {
        T FindByName(string name);
    }
}
