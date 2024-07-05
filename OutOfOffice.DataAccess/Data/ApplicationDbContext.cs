using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OutOfOffice.Models;

namespace OutOfOffice.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<Employee>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<LeaveRequest> LeaveRequest { get; set; }
        public DbSet<LeaveRequestApproval> LeaveRequestApproval { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Entities configuration
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.PeoplePartner)
                .WithMany()
                .HasForeignKey(e => e.PeoplePartnerId)
                .OnDelete(DeleteBehavior.Restrict);

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

            modelBuilder.Entity<LeaveRequestApproval>()
                .HasOne(ar => ar.Approver)
                .WithMany()
                .HasForeignKey(ar => ar.ApproverId);

            modelBuilder.Entity<LeaveRequestApproval>()
                .HasOne(ar => ar.LeaveRequest)
                .WithMany()
                .HasForeignKey(ar => ar.LeaveRequestId)
                .OnDelete(DeleteBehavior.Restrict);

            // Renaming ASP.NET Core Identity tables
            modelBuilder.Entity<IdentityRole>(entity => { entity.ToTable(name: "Role"); });
            modelBuilder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable("EmployeeRole"); });
            modelBuilder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("Claim"); });
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("Login"); });
            modelBuilder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("Token"); });
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("RoleClaim"); });


            // Seeding Role table
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
            var hasher = new PasswordHasher<Employee>();

            // Seeding Employee table
            modelBuilder.Entity<Employee>(
                    entity =>
                    {
                        entity.ToTable(name: "Employee");
                        entity.HasData(
                            // admin
                            new Employee
                            {
                                Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                                FullName = "Denis McBoss",
                                Subdivision = "Administration",
                                Position = "Administrator",
                                Status = "Active",
                                OutOfOfficeBalance = 30,
                                PeoplePartnerId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                                UserName = "admin@gmail.com",
                                NormalizedUserName = "admin@gmail.com".ToUpper(),
                                PasswordHash = hasher.HashPassword(null, "Admin1234_")
                            },
                            // hr managers
                            new Employee
                            {
                                Id = "91565f7d-00f0-4e36-8b54-0d9210668113",
                                FullName = "Alyssa Kennedy",
                                Subdivision = "Human Resources",
                                Position = "HR manager",
                                Status = "Active",
                                OutOfOfficeBalance = 30,
                                PhotoUrl = @"\photos\780bde51-e8e8-43ca-8db4-cda2e4ff4248.png",
                                PeoplePartnerId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                                UserName = "hrmanager@gmail.com",
                                NormalizedUserName = "hrmanager@gmail.com".ToUpper(),
                                PasswordHash = hasher.HashPassword(null, "HR1234_")
                            },
                            new Employee
                            {
                                Id = "8825ba1e-f826-42fa-bc2c-bca4a91e64af",
                                FullName = "Ciara Montes",
                                Subdivision = "Human Resources",
                                Position = "HR manager",
                                Status = "Active",
                                OutOfOfficeBalance = 30,
                                PeoplePartnerId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                                UserName = "hrmanager2@gmail.com",
                                NormalizedUserName = "hrmanager2@gmail.com".ToUpper(),
                                PasswordHash = hasher.HashPassword(null, "HR12342_")
                            },
                            // project managers
                            new Employee
                            {
                                Id = "c97575f3-7279-42a7-a52c-8c9c04e5d8b6",
                                FullName = "Oliver Dodger",
                                Subdivision = "IT",
                                Position = "Project manager",
                                Status = "Active",
                                OutOfOfficeBalance = 30,
                                PhotoUrl = @"\photos\16c0f1a5-2d26-4be6-a690-2383571bf409.png",
                                PeoplePartnerId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                                UserName = "projectmanager@gmail.com",
                                NormalizedUserName = "projectmanager@gmail.com".ToUpper(),
                                PasswordHash = hasher.HashPassword(null, "Project1234_")
                            },
                            new Employee
                            {
                                Id = "39040db5-17ed-4437-9454-86218e9f2a21",
                                FullName = "Khalil O'Reilly",
                                Subdivision = "Marketing",
                                Position = "Project manager",
                                Status = "Active",
                                OutOfOfficeBalance = 30,
                                PeoplePartnerId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                                UserName = "projectmanager2@gmail.com",
                                NormalizedUserName = "projectmanager2@gmail.com".ToUpper(),
                                PasswordHash = hasher.HashPassword(null, "Project12342_")
                            },
                            // employees
                            new Employee
                            {
                                Id = "3c155c25-ef31-41c0-9023-dbf59506d2c2",
                                FullName = "Grace Carney",
                                Subdivision = "IT",
                                Position = "Back-end developer",
                                Status = "Active",
                                OutOfOfficeBalance = 30,
                                PeoplePartnerId = "91565f7d-00f0-4e36-8b54-0d9210668113",
                                UserName = "employee1@gmail.com",
                                NormalizedUserName = "employee1@gmail.com".ToUpper(),
                                PasswordHash = hasher.HashPassword(null, "Employee12341_")
                            },
                            new Employee
                            {
                                Id = "efa05cf9-5f6f-41ff-a3b7-a4b2d40739ef",
                                FullName = "Justin Valencia",
                                Subdivision = "Sales",
                                Position = "Accountant",
                                Status = "Active",
                                OutOfOfficeBalance = 30,
                                PeoplePartnerId = "8825ba1e-f826-42fa-bc2c-bca4a91e64af",
                                UserName = "employee2@gmail.com",
                                NormalizedUserName = "employee2@gmail.com".ToUpper(),
                                PasswordHash = hasher.HashPassword(null, "Employee12342_")
                            },
                            new Employee
                            {
                                Id = "df501ef6-7187-4126-82fc-d3dce8f7c73e",
                                FullName = "Mia Irwin",
                                Subdivision = "Finance",
                                Position = "Sales manager",
                                Status = "Active",
                                OutOfOfficeBalance = 30,
                                PeoplePartnerId = "91565f7d-00f0-4e36-8b54-0d9210668113",
                                UserName = "employee3@gmail.com",
                                NormalizedUserName = "employee3@gmail.com".ToUpper(),
                                PasswordHash = hasher.HashPassword(null, "Employee12343_")
                            },
                            new Employee
                            {
                                Id = "357af2a2-5650-48b8-81af-6d1355b94d98",
                                FullName = "Ibraheem Harrison",
                                Subdivision = "Marketing",
                                Position = "Receptionist",
                                Status = "Active",
                                OutOfOfficeBalance = 30,
                                PeoplePartnerId = "8825ba1e-f826-42fa-bc2c-bca4a91e64af",
                                UserName = "employee4@gmail.com",
                                NormalizedUserName = "employee4@gmail.com".ToUpper(),
                                PasswordHash = hasher.HashPassword(null, "Employee12344_")
                            }
                        );
                    }
                );

            // Seeding EmployeeRole table
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
                new IdentityUserRole<string>
                {
                    RoleId = "ce7db7fd-ba3f-4cc7-8d37-a831b0725379",
                    UserId = "8825ba1e-f826-42fa-bc2c-bca4a91e64af"
                },
                // project manager
                new IdentityUserRole<string>
                {
                    RoleId = "57bde49e-8d41-45c4-baea-29141e2b2b6c",
                    UserId = "c97575f3-7279-42a7-a52c-8c9c04e5d8b6"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "57bde49e-8d41-45c4-baea-29141e2b2b6c",
                    UserId = "39040db5-17ed-4437-9454-86218e9f2a21"
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
                },
                new IdentityUserRole<string>
                {
                    RoleId = "92d723f4-81c5-4109-b962-bbec93185fe7",
                    UserId = "df501ef6-7187-4126-82fc-d3dce8f7c73e"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "92d723f4-81c5-4109-b962-bbec93185fe7",
                    UserId = "357af2a2-5650-48b8-81af-6d1355b94d98"
                }
            );
        }
    }
}
