using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Model
{
    public class HuyDNPH22526_LAB5_6Context : DbContext
    {
        public HuyDNPH22526_LAB5_6Context()
        {
            
        }
        public HuyDNPH22526_LAB5_6Context(DbContextOptions options) : base(options)
        { }
        public DbSet<NhanVien> NhanViens { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-RKUPNGD\SQLEXPRESS;Initial Catalog=Lab5_6_NET105;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.
                GetExecutingAssembly());
        }
    }
}
