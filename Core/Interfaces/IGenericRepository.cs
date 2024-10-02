using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cores.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T Get(object id);

        object GetElement(object id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(object id);
    }
}
