using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OutOfOffice.Models;

namespace OutOfOffice.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<LeaveRequest> LeaveRequest { get; set; }
        public DbSet<ApprovalRequest> ApprovalRequest { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Entities configuration

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.PeoplePartner)
                .WithMany()
                .HasForeignKey(e => e.PeoplePartnerId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Projects)
                .WithMany(p => p.Members)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeeProject",
                    j => j.HasOne<Project>()
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j.HasOne<Employee>()
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                );

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
                .WithMany()
                .HasForeignKey(ar => ar.LeaveRequestId)
                .OnDelete(DeleteBehavior.Restrict);

            // Data seeding
            // AspNetRoles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                },
                new IdentityRole
                {
                    Id = "ce7db7fd-ba3f-4cc7-8d37-a831b0725379",
                    Name = "HR manager",
                    NormalizedName = "HR manager".ToUpper()
                },
                new IdentityRole
                {
                    Id = "57bde49e-8d41-45c4-baea-29141e2b2b6c",
                    Name = "Project manager",
                    NormalizedName = "Project manager".ToUpper()
                },
                new IdentityRole
                {
                    Id = "92d723f4-81c5-4109-b962-bbec93185fe7",
                    Name = "Employee",
                    NormalizedName = "Employee".ToUpper()
                }
            );

            // a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<IdentityUser>();

            // AspNetUsers
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    UserName = "admin@gmail.com",
                    NormalizedUserName = "admin@gmail.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "Admin1234_")
                },
                new IdentityUser
                {
                    Id = "91565f7d-00f0-4e36-8b54-0d9210668113",
                    UserName = "hrmanager@gmail.com",
                    NormalizedUserName = "hrmanager@gmail.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "HR1234_")
                },
                new IdentityUser
                {
                    Id = "c97575f3-7279-42a7-a52c-8c9c04e5d8b6",
                    UserName = "projectmanager@gmail.com",
                    NormalizedUserName = "projectmanager@gmail.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "Project1234_")
                },
                new IdentityUser
                {
                    Id = "3c155c25-ef31-41c0-9023-dbf59506d2c2",
                    UserName = "employee1@gmail.com",
                    NormalizedUserName = "employee1@gmail.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "Employee12341_")
                },
                new IdentityUser
                {
                    Id = "efa05cf9-5f6f-41ff-a3b7-a4b2d40739ef",
                    UserName = "employee2@gmail.com",
                    NormalizedUserName = "employee2@gmail.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "Employee12342_")
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                // admin
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                },
                // hr manager
                new IdentityUserRole<string>
                {
                    RoleId = "ce7db7fd-ba3f-4cc7-8d37-a831b0725379",
                    UserId = "91565f7d-00f0-4e36-8b54-0d9210668113"
                },
                // project manager
                new IdentityUserRole<string>
                {
                    RoleId = "57bde49e-8d41-45c4-baea-29141e2b2b6c",
                    UserId = "c97575f3-7279-42a7-a52c-8c9c04e5d8b6"
                },
                // employees
                new IdentityUserRole<string>
                {
                    RoleId = "92d723f4-81c5-4109-b962-bbec93185fe7",
                    UserId = "3c155c25-ef31-41c0-9023-dbf59506d2c2"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "92d723f4-81c5-4109-b962-bbec93185fe7",
                    UserId = "efa05cf9-5f6f-41ff-a3b7-a4b2d40739ef"
                }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee()
                {
                    Id = 1,
                    UserId = "91565f7d-00f0-4e36-8b54-0d9210668113",
                    FullName = "Alyssa Kennedy",
                    Subdivision = "Recruiting",
                    Position = "Hr Manager",
                    Status = "Active",
                    OutOfOfficeBalance = 15,
                    PhotoUrl = @"\photos\780bde51-e8e8-43ca-8db4-cda2e4ff4248.png"
                },
                new Employee()
                {
                    Id = 2,
                    UserId = "c97575f3-7279-42a7-a52c-8c9c04e5d8b6",
                    FullName = "Oliver Dodger",
                    Subdivision = "IT",
                    Position = "Project Manager",
                    Status = "Active",
                    OutOfOfficeBalance = 10,
                    PhotoUrl = @"\photos\16c0f1a5-2d26-4be6-a690-2383571bf409.png"
                },
                new Employee()
                {
                    Id = 3,
                    UserId = "3c155c25-ef31-41c0-9023-dbf59506d2c2",
                    FullName = "Grace Carney",
                    Subdivision = "IT",
                    Position = "Programmer",
                    Status = "Active",
                    OutOfOfficeBalance = 3
                },
                new Employee()
                {
                    Id = 4,
                    UserId = "efa05cf9-5f6f-41ff-a3b7-a4b2d40739ef",
                    FullName = "Justin Valencia",
                    Subdivision = "Sales",
                    Position = "Accountant",
                    Status = "Active",
                    OutOfOfficeBalance = 5
                }
            );
        }
    }
}
