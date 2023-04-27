using Microsoft.EntityFrameworkCore;
using learn.Models; 

namespace learn.Models
{
    public class HRDatabaseContext : DbContext  
    {
        public DbSet <Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=localhost\sqlexpress; initial catalog=EmployeesDB2; integrated security=SSPI;TrustServerCertificate=true");
        }

    }
}
