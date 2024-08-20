using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DaigFlow.Migrations
{
    public partial class newwork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Daigs",
                newName: "DaigId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DaigId",
                table: "Daigs",
                newName: "Id");
        }
    }
}
