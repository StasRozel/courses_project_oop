﻿using Microsoft.Data.SqlClient;
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
    public class Repository : IRepository<Ticket>
    {
        private ApplicationDbContext context;

        public bool Create(Ticket item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Ticket Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> GetList()
        {
            throw new NotImplementedException();
        }

        public void Update(Ticket item)
        {
            throw new NotImplementedException();
        }
    }
}
