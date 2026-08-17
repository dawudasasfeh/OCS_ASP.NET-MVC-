using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Validation_in_ASP.NET__Client_Side_vs_Server_Side_.Models;

namespace Validation_in_ASP.NET__Client_Side_vs_Server_Side_.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Employee> Employees { get; set; }

    }
}
