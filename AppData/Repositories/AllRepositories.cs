﻿using AppData.IRepositories;
using AppData.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Repositories
{
    public class AllRepositories<T> : IAllRepositories<T> where T : class
    {
        HuyDNPH22526_LAB5_6Context context;
        DbSet<T> dbset;
        public AllRepositories()
        {

        }
        public AllRepositories(HuyDNPH22526_LAB5_6Context context, DbSet<T> dbset)
        {
            this.context = context;
            this.dbset = dbset;
        }
        public bool CreateItem(T item)
        {
            try
            {
                dbset.Add(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteItem(T item)
        {
            try
            {
                dbset.Remove(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public bool UpdateItem(T item)
        {
            try
            {
                dbset.Update(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
