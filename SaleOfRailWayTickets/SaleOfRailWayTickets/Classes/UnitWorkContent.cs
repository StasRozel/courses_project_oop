using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_5.Classes
{
    public class UnitWorkContent
    {
        private ApplicationDbContext context;
        private TicketRepository ticketRepository;
        private UserRepository userRepository;
        private PurchasedTicketRepository purchasedTicketRepository;

        public UnitWorkContent(ApplicationDbContext context) 
        {
            this.context = context;
        }

        public TicketRepository TicketRepository
        { 
            get { return ticketRepository ?? new TicketRepository(context); } 
        }

        public UserRepository UserRepository
        {
            get { return userRepository ?? new UserRepository(context); }
        }

        public PurchasedTicketRepository PurchasedTicketRepository
        {
            get { return purchasedTicketRepository ?? new PurchasedTicketRepository(context); }
        }
    }
}
