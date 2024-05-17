using lab4_5.Classes;
using Microsoft.Data.SqlClient;
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
    public class UserRepository : IRepository<UserModel>
    {
        private ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool Registration(UserModel item)
        {
            try
            {
                context.UsersDbSet.Add(item);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public UserModel? Authorization(string passwordHash, string email)
        {
            UserModel? user = new UserModel();
            try
            {
                user = context.UsersDbSet.Find(email);
                if (user?.PasswordHash != passwordHash) {
                    throw new Exception("Неверный логин или пароль");
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return user;
        }

        public bool Create(UserModel item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(UserModel item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public UserModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserModel> GetList()
        {
            throw new NotImplementedException();
        }

        public void Update(UserModel item)
        {
            throw new NotImplementedException();
        }

    }
}
