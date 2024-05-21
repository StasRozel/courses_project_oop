﻿using lab4_5.Classes;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new UserModel();
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
            return context.UsersDbSet.ToList();
        }

        public void Update(UserModel item)
        {
            try
            {
                if (item != null)
                {
                    UserModel? existingUser = context.UsersDbSet.Find(App.session.AuthUser.Email);
                    existingUser.FirstName = item.FirstName;
                    existingUser.LastName = item.LastName;
                    existingUser.Surname = item.Surname;
                    existingUser.PasswordHash= item.PasswordHash;
                    existingUser.Email = item.Email;
                    existingUser.PhoneNumber = item.PhoneNumber;
                    existingUser.IsAdmin = false;

                    // Обновите другие свойства, которые нужно изменить
                    context.UsersDbSet.Update(existingUser);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
