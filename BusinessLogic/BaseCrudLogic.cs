using DataModel.Entities;
using Interfaces;
using Interfaces.Logic;
using Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class BaseCrudLogic<T,F> : ICrudLogic<T> where T: BaseEntity,new() where F: IRepository<T>
    {
        internal F Repo;
        internal IUnitOfWork Unit;

        public BaseCrudLogic(F Repo,IUnitOfWork Unit)
        {
            this.Repo = Repo;
            this.Unit = Unit;
        }

        public virtual void Add(T Item)
        {
            Repo.Save(Item);
            Unit.SaveChanges();
        }

        public virtual void Delete(T Item)
        {
            Repo.Delete(Item);
            Unit.SaveChanges();
        }

        public virtual void Edit(T Item)
        {
            Repo.Update(Item);
            Unit.SaveChanges();
        }

        public virtual List<T> Get()
        {
            return Repo.Get().ToList();
        }

        public virtual T GetById(int id)
        {
            return Repo.GetById(id);
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
