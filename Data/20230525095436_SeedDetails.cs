using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfileManagement.Data
{
    public partial class SeedDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "ProfileDetail");

            migrationBuilder.InsertData(
                table: "ProfileDetail",
                columns: new[] { "Id", "Department", "Email", "Experience", "Name", "Projects", "Skills" },
                values: new object[] { 1, 2, "mark@gmail.com", "1 year", "Mark", "Todo App", "Writing" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProfileDetail",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "ProfileDetail",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
