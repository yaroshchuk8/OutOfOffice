using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OutOfOffice.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityAndCreateEntitiesWithConnectionsAndSeedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subdivision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeoplePartnerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OutOfOfficeBalance = table.Column<int>(type: "int", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Employee_PeoplePartnerId",
                        column: x => x.PeoplePartnerId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Claim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Claim_Employee_UserId",
                        column: x => x.UserId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AbsenceReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequest_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_Login_Employee_UserId",
                        column: x => x.UserId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ManagerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Employee_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_Token_Employee_UserId",
                        column: x => x.UserId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRole",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_EmployeeRole_Employee_UserId",
                        column: x => x.UserId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequestApproval",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApproverId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LeaveRequestId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequestApproval", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequestApproval_Employee_ApproverId",
                        column: x => x.ApproverId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaveRequestApproval_LeaveRequest_LeaveRequestId",
                        column: x => x.LeaveRequestId,
                        principalTable: "LeaveRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProject",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProject", x => new { x.EmployeeId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OutOfOfficeBalance", "PasswordHash", "PeoplePartnerId", "PhoneNumber", "PhoneNumberConfirmed", "PhotoUrl", "Position", "SecurityStamp", "Status", "Subdivision", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "5766e4aa-4934-422a-8cb7-b860d560873b", null, false, "Denis McBoss", false, null, null, "ADMIN@GMAIL.COM", 30, "AQAAAAIAAYagAAAAENs64pUVmZly/iLiuTd2zs1dwTNLz6shbC6JtvIKXqGXIkT8nlH3aIGf0cSCU7pFJQ==", "8e445865-a24d-4543-a6c6-9443d048cdb9", null, false, null, "Administrator", "86465aef-4ad8-460a-89cb-fb4e75137130", "Active", "Administration", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", null, "Admin", "ADMIN" },
                    { "57bde49e-8d41-45c4-baea-29141e2b2b6c", null, "Project manager", "PROJECT MANAGER" },
                    { "92d723f4-81c5-4109-b962-bbec93185fe7", null, "Employee", "EMPLOYEE" },
                    { "ce7db7fd-ba3f-4cc7-8d37-a831b0725379", null, "HR manager", "HR MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OutOfOfficeBalance", "PasswordHash", "PeoplePartnerId", "PhoneNumber", "PhoneNumberConfirmed", "PhotoUrl", "Position", "SecurityStamp", "Status", "Subdivision", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "39040db5-17ed-4437-9454-86218e9f2a21", 0, "783606fd-0629-4870-b6db-2a66eded11a2", null, false, "Khalil O'Reilly", false, null, null, "PROJECTMANAGER2@GMAIL.COM", 30, "AQAAAAIAAYagAAAAEHSR9SGNIcSRWqGyNJNFLrWP1LPnSCdO11MeCgCwEA6SzyaEewZ/FbpYKhatyuWxUg==", "8e445865-a24d-4543-a6c6-9443d048cdb9", null, false, null, "Project manager", "e4395ece-87bb-437b-b597-e9ccccf5abba", "Active", "Marketing", false, "projectmanager2@gmail.com" },
                    { "8825ba1e-f826-42fa-bc2c-bca4a91e64af", 0, "48b4a261-8bc2-4a87-9a26-e88ef013ee64", null, false, "Ciara Montes", false, null, null, "HRMANAGER2@GMAIL.COM", 30, "AQAAAAIAAYagAAAAEFJeRl/kRlQp2U5WipVk6Ht2n5rNszYRb6FbKNMtbPamxFdr9mOkY1Md7Lz5muI+Bw==", "8e445865-a24d-4543-a6c6-9443d048cdb9", null, false, null, "HR manager", "dbeb77bc-cf02-4244-97f0-fc207fb96342", "Active", "Human Resources", false, "hrmanager2@gmail.com" },
                    { "91565f7d-00f0-4e36-8b54-0d9210668113", 0, "77e4c3a7-0a0e-4476-8a24-e43bb6d4c8dc", null, false, "Alyssa Kennedy", false, null, null, "HRMANAGER@GMAIL.COM", 30, "AQAAAAIAAYagAAAAEMEJgl1sKj677opF/zBQI9QZaGB3JjGkPSf7IMBMujJvSglhW/FTjqssd7mX+m/b/w==", "8e445865-a24d-4543-a6c6-9443d048cdb9", null, false, "\\photos\\780bde51-e8e8-43ca-8db4-cda2e4ff4248.png", "HR manager", "61274506-dcdd-431d-ab77-068efcaa5968", "Active", "Human Resources", false, "hrmanager@gmail.com" },
                    { "c97575f3-7279-42a7-a52c-8c9c04e5d8b6", 0, "f0862528-3a22-4e8b-9d61-d5721360dd94", null, false, "Oliver Dodger", false, null, null, "PROJECTMANAGER@GMAIL.COM", 30, "AQAAAAIAAYagAAAAEJn8WKxmo8hfkYLjjdvD4Z1x7Obods3cXwcbTc7NgSacvH8j6dANbDzDmSuNfinz+w==", "8e445865-a24d-4543-a6c6-9443d048cdb9", null, false, "\\photos\\16c0f1a5-2d26-4be6-a690-2383571bf409.png", "Project manager", "aaeb52bb-766d-4883-b8d8-475896bb163e", "Active", "IT", false, "projectmanager@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OutOfOfficeBalance", "PasswordHash", "PeoplePartnerId", "PhoneNumber", "PhoneNumberConfirmed", "PhotoUrl", "Position", "SecurityStamp", "Status", "Subdivision", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "357af2a2-5650-48b8-81af-6d1355b94d98", 0, "8f218d52-d40c-4a68-92d0-8eeda8519b52", null, false, "Ibraheem Harrison", false, null, null, "EMPLOYEE4@GMAIL.COM", 30, "AQAAAAIAAYagAAAAEHBQaM8nApc8ZBsMA/USB7d9OsGU11AWfaKJYqRypuq1rgObpDg6e3Sef5KmqYyyBA==", "8825ba1e-f826-42fa-bc2c-bca4a91e64af", null, false, null, "Receptionist", "78a8caf2-7934-4ee5-b6de-7ce22c8e52d7", "Active", "Marketing", false, "employee4@gmail.com" },
                    { "3c155c25-ef31-41c0-9023-dbf59506d2c2", 0, "c40c00a6-6941-42c7-8ccb-08dd9160d9c6", null, false, "Grace Carney", false, null, null, "EMPLOYEE1@GMAIL.COM", 30, "AQAAAAIAAYagAAAAECf5q65l+527WS/+Y6wI9LAwD0EW+e9Y2ez5R9qDWyzuTeqcdrNcr2TMFAokDOcmKA==", "91565f7d-00f0-4e36-8b54-0d9210668113", null, false, null, "Back-end developer", "639beb1c-87d9-4ac4-91b4-aaaeb959488b", "Active", "IT", false, "employee1@gmail.com" },
                    { "df501ef6-7187-4126-82fc-d3dce8f7c73e", 0, "6e74496e-5b17-48ed-bf7e-1b5c22870a50", null, false, "Mia Irwin", false, null, null, "EMPLOYEE3@GMAIL.COM", 30, "AQAAAAIAAYagAAAAEBCQJkyZ5FFuJX8HNctn7QUK/ErMfoRXJ1AsOl/auIxF0mNOiIsgn0cAWrBZdpQkZw==", "91565f7d-00f0-4e36-8b54-0d9210668113", null, false, null, "Sales manager", "cf078be3-a5d2-48e2-a565-5638e59e7d38", "Active", "Finance", false, "employee3@gmail.com" },
                    { "efa05cf9-5f6f-41ff-a3b7-a4b2d40739ef", 0, "b399f647-b2b7-4f4d-9f37-3ed4bf7731f1", null, false, "Justin Valencia", false, null, null, "EMPLOYEE2@GMAIL.COM", 30, "AQAAAAIAAYagAAAAENW2uqvaS250ynLl1PwZD1kcl1niT1c7+mz0hFO/oEbfVSk4JzDrFvxxwkKjiNucyQ==", "8825ba1e-f826-42fa-bc2c-bca4a91e64af", null, false, null, "Accountant", "3ea5b7e5-006d-4a7d-9034-910fb158f7e9", "Active", "Sales", false, "employee2@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "57bde49e-8d41-45c4-baea-29141e2b2b6c", "39040db5-17ed-4437-9454-86218e9f2a21" },
                    { "ce7db7fd-ba3f-4cc7-8d37-a831b0725379", "8825ba1e-f826-42fa-bc2c-bca4a91e64af" },
                    { "ce7db7fd-ba3f-4cc7-8d37-a831b0725379", "91565f7d-00f0-4e36-8b54-0d9210668113" },
                    { "57bde49e-8d41-45c4-baea-29141e2b2b6c", "c97575f3-7279-42a7-a52c-8c9c04e5d8b6" },
                    { "92d723f4-81c5-4109-b962-bbec93185fe7", "357af2a2-5650-48b8-81af-6d1355b94d98" },
                    { "92d723f4-81c5-4109-b962-bbec93185fe7", "3c155c25-ef31-41c0-9023-dbf59506d2c2" },
                    { "92d723f4-81c5-4109-b962-bbec93185fe7", "df501ef6-7187-4126-82fc-d3dce8f7c73e" },
                    { "92d723f4-81c5-4109-b962-bbec93185fe7", "efa05cf9-5f6f-41ff-a3b7-a4b2d40739ef" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Claim_UserId",
                table: "Claim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Employee",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PeoplePartnerId",
                table: "Employee",
                column: "PeoplePartnerId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Employee",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_ProjectId",
                table: "EmployeeProject",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRole_RoleId",
                table: "EmployeeRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequest_EmployeeId",
                table: "LeaveRequest",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequestApproval_ApproverId",
                table: "LeaveRequestApproval",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequestApproval_LeaveRequestId",
                table: "LeaveRequestApproval",
                column: "LeaveRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Login_UserId",
                table: "Login",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ManagerId",
                table: "Project",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                table: "RoleClaim",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claim");

            migrationBuilder.DropTable(
                name: "EmployeeProject");

            migrationBuilder.DropTable(
                name: "EmployeeRole");

            migrationBuilder.DropTable(
                name: "LeaveRequestApproval");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "LeaveRequest");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
