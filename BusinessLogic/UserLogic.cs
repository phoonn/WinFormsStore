using DataModel.Entities;
using Interfaces.Logic;
using Interfaces.Repositories;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class UserLogic : BaseCrudLogic<User,IUserRepository>, IUserLogic
    {
        public UserLogic(IUserRepository UserRepo, IUnitOfWork Unit) : base(UserRepo,Unit)
        {
            this.Unit = Unit;
            this.Repo = UserRepo;
        }

        public User Login(string name,string password)
        {
            return Repo.Login(name,password);
        }
    }
}
