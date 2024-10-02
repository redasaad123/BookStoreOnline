
using Cores.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Rrpository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbAppContext context;
        private readonly DbSet<T> Dpset;

        public GenericRepository( DbAppContext context)
        {
            this.context = context;
            Dpset = context.Set<T>();
        }

        public void Delete(object id)
        {
            T entity = Get(id);

            Dpset.Remove(entity);
           
        }

        public T Get(object id)
        {
            return Dpset.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Dpset.ToList();
            
        }

        public object GetElement(object id)
        {
            return Dpset.Find(id);
        }

        public void Insert(T entity)
        {
            Dpset.Add(entity);
        }

        public void Update(T entity)
        {
            Dpset.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
