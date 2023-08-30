using CRUD.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.DAL.Database
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(" Data Source = ESSA-AHMED; Integrated Security = True; Initial Catalog = CRUD; Trust Server Certificate = True; ");
        }
        public DbSet<Department> Department { get; set; }
    }
}
