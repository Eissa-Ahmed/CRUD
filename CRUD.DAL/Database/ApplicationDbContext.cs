using CRUD.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace CRUD.DAL.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder.UseSqlServer(" Data Source = ESSA-AHMED; Integrated Security = True; Initial Catalog = CRUD; Trust Server Certificate = True; ");
         }*/
        public DbSet<Department> Department { get; set; }
    }
}
