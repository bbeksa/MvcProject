using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcProject.Migrations.MvcProject
{
    public partial class NazwaSezSetRem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataTextFieldLabel",
                table: "Seazon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DataTextFieldLabel",
                table: "Seazon",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
