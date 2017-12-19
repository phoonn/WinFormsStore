using DataModel.Entities;
using Interfaces.Logic;
using Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessLogic
{
    public class OrderLogic : IOrderLogic
    {
        private IOrderRepository Orderrepo;
        private IUnitOfWork Unit;

        //public OrdersLogic()
        //{
        //    var Context = new StoreDbContext();
        //    this.Unit = new UnitOfWork(Context);
        //    this.Orderrepo = new OrderRepository(Unit, Context);
        //}

        public OrderLogic(IUnitOfWork Unit, IOrderRepository Orderrepo)
        {
            this.Unit = Unit;
            this.Orderrepo = Orderrepo;
        }

        public List<Order> GetOrders(Expression<Func<Order, bool>> filter = null,
            Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy = null,
            string includeProperties = "", int take = 0)
        {
            return Orderrepo.Get(filter, orderBy, includeProperties, take).ToList();
        }

        public List<Order> Get()
        {
            return Orderrepo.GetAll();
        }

        public List<Order> GetOrders(string firstname = default(string), string secondname = default(string), bool? SortByDate = null, int? id = 0, int? Day = 0, int? Month = 0, int? Year = 0)
        {
            return Orderrepo.Search(firstname, secondname, SortByDate, id, Day, Month, Year);
        }

        public void Add(Order order)
        {
            Orderrepo.Save(order);
            Unit.SaveChanges();
        }

        public void Edit(Order order)
        {
            Orderrepo.Update(order);
            Unit.SaveChanges();
        }

        public void Delete(Order order)
        {
            Orderrepo.Delete(order);
            Unit.SaveChanges();
        }

        public Order GetById(int id)
        {
            return Orderrepo.GetById(id);
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
