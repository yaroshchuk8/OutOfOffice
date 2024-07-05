using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutOfOffice.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MakeCommentColumnNullableInLeaveRequstAndLeaveRequestApprovalTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "LeaveRequestApproval",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "LeaveRequest",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: "3c155c25-ef31-41c0-9023-dbf59506d2c2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1000f19-6225-4842-ac60-91197467c5dc", "AQAAAAIAAYagAAAAELhnx0SSDinlcm2/r4oMZcd7wgGx+5+BXksUxMIVMZoZLpvmsBEM9lToephZUyspgQ==", "58a16a1d-33b3-4957-a0a8-b94135092814" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25a7c450-61f1-4d7e-9b1e-1d520d484621", "AQAAAAIAAYagAAAAEApSlgvK3yMNA13nKCVWDO2y3lPeH6T5ysvEgOL1eq9tJ1sSyPLJHLx4qpM8ZQP9Kg==", "28f8ddfd-7948-43be-88cd-8396102ad222" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: "91565f7d-00f0-4e36-8b54-0d9210668113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "56472937-5039-4bc7-9271-e6166a4fee75", "AQAAAAIAAYagAAAAECEppelnI1M8ExG30nXogo4iJhcM4Ermi9csqGIEFHTUVMG4aULtoausG9nTYaLRXA==", "f593d4ee-41fc-4d10-b91f-01b1ddd0b3c1" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: "c97575f3-7279-42a7-a52c-8c9c04e5d8b6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d9e8424-4880-409a-afc2-9c400fbe023a", "AQAAAAIAAYagAAAAED5p/TD2lw7MEcOdjDIn4WDp+qp7OvLpDyfUgWv2mQuRWAC++L7/cp6K5q5TX4UkVQ==", "12c280fa-9eda-43dd-ad15-6e2b0553c919" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: "efa05cf9-5f6f-41ff-a3b7-a4b2d40739ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5818573-c041-4ad8-bf45-d75caf29d646", "AQAAAAIAAYagAAAAEAYWcsBeTc9aledOQtijZtIiqaKhvIR3DtlYR1qj7fiXNZvVdnCL/R9MC5Q2rxh+EA==", "9276acdd-8d4c-47d9-bfd6-02be14c1777f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "LeaveRequestApproval",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "LeaveRequest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: "3c155c25-ef31-41c0-9023-dbf59506d2c2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02fbe290-6e82-4246-a0d8-b7b1b4bc6225", "AQAAAAIAAYagAAAAEFLBVrJZcaR2rJjdOMoualp+8WKaCfir6hkYJ8DKx8eN7gC5f+JfjFYb5yc4z+/H8w==", "0ff654e2-38cc-45b9-943c-eed2bfe9362b" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ed11de6-d72c-4bda-b867-1cc43c7e8662", "AQAAAAIAAYagAAAAEAzmvnS6b7deoUQpXN4k9dM21NPD1mrP80LteLkLX661sOgWrmjKFRcy2UFAMoPQiQ==", "c5e1fae3-05bb-420d-a267-f0277d7b84f6" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: "91565f7d-00f0-4e36-8b54-0d9210668113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ab0fd36-d2d4-43e6-bb74-8360c00aecc1", "AQAAAAIAAYagAAAAEGUBqZhk/tS0RvP5Ac+dCskP7QI7R1XA7u+bmhsyZ1zGmlLD31Ir3yHrDg8jZGibSA==", "aca415a3-0aae-44cc-bc94-9066a5e70695" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: "c97575f3-7279-42a7-a52c-8c9c04e5d8b6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a32cf73-4ba7-48d5-a266-311815336f0d", "AQAAAAIAAYagAAAAEPqdmjCmeXJm+7txaYNHN+flSdK+8hBy0TTCTgRc1vmVlQ9QuVYxrAPxltUvIX8XQg==", "032c0ec1-37bf-4b7e-868e-1c3d40eb8aa4" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: "efa05cf9-5f6f-41ff-a3b7-a4b2d40739ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e90b94b-5a33-4af8-8f0c-64a98ec89d1d", "AQAAAAIAAYagAAAAEFahM5Fqfm4NcFUtUJHqQP7UeV2Fr4ReydoiPqSFUnWfhUKDVikyEidqIytGS1Bc4w==", "2dd10d7c-9369-472f-b7fb-99914777bc69" });
        }
    }
}
