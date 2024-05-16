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
        static void GetTicketList() { } 
        static Ticket GetTickets(int id) { return new Ticket(); } 
        static void Create(T ticket) { } 
        static void Update(T ticket) { } 
        static void Delete(int id) { } 
    }
}
