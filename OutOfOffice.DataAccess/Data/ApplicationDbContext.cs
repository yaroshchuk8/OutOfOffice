using Microsoft.EntityFrameworkCore;
using OutOfOffice.Models;

namespace OutOfOffice.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<LeaveRequest> LeaveRequest { get; set; }
        public DbSet<ApprovalRequest> ApprovalRequest { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.PeoplePartner)
                .WithMany()
                .HasForeignKey(e => e.PeoplePartnerId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Projects)
                .WithMany(p => p.Members);


            /*modelBuilder.Entity<Employee>().HasData(
                new Employee()
                {
                    Id = 1,
                    FullName = "Nicholas Grey",
                    Subdivision = "IT",
                    Position = "Admin",
                    Status = "Active",
                    OutOfOfficeBalance = 30,
                    PhotoUrl = @"\img\employee\admin.png"
                }
                );*/
        }
    }
}
