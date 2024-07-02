﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OutOfOffice.DataAccess.Data;

#nullable disable

namespace OutOfOffice.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240702221802_MaintainConnectionsBetweenTablesAndSeedData")]
    partial class MaintainConnectionsBetweenTablesAndSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeProject", b =>
                {
                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("EmployeeProject");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "ce7db7fd-ba3f-4cc7-8d37-a831b0725379",
                            Name = "HR manager",
                            NormalizedName = "HR MANAGER"
                        },
                        new
                        {
                            Id = "57bde49e-8d41-45c4-baea-29141e2b2b6c",
                            Name = "Project manager",
                            NormalizedName = "PROJECT MANAGER"
                        },
                        new
                        {
                            Id = "92d723f4-81c5-4109-b962-bbec93185fe7",
                            Name = "Employee",
                            NormalizedName = "EMPLOYEE"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Claim", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("Login", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("EmployeeRole", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210"
                        },
                        new
                        {
                            UserId = "91565f7d-00f0-4e36-8b54-0d9210668113",
                            RoleId = "ce7db7fd-ba3f-4cc7-8d37-a831b0725379"
                        },
                        new
                        {
                            UserId = "c97575f3-7279-42a7-a52c-8c9c04e5d8b6",
                            RoleId = "57bde49e-8d41-45c4-baea-29141e2b2b6c"
                        },
                        new
                        {
                            UserId = "3c155c25-ef31-41c0-9023-dbf59506d2c2",
                            RoleId = "92d723f4-81c5-4109-b962-bbec93185fe7"
                        },
                        new
                        {
                            UserId = "efa05cf9-5f6f-41ff-a3b7-a4b2d40739ef",
                            RoleId = "92d723f4-81c5-4109-b962-bbec93185fe7"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("Token", (string)null);
                });

            modelBuilder.Entity("OutOfOffice.Models.LeaveRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AbsenceReason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("LeaveRequest");
                });

            modelBuilder.Entity("OutOfOffice.Models.LeaveRequestApproval", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApproverId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LeaveRequestId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApproverId");

                    b.HasIndex("LeaveRequestId");

                    b.ToTable("LeaveRequestApproval");
                });

            modelBuilder.Entity("OutOfOffice.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ManagerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("OutOfOffice.Models.Employee", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OutOfOfficeBalance")
                        .HasColumnType("int");

                    b.Property<string>("PeoplePartnerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subdivision")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("PeoplePartnerId");

                    b.ToTable("Employee", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f3433776-130b-47bd-82d9-07273e345715",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEBXaRglaUxJtmXRwCNr9GX6yIW6djekRIP17tvOmi7j5cmBv3Ayd/reoaEK8kU1vvw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b69d51b8-885d-4282-8565-bdea598fec3f",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com",
                            FullName = "Denis McBoss",
                            OutOfOfficeBalance = 15,
                            Position = "Administrator",
                            Status = "Active",
                            Subdivision = "IT"
                        },
                        new
                        {
                            Id = "91565f7d-00f0-4e36-8b54-0d9210668113",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "170279bb-b36d-4334-af19-b11d6261b854",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "HRMANAGER@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEOU6ENjGUwBxAaRAhLEEVDlaN0Z0AJCQo9mA7t1+5IUo68BO15IuL8WS0XlSFf3E1g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b95c4165-e7fc-4a0e-9719-3990ed9842ba",
                            TwoFactorEnabled = false,
                            UserName = "hrmanager@gmail.com",
                            FullName = "Alyssa Kennedy",
                            OutOfOfficeBalance = 15,
                            PhotoUrl = "\\photos\\780bde51-e8e8-43ca-8db4-cda2e4ff4248.png",
                            Position = "Hr Manager",
                            Status = "Active",
                            Subdivision = "Recruiting"
                        },
                        new
                        {
                            Id = "c97575f3-7279-42a7-a52c-8c9c04e5d8b6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d13fccb4-3a67-4a0d-8555-1b459f50f9af",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "PROJECTMANAGER@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEGaJSL6CLBBHeYPxLzLvgSyh2YygHa9ZLE8Vx3eLkGoGcSHKGVwtAXC0N8rlY6Mbwg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "da75e478-5921-42d3-8438-851799abf797",
                            TwoFactorEnabled = false,
                            UserName = "projectmanager@gmail.com",
                            FullName = "Oliver Dodger",
                            OutOfOfficeBalance = 10,
                            PhotoUrl = "\\photos\\16c0f1a5-2d26-4be6-a690-2383571bf409.png",
                            Position = "Project Manager",
                            Status = "Active",
                            Subdivision = "IT"
                        },
                        new
                        {
                            Id = "3c155c25-ef31-41c0-9023-dbf59506d2c2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "92ba3018-c0a7-49b6-83dd-43dd97c20aa8",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "EMPLOYEE1@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAELkamKzJEdJ5Ryqjxo4zMAheYIRGc8dC0FK97Zcet3sGGfDP5c71BrEcZzIqe/imBg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "27ad1851-eed5-45c5-9575-5bdab0602097",
                            TwoFactorEnabled = false,
                            UserName = "employee1@gmail.com",
                            FullName = "Grace Carney",
                            OutOfOfficeBalance = 3,
                            Position = "Programmer",
                            Status = "Active",
                            Subdivision = "IT"
                        },
                        new
                        {
                            Id = "efa05cf9-5f6f-41ff-a3b7-a4b2d40739ef",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "bd7a3163-0b41-4ce1-a57e-16eba0551901",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "EMPLOYEE2@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEHz5fek2qCu86OYnvOTkCtVk+m7DDingFC+kCGXxcCgJVMWMzGPpp9i9K3RvD0Y/AQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "21a0ea7a-d246-4077-8293-46279d9cb904",
                            TwoFactorEnabled = false,
                            UserName = "employee2@gmail.com",
                            FullName = "Justin Valencia",
                            OutOfOfficeBalance = 5,
                            Position = "Accountant",
                            Status = "Active",
                            Subdivision = "Sales"
                        });
                });

            modelBuilder.Entity("EmployeeProject", b =>
                {
                    b.HasOne("OutOfOffice.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("OutOfOffice.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OutOfOffice.Models.LeaveRequest", b =>
                {
                    b.HasOne("OutOfOffice.Models.Employee", "Employee")
                        .WithMany("LeaveRequests")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("OutOfOffice.Models.LeaveRequestApproval", b =>
                {
                    b.HasOne("OutOfOffice.Models.Employee", "Approver")
                        .WithMany()
                        .HasForeignKey("ApproverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OutOfOffice.Models.LeaveRequest", "LeaveRequest")
                        .WithMany()
                        .HasForeignKey("LeaveRequestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Approver");

                    b.Navigation("LeaveRequest");
                });

            modelBuilder.Entity("OutOfOffice.Models.Project", b =>
                {
                    b.HasOne("OutOfOffice.Models.Employee", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("OutOfOffice.Models.Employee", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithOne()
                        .HasForeignKey("OutOfOffice.Models.Employee", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OutOfOffice.Models.Employee", "PeoplePartner")
                        .WithMany()
                        .HasForeignKey("PeoplePartnerId");

                    b.Navigation("PeoplePartner");
                });

            modelBuilder.Entity("OutOfOffice.Models.Employee", b =>
                {
                    b.Navigation("LeaveRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
