using DataModel.Entities;
using Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Repositories
{
    public class OrderRepository : BaseRepository<Order> , IOrderRepository
    {
        public List<Order> Search(string firstname, string secondname,bool? SortByDate, int? id , int? Day , int? Month, int? Year)
        {
            IQueryable<Order> query = Items;
            //if (!String.IsNullOrEmpty(firstname)||!String.IsNullOrEmpty(secondname)||date!=default(DateTime))
            //{
            //   query = query.Where(i => (i.FirstName.Contains(firstname) || string.IsNullOrEmpty(firstname)) &&
            //                        (i.LastName.Contains(secondname) || string.IsNullOrEmpty(secondname)) &&
            //                        (i.DateOfOrder == date || date == default(DateTime)));
            //}
            id = Convert.ToInt32(id);
            if (id!=0)
            {
                query = query.Where(i => i.Id == id);
            }
            if (!String.IsNullOrEmpty(firstname))
            {
                query = query.Where(i => i.FirstName.Contains(firstname));
            }

            if (!String.IsNullOrEmpty(secondname))
            {
                query = query.Where(i => i.LastName.Contains(secondname));
            }
            if (Day!=0)
            {
                query = query.Where(i => i.DateOfOrder.Day == Day);
            }
            if (Month!=0)
            {
                query = query.Where(i => i.DateOfOrder.Month == Month);
            }
            if (Year != 0)
            {
                query = query.Where(i => i.DateOfOrder.Year == Year);
            }
            if (SortByDate==true)
            {
                query = query.OrderByDescending(i => i.DateOfOrder);
            }
            return query.ToList();

        }
        public OrderRepository(IUnitOfWork unit, DbContext context):base(unit,context)
        {

        }
    }
}
