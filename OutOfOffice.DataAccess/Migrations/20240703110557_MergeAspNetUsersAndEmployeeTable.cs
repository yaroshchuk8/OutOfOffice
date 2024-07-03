using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OutOfOffice.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MergeAspNetUsersAndEmployeeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Claim_AspNetUsers_UserId",
                table: "Claim");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AspNetUsers_Id",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRole_AspNetUsers_UserId",
                table: "EmployeeRole");

            migrationBuilder.DropForeignKey(
                name: "FK_Login_AspNetUsers_UserId",
                table: "Login");

            migrationBuilder.DropForeignKey(
                name: "FK_Token_AspNetUsers_UserId",
                table: "Token");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employee",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Employee",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Employee",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Employee",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Employee",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Employee",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Employee",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Employee",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Employee",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: "3c155c25-ef31-41c0-9023-dbf59506d2c2",
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "5835cf5c-d288-489e-8dfa-245e51cef5c8", null, false, false, null, null, "EMPLOYEE1@GMAIL.COM", "AQAAAAIAAYagAAAAEHz7kOy3OlhUXG0DGHQxfTiXkw8Wiow+tpPo5ji7rt1vL6I4kgnBowQY5Z0hN6pxlA==", null, false, "f4c00ab6-85c0-470c-9e20-905a40da3b8b", false, "employee1@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "541fc2fe-2ff6-44a8-a3d3-b8495c0e8e44", null, false, false, null, null, "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEGoFnaRfWvSTuxpndKwwQmOKpd5eFtLLV2pBJivzNF8Wq9/FSR3kEMfRzRXMosg/ng==", null, false, "632dbd02-3917-4cb2-955c-4ede80680876", false, "admin@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: "91565f7d-00f0-4e36-8b54-0d9210668113",
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "52f46f61-2408-4212-9457-34ad4c4171d5", null, false, false, null, null, "HRMANAGER@GMAIL.COM", "AQAAAAIAAYagAAAAEEDGVY2RDchr7MIat17QK1t6JsK1aAgl6mxsgP8xrZW4TPc/vZKAlrYbM7nhwF7ESg==", null, false, "31acb626-440d-478b-b1f1-c2bf16fffe5b", false, "hrmanager@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: "c97575f3-7279-42a7-a52c-8c9c04e5d8b6",
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "3518a49f-d8f4-48fb-871a-00d8ecdccc0c", null, false, false, null, null, "PROJECTMANAGER@GMAIL.COM", "AQAAAAIAAYagAAAAEDd6secf9FyP+rOLbFvNEWfTS5RpatYBN5EZ6sjZ4abuQi+QIxnH/lnfrlf06ppKWg==", null, false, "62bbf669-1f49-421b-aa0c-7f8c3c1d0568", false, "projectmanager@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: "efa05cf9-5f6f-41ff-a3b7-a4b2d40739ef",
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "1568b9b9-5882-47f9-a34a-8c9379bd2f2b", null, false, false, null, null, "EMPLOYEE2@GMAIL.COM", "AQAAAAIAAYagAAAAELHY/XsUNG6zPxHcSlBU1FaQHNeAGOvtBqr4406zHUpiAckJHwEQuuK/ddAvm9VXbA==", null, false, "bf41dceb-c1ae-402b-9a04-8bae88295259", false, "employee2@gmail.com" });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Employee",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Employee",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Claim_Employee_UserId",
                table: "Claim",
                column: "UserId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRole_Employee_UserId",
                table: "EmployeeRole",
                column: "UserId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Login_Employee_UserId",
                table: "Login",
                column: "UserId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Token_Employee_UserId",
                table: "Token",
                column: "UserId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Claim_Employee_UserId",
                table: "Claim");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRole_Employee_UserId",
                table: "EmployeeRole");

            migrationBuilder.DropForeignKey(
                name: "FK_Login_Employee_UserId",
                table: "Login");

            migrationBuilder.DropForeignKey(
                name: "FK_Token_Employee_UserId",
                table: "Token");

            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Employee");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Claim_AspNetUsers_UserId",
                table: "Claim",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_AspNetUsers_Id",
                table: "Employee",
                column: "Id",
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
                name: "FK_Login_AspNetUsers_UserId",
                table: "Login",
                column: "UserId",
                principalTable: "AspNetUsers",
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
    }
}
