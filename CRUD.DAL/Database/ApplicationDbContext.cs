 using CRUD.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace CRUD.DAL.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }
      
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }

    }


}
