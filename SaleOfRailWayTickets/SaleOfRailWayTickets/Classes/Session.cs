using lab4_5.Model;
using lab4_5.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_5.Classes
{
    public class Session
    {
        public UserModel AuthUser { get; set; }
        public ClientWindow clientWindow { get; set; }
        public PurchasedTicketModel purchasedTicket { get; set; }
        public Session() { }

    }
}
