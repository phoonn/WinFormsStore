using System.Linq;
using DataModel.Entities;
using Interfaces.Repositories;
using System.Data.Entity;

namespace DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User> , IUserRepository
    {
        public User Login(string username, string password)
        {
            return Items.FirstOrDefault(i => i.Username == username && i.Password == password);
        }

        public UserRepository(IUnitOfWork unit, DbContext context) : base(unit, context)
        { }
    }
}
