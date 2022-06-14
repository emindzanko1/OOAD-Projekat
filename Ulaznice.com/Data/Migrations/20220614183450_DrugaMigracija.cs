using Microsoft.EntityFrameworkCore.Migrations;

namespace Ulaznice.com.Data.Migrations
{
    public partial class DrugaMigracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrikazMjesta",
                table: "SlobodnaMjesta",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrikazKarte",
                table: "PovratniMail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SlikaNagrade",
                table: "Nagrada",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrikazMjesta",
                table: "SlobodnaMjesta");

            migrationBuilder.DropColumn(
                name: "PrikazKarte",
                table: "PovratniMail");

            migrationBuilder.DropColumn(
                name: "SlikaNagrade",
                table: "Nagrada");
        }
    }
}
