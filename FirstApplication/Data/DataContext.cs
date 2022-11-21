using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace FirstApplication.Data
{
    public class DataContext:IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        public DbSet<FirstApplication.Models.Department> Department { get; set; }
        public DbSet<FirstApplication.Models.Employee> Employee { get; set; }
    }
}
