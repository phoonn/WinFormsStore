using DataModel.Entities;
using Interfaces.Logic;
using Interfaces.Repositories;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class UserLogic : IUserLogic<User>
    {
        private IUnitOfWork Unit;
        private IUserRepository<User> UserRepo;

        //public UsersLogic()
        //{
        //    DbContext context = new StoreDbContext();
        //    Unit = new UnitOfWork(context);
        //    UserRepo = new UserRepository(Unit, context);
        //}

        public UserLogic(IUnitOfWork Unit, IUserRepository<User> UserRepo)
        {
            this.Unit = Unit;
            this.UserRepo = UserRepo;
        }

        public List<User> Get()
        {
            return UserRepo.GetAll();
        }

        public User Login(string name,string password)
        {
            return UserRepo.Login(name,password);
        }

        public void Add(User user)
        {
            UserRepo.Save(user);
            Unit.SaveChanges();
        }

        public void Edit(User user)
        {
            UserRepo.Update(user);
            Unit.SaveChanges();
        }

        public void Delete(User user)
        {
            UserRepo.Delete(user);
            Unit.SaveChanges();
        }

        public User GetById(int id)
        {
            return UserRepo.GetById(id);
        }

        #region IDisposable Support
        private bool disposedValue = false; 

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Unit.Dispose();
                }
                

                disposedValue = true;
            }
        }
        
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion


    }
}
