using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_Task1.Models;

namespace MVC_Task1.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUserModel>(options)
    {
        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<MangerModel> Mangers { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<FeedbackModel> Feedbacks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmployeeModel>()
                .HasOne(e => e.User)
                .WithOne()
                .HasForeignKey<EmployeeModel>(e => e.UserId);

            modelBuilder.Entity<MangerModel>()
                .HasOne(e=>e.User) 
                .WithOne()
                .HasForeignKey<MangerModel>(e=> e.UserId);

            modelBuilder.Entity<EmployeeModel>()
                .HasOne(e=>e.Department)
                .WithMany(u => u.Employees)
                .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<TaskModel>()
                .HasOne(e => e.Employee)
                .WithMany(e=>e.Tasks)
                .HasForeignKey(e => e.EmployeeId);


        }



    }
}
