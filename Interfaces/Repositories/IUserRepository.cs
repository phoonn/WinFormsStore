namespace Interfaces.Repositories
{
    public interface IUserRepository<T> : IRepository<T> where T: class,IBaseEntity,new()
    {
        T Login(string username, string password);
    }
}
