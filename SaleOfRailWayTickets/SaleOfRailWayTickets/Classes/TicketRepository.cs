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
    public class TicketRepository : IRepository<TicketEssence>
    {
        private ApplicationDbContext context;

        public TicketRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool Create(TicketEssence item)
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

        public bool Delete(TicketEssence item)
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

        public TicketEssence Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<TicketEssence> GetList()
        {
            return context.TicketsDbSet.ToList();
        }

        public void Update(TicketEssence item)
        {
            try
            {
                if (item != null)
                {
                    TicketEssence? existingTicket = context.TicketsDbSet.Find(item.Id);
                    existingTicket.NameWay = item.NameWay;
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
