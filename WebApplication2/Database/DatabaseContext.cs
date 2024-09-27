using Microsoft.EntityFrameworkCore;
using WebApplication2.Model;

namespace WebApplication2.Database
{
    public class DatabaseContext  : DbContext
    {
        public DatabaseContext(DbContextOptions options) :base(options) 
        { 
        }


        //Dbset 

        public DbSet<Employee> Employees { get; set; }

        
    }
}
