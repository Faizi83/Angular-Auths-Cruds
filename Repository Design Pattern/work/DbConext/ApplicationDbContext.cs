using Microsoft.EntityFrameworkCore;
using work.Models;

namespace work.DbConext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Register> Registers { get; set; }

        
    }
}
