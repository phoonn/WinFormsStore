using DataModel.Entities;

namespace Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User Login(string username, string password);
    }
}
