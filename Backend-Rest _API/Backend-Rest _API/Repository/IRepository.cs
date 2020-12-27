using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Rest__API.Repository
{
    interface IRepository<T> where T:class
    {
        List<T> GetAll();
        T Get(int id);
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
