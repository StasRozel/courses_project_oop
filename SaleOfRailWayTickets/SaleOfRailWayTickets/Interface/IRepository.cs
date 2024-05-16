using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_5
{
    interface IRepository<T> : IDisposable
        where T : class
    {
        abstract List<T> GetList();
        abstract Ticket Get(int id);
        abstract bool Create(T item);
        abstract void Update(T item);
        abstract bool Delete(int id); 
    }
}
