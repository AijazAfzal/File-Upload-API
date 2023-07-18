using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Roll_No",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "Student_Email",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Student_Email",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "Roll_No",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
