using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSomeField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Code",
                table: "LeaveTypes",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "LeaveTypes",
                newName: "Code");
        }
    }
}
