using AO7K2W_HFT_2021221.Data;
using AO7K2W_HFT_2021221.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO7K2W_HFT_2021221.Repository.GenericRepository
{
    public abstract class Repository <T> : IRepository<T> where T :class
    {
        protected TankDbContext ctx;
        public Repository(TankDbContext ctx)
        {
            this.ctx = ctx;
        }
        public void Create(T item)
        {
            ctx.Set<T>().Add(item);
            ctx.SaveChanges();
        }
        public IQueryable<T> ReadAll()
        {
            return ctx.Set<T>();
        }
        public void Delete(int id)
        {
            ctx.Set<T>().Remove(Read(id));
        }
        public abstract T Read(int id);
        public abstract void Update(T item);
    }
}
