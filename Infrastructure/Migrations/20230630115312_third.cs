using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Student_Name",
                table: "Students",
                newName: "Last_Name");

            migrationBuilder.RenameColumn(
                name: "Student_Email",
                table: "Students",
                newName: "First_Name");

            migrationBuilder.AddColumn<string>(
                name: "Email_address",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email_address",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "Last_Name",
                table: "Students",
                newName: "Student_Name");

            migrationBuilder.RenameColumn(
                name: "First_Name",
                table: "Students",
                newName: "Student_Email");
        }
    }
}
