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
                .WithMany(p => p.Members)
                .UsingEntity(ent => ent.ToTable("EmployeeProject"));

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Manager)
                .WithMany()
                .HasForeignKey(p => p.ManagerId);

            modelBuilder.Entity<LeaveRequest>()
                .HasOne(lr => lr.Employee)
                .WithMany(e => e.LeaveRequests)
                .HasForeignKey(lr => lr.EmployeeId);

            modelBuilder.Entity<ApprovalRequest>()
                .HasOne(ar => ar.Approver)
                .WithMany()
                .HasForeignKey(ar => ar.ApproverId);

            modelBuilder.Entity<ApprovalRequest>()
                .HasOne(ar => ar.LeaveRequest)
                .WithOne()
                .HasForeignKey<ApprovalRequest>(ar => ar.LeaveRequestId);

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
