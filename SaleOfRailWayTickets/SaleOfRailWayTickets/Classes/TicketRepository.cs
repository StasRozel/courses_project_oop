using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client.NativeInterop;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lab4_5.Classes
{
    public class TicketRepository : IRepository<TicketModel>
    {
        private ApplicationDbContext context;

        public TicketRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool Create(TicketModel item)
        {
           try
            {
                context.TicketsDbSet.Add(item);
                context.SaveChanges();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        } 

        public bool Delete(TicketModel item)
        {
            try
            {
                context.TicketsDbSet.Remove(item);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        public void Dispose() {}

        public TicketModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<TicketModel> GetList()
        {
            return context.TicketsDbSet.ToList();
        }

        public void Update(TicketModel item)
        {
            try
            {
                if (item != null)
                {
                    TicketModel? existingTicket = context.TicketsDbSet.Find(item.Id);
                    existingTicket.From = item.From;
                    existingTicket.To = item.To;
                    existingTicket.Description = item.Description;
                    existingTicket.Time = item.Time;
                    existingTicket.Price = item.Price;
                    existingTicket.NumberTrain = item.NumberTrain;
                    existingTicket.Type = item.Type;
                    
                    // Обновите другие свойства, которые нужно изменить
                    context.TicketsDbSet.Update(existingTicket);
                    context.SaveChanges();
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
