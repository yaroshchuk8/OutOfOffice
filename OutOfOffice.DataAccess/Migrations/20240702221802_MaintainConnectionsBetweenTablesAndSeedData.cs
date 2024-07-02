using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OutOfOffice.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MaintainConnectionsBetweenTablesAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OutOfOfficeBalance",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PeoplePartnerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Subdivision",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "Token");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "EmployeeRole");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "Login");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "Claim");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "RoleClaim");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "EmployeeRole",
                newName: "IX_EmployeeRole_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "Login",
                newName: "IX_Login_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "Claim",
                newName: "IX_Claim_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "RoleClaim",
                newName: "IX_RoleClaim_RoleId");

            migrationBuilder.AlterColumn<string>(
                name: "ManagerId",
                table: "Project",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ApproverId",
                table: "LeaveRequestApproval",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "LeaveRequest",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Token",
                table: "Token",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeRole",
                table: "EmployeeRole",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Login",
                table: "Login",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Claim",
                table: "Claim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleClaim",
                table: "RoleClaim",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subdivision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeoplePartnerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OutOfOfficeBalance = table.Column<int>(type: "int", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Employee_PeoplePartnerId",
                        column: x => x.PeoplePartnerId,
                        principalTable: "Employee",
                        principalColumn: "Id");
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
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3c155c25-ef31-41c0-9023-dbf59506d2c2", 0, "92ba3018-c0a7-49b6-83dd-43dd97c20aa8", null, false, false, null, null, "EMPLOYEE1@GMAIL.COM", "AQAAAAIAAYagAAAAELkamKzJEdJ5Ryqjxo4zMAheYIRGc8dC0FK97Zcet3sGGfDP5c71BrEcZzIqe/imBg==", null, false, "27ad1851-eed5-45c5-9575-5bdab0602097", false, "employee1@gmail.com" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "f3433776-130b-47bd-82d9-07273e345715", null, false, false, null, null, "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEBXaRglaUxJtmXRwCNr9GX6yIW6djekRIP17tvOmi7j5cmBv3Ayd/reoaEK8kU1vvw==", null, false, "b69d51b8-885d-4282-8565-bdea598fec3f", false, "admin@gmail.com" },
                    { "91565f7d-00f0-4e36-8b54-0d9210668113", 0, "170279bb-b36d-4334-af19-b11d6261b854", null, false, false, null, null, "HRMANAGER@GMAIL.COM", "AQAAAAIAAYagAAAAEOU6ENjGUwBxAaRAhLEEVDlaN0Z0AJCQo9mA7t1+5IUo68BO15IuL8WS0XlSFf3E1g==", null, false, "b95c4165-e7fc-4a0e-9719-3990ed9842ba", false, "hrmanager@gmail.com" },
                    { "c97575f3-7279-42a7-a52c-8c9c04e5d8b6", 0, "d13fccb4-3a67-4a0d-8555-1b459f50f9af", null, false, false, null, null, "PROJECTMANAGER@GMAIL.COM", "AQAAAAIAAYagAAAAEGaJSL6CLBBHeYPxLzLvgSyh2YygHa9ZLE8Vx3eLkGoGcSHKGVwtAXC0N8rlY6Mbwg==", null, false, "da75e478-5921-42d3-8438-851799abf797", false, "projectmanager@gmail.com" },
                    { "efa05cf9-5f6f-41ff-a3b7-a4b2d40739ef", 0, "bd7a3163-0b41-4ce1-a57e-16eba0551901", null, false, false, null, null, "EMPLOYEE2@GMAIL.COM", "AQAAAAIAAYagAAAAEHz5fek2qCu86OYnvOTkCtVk+m7DDingFC+kCGXxcCgJVMWMzGPpp9i9K3RvD0Y/AQ==", null, false, "21a0ea7a-d246-4077-8293-46279d9cb904", false, "employee2@gmail.com" }
                });

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
                columns: new[] { "Id", "FullName", "OutOfOfficeBalance", "PeoplePartnerId", "PhotoUrl", "Position", "Status", "Subdivision" },
                values: new object[,]
                {
                    { "3c155c25-ef31-41c0-9023-dbf59506d2c2", "Grace Carney", 3, null, null, "Programmer", "Active", "IT" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", "Denis McBoss", 15, null, null, "Administrator", "Active", "IT" },
                    { "91565f7d-00f0-4e36-8b54-0d9210668113", "Alyssa Kennedy", 15, null, "\\photos\\780bde51-e8e8-43ca-8db4-cda2e4ff4248.png", "Hr Manager", "Active", "Recruiting" },
                    { "c97575f3-7279-42a7-a52c-8c9c04e5d8b6", "Oliver Dodger", 10, null, "\\photos\\16c0f1a5-2d26-4be6-a690-2383571bf409.png", "Project Manager", "Active", "IT" },
                    { "efa05cf9-5f6f-41ff-a3b7-a4b2d40739ef", "Justin Valencia", 5, null, null, "Accountant", "Active", "Sales" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "92d723f4-81c5-4109-b962-bbec93185fe7", "3c155c25-ef31-41c0-9023-dbf59506d2c2" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "ce7db7fd-ba3f-4cc7-8d37-a831b0725379", "91565f7d-00f0-4e36-8b54-0d9210668113" },
                    { "57bde49e-8d41-45c4-baea-29141e2b2b6c", "c97575f3-7279-42a7-a52c-8c9c04e5d8b6" },
                    { "92d723f4-81c5-4109-b962-bbec93185fe7", "efa05cf9-5f6f-41ff-a3b7-a4b2d40739ef" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_ManagerId",
                table: "Project",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequestApproval_ApproverId",
                table: "LeaveRequestApproval",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequestApproval_LeaveRequestId",
                table: "LeaveRequestApproval",
                column: "LeaveRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequest_EmployeeId",
                table: "LeaveRequest",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PeoplePartnerId",
                table: "Employee",
                column: "PeoplePartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_ProjectId",
                table: "EmployeeProject",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Claim_AspNetUsers_UserId",
                table: "Claim",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRole_AspNetUsers_UserId",
                table: "EmployeeRole",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRole_Role_RoleId",
                table: "EmployeeRole",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequest_Employee_EmployeeId",
                table: "LeaveRequest",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestApproval_Employee_ApproverId",
                table: "LeaveRequestApproval",
                column: "ApproverId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestApproval_LeaveRequest_LeaveRequestId",
                table: "LeaveRequestApproval",
                column: "LeaveRequestId",
                principalTable: "LeaveRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Login_AspNetUsers_UserId",
                table: "Login",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Employee_ManagerId",
                table: "Project",
                column: "ManagerId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaim_Role_RoleId",
                table: "RoleClaim",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Token_AspNetUsers_UserId",
                table: "Token",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Claim_AspNetUsers_UserId",
                table: "Claim");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRole_AspNetUsers_UserId",
                table: "EmployeeRole");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRole_Role_RoleId",
                table: "EmployeeRole");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequest_Employee_EmployeeId",
                table: "LeaveRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestApproval_Employee_ApproverId",
                table: "LeaveRequestApproval");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestApproval_LeaveRequest_LeaveRequestId",
                table: "LeaveRequestApproval");

            migrationBuilder.DropForeignKey(
                name: "FK_Login_AspNetUsers_UserId",
                table: "Login");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Employee_ManagerId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaim_Role_RoleId",
                table: "RoleClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_Token_AspNetUsers_UserId",
                table: "Token");

            migrationBuilder.DropTable(
                name: "EmployeeProject");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Project_ManagerId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_LeaveRequestApproval_ApproverId",
                table: "LeaveRequestApproval");

            migrationBuilder.DropIndex(
                name: "IX_LeaveRequestApproval_LeaveRequestId",
                table: "LeaveRequestApproval");

            migrationBuilder.DropIndex(
                name: "IX_LeaveRequest_EmployeeId",
                table: "LeaveRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Token",
                table: "Token");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleClaim",
                table: "RoleClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Login",
                table: "Login");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeRole",
                table: "EmployeeRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Claim",
                table: "Claim");

            migrationBuilder.DeleteData(
                table: "EmployeeRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "92d723f4-81c5-4109-b962-bbec93185fe7", "3c155c25-ef31-41c0-9023-dbf59506d2c2" });

            migrationBuilder.DeleteData(
                table: "EmployeeRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "EmployeeRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ce7db7fd-ba3f-4cc7-8d37-a831b0725379", "91565f7d-00f0-4e36-8b54-0d9210668113" });

            migrationBuilder.DeleteData(
                table: "EmployeeRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "57bde49e-8d41-45c4-baea-29141e2b2b6c", "c97575f3-7279-42a7-a52c-8c9c04e5d8b6" });

            migrationBuilder.DeleteData(
                table: "EmployeeRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "92d723f4-81c5-4109-b962-bbec93185fe7", "efa05cf9-5f6f-41ff-a3b7-a4b2d40739ef" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c155c25-ef31-41c0-9023-dbf59506d2c2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "91565f7d-00f0-4e36-8b54-0d9210668113");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c97575f3-7279-42a7-a52c-8c9c04e5d8b6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "efa05cf9-5f6f-41ff-a3b7-a4b2d40739ef");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "57bde49e-8d41-45c4-baea-29141e2b2b6c");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "92d723f4-81c5-4109-b962-bbec93185fe7");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "ce7db7fd-ba3f-4cc7-8d37-a831b0725379");

            migrationBuilder.RenameTable(
                name: "Token",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "RoleClaim",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "Login",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "EmployeeRole",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "Claim",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameIndex(
                name: "IX_RoleClaim_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Login_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeRole_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Claim_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "ManagerId",
                table: "Project",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ApproverId",
                table: "LeaveRequestApproval",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "LeaveRequest",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OutOfOfficeBalance",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PeoplePartnerId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subdivision",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
