﻿using lab4_5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lab4_5.Classes
{
    public class PurchasedTicketRepository : IRepository<PurchasedTicketModel>
    {
        private ApplicationDbContext context;

        public PurchasedTicketRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool Create(PurchasedTicketModel item)
        {
            try
            {
                context.PurchasedTicketsDbSet.Add(item);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        public bool Delete(PurchasedTicketModel item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public PurchasedTicketModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<PurchasedTicketModel> GetList()
        {
            return context.PurchasedTicketsDbSet.ToList();
        }

        public void Update(PurchasedTicketModel item)
        {
            throw new NotImplementedException();
        }
    }
}