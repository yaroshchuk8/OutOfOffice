using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OutOfOffice.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ExtendIdentityUserAndRenameIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequest_Employee_EmployeeId",
                table: "LeaveRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Employee_ManagerId",
                table: "Project");

            migrationBuilder.DropTable(
                name: "ApprovalRequest");

            migrationBuilder.DropTable(
                name: "EmployeeProject");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Project_ManagerId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_LeaveRequest_EmployeeId",
                table: "LeaveRequest");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "92d723f4-81c5-4109-b962-bbec93185fe7", "3c155c25-ef31-41c0-9023-dbf59506d2c2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ce7db7fd-ba3f-4cc7-8d37-a831b0725379", "91565f7d-00f0-4e36-8b54-0d9210668113" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "57bde49e-8d41-45c4-baea-29141e2b2b6c", "c97575f3-7279-42a7-a52c-8c9c04e5d8b6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "92d723f4-81c5-4109-b962-bbec93185fe7", "efa05cf9-5f6f-41ff-a3b7-a4b2d40739ef" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57bde49e-8d41-45c4-baea-29141e2b2b6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92d723f4-81c5-4109-b962-bbec93185fe7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce7db7fd-ba3f-4cc7-8d37-a831b0725379");

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

            migrationBuilder.AlterColumn<string>(
                name: "ManagerId",
                table: "Project",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "LeaveRequest",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.CreateTable(
                name: "LeaveRequestApproval",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApproverId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeaveRequestId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequestApproval", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequestApproval");

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

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "Project",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Project",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "LeaveRequest",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeoplePartnerId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutOfOfficeBalance = table.Column<int>(type: "int", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subdivision = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_AspNetUsers_UserId",
                        column: x => x.UserId,
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
                name: "ApprovalRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApproverId = table.Column<int>(type: "int", nullable: false),
                    LeaveRequestId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovalRequest_Employee_ApproverId",
                        column: x => x.ApproverId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalRequest_LeaveRequest_LeaveRequestId",
                        column: x => x.LeaveRequestId,
                        principalTable: "LeaveRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProject",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", null, "Admin", "ADMIN" },
                    { "57bde49e-8d41-45c4-baea-29141e2b2b6c", null, "Project manager", "PROJECT MANAGER" },
                    { "92d723f4-81c5-4109-b962-bbec93185fe7", null, "Employee", "EMPLOYEE" },
                    { "ce7db7fd-ba3f-4cc7-8d37-a831b0725379", null, "HR manager", "HR MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3c155c25-ef31-41c0-9023-dbf59506d2c2", 0, "d27e22e8-1de2-48e9-9e2c-3cea10c8c93d", null, false, false, null, null, "EMPLOYEE1@GMAIL.COM", "AQAAAAIAAYagAAAAENzbnXf+HuYW+duipUXvROpGTDurauiY1x5+wNBCdA+oGxPWTohMOwB6u0923+0D7A==", null, false, "7f601b68-99b1-49b3-8705-296473bb995d", false, "employee1@gmail.com" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "5d7c1d79-c2c6-4f3b-9fd2-015861e0aaa3", null, false, false, null, null, "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEKmbPuLYzDgyyZRAm0T4UPj9T8/u+OsOpw2leJ+HVnMZqOwu4oCqtHc0iZ6pB7RSAA==", null, false, "a3a755f4-d183-4ac5-891a-530aa7c1c085", false, "admin@gmail.com" },
                    { "91565f7d-00f0-4e36-8b54-0d9210668113", 0, "55d0dbae-cc4a-4301-ae5b-1f4d08f3e854", null, false, false, null, null, "HRMANAGER@GMAIL.COM", "AQAAAAIAAYagAAAAEHb0zDNzZ/LDpfmBLF+LLXNyQWoGhiT9+2lxI373ICMAQIthcgcPv4SIaeaSf16xKw==", null, false, "b878c6e2-8a20-40da-a426-3611050aa5cf", false, "hrmanager@gmail.com" },
                    { "c97575f3-7279-42a7-a52c-8c9c04e5d8b6", 0, "4779f1cb-3d3a-4bbd-a3a8-39440ca532ed", null, false, false, null, null, "PROJECTMANAGER@GMAIL.COM", "AQAAAAIAAYagAAAAEMCS1jCVwqIicxbFQanwgwKqFdoyiPgaFq1YpuQ6kKICwpKbntC1I8JTz7RwdzdrvA==", null, false, "70b8ccf2-de00-461b-bdf6-04d61955a33a", false, "projectmanager@gmail.com" },
                    { "efa05cf9-5f6f-41ff-a3b7-a4b2d40739ef", 0, "576a9788-25dd-4433-9116-f21ec34c65a8", null, false, false, null, null, "EMPLOYEE2@GMAIL.COM", "AQAAAAIAAYagAAAAEIWJg/HZLuMMJneCEWVjeBtrdVyj/sX542mUWXK3Rj9sDAGtuaqyufdpsD09mplQvQ==", null, false, "dbf3b871-811c-4290-a4a5-4ffb32e1d713", false, "employee2@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "92d723f4-81c5-4109-b962-bbec93185fe7", "3c155c25-ef31-41c0-9023-dbf59506d2c2" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "ce7db7fd-ba3f-4cc7-8d37-a831b0725379", "91565f7d-00f0-4e36-8b54-0d9210668113" },
                    { "57bde49e-8d41-45c4-baea-29141e2b2b6c", "c97575f3-7279-42a7-a52c-8c9c04e5d8b6" },
                    { "92d723f4-81c5-4109-b962-bbec93185fe7", "efa05cf9-5f6f-41ff-a3b7-a4b2d40739ef" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "FullName", "OutOfOfficeBalance", "PeoplePartnerId", "PhotoUrl", "Position", "Status", "Subdivision", "UserId" },
                values: new object[,]
                {
                    { 1, "Alyssa Kennedy", 15, null, "\\photos\\780bde51-e8e8-43ca-8db4-cda2e4ff4248.png", "Hr Manager", "Active", "Recruiting", "91565f7d-00f0-4e36-8b54-0d9210668113" },
                    { 2, "Oliver Dodger", 10, null, "\\photos\\16c0f1a5-2d26-4be6-a690-2383571bf409.png", "Project Manager", "Active", "IT", "c97575f3-7279-42a7-a52c-8c9c04e5d8b6" },
                    { 3, "Grace Carney", 3, null, null, "Programmer", "Active", "IT", "3c155c25-ef31-41c0-9023-dbf59506d2c2" },
                    { 4, "Justin Valencia", 5, null, null, "Accountant", "Active", "Sales", "efa05cf9-5f6f-41ff-a3b7-a4b2d40739ef" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_ManagerId",
                table: "Project",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequest_EmployeeId",
                table: "LeaveRequest",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequest_ApproverId",
                table: "ApprovalRequest",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequest_LeaveRequestId",
                table: "ApprovalRequest",
                column: "LeaveRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PeoplePartnerId",
                table: "Employee",
                column: "PeoplePartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_UserId",
                table: "Employee",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_ProjectId",
                table: "EmployeeProject",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequest_Employee_EmployeeId",
                table: "LeaveRequest",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Employee_ManagerId",
                table: "Project",
                column: "ManagerId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
