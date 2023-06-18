using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfileManagement.Data
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfileDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Department = table.Column<int>(type: "INTEGER", nullable: false),
                    Skills = table.Column<string>(type: "TEXT", nullable: false),
                    Experience = table.Column<string>(type: "TEXT", nullable: false),
                    Projects = table.Column<string>(type: "TEXT", nullable: false) 
                 },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileDetail", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileDetail");
        }
    }
}
