using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_5.Classes
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TicketEssence> TicketsDbSet { get; set; }
        public DbSet<UserModel> UsersDbSet { get; set; }


        public ApplicationDbContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=Stas;Initial Catalog=TicketSystem;Integrated Security=True;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TicketEssence>().ToTable("Tickets");

            modelBuilder.Entity<UserModel>().ToTable("Users");


        }

    }


}
