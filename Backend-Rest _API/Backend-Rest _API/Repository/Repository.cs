
using Backend_Rest__API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace Backend_Rest__API.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ECommerceAPIEntities context = new ECommerceAPIEntities();
        public void Delete(int id)
        {
            this.context.Set<T>().Remove(Get(id));
            this.context.SaveChanges();
        }


        public T Get(int id)
        {
            return this.context.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            return this.context.Set<T>().ToList();
        }
        //---get by id
        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }


        public void Insert(T entity)
        {
            this.context.Set<T>().Add(entity);
            this.context.SaveChanges();
        }

        public void Update(T entity)
        {
            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
        }
    }
}