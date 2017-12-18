﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using Interfaces.Repositories;
using Interfaces;

namespace DataAccess.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T: class,IBaseEntity,new()
    {
        internal DbContext context { get; set; }

        protected DbSet<T> Items { get; set; }

        internal IUnitOfWork Unit;

        public BaseRepository(IUnitOfWork unit, DbContext context)
        {
            this.Unit = unit;
            this.context = context;
            this.Items = context.Set<T>();
        }

        public BaseRepository(StoreDbContext context)
        {
            this.context = context;
            this.Items = this.context.Set<T>();
        }

        public virtual T GetById(int Id)
        {
           return Items.Find(Id);
        }

        public virtual T Find(Expression<Func<T,bool>> filter)
        {
            return Items.FirstOrDefault(filter);
        }

        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "", int take = 0)
        {
            IQueryable<T> query = Items;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (take > 0)
            {
                if (orderBy != null)
                {
                    return orderBy(query).Take(take).ToList();
                }
                else
                {
                    return query.Take(take).ToList();
                }
            }
            else if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual List<T> GetAll()
        {
            return Items.ToList();
        }

        public void Save(T item)
        {
            Items.Add(item);
        }
        
        public virtual void Delete(object id)
        {
            T entityToDelete = Items.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                Items.Attach(entityToDelete);
            }
            Items.Remove(entityToDelete);
        }

        public virtual void Update(T entityToUpdate)
        {
            if (context.Entry(entityToUpdate).State == EntityState.Detached)
            {
                Items.Attach(entityToUpdate);
            }
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
