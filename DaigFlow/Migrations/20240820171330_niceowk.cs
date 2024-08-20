using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DaigFlow.Migrations
{
    public partial class niceowk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalCount",
                table: "Daigs",
                newName: "Price");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Daigs",
                newName: "TotalCount");
        }
    }
}
