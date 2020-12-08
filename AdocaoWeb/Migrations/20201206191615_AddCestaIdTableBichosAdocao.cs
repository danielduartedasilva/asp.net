using Microsoft.EntityFrameworkCore.Migrations;

namespace AdocaoWeb.Migrations
{
    public partial class AddCestaIdTableBichosAdocao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CestaId",
                table: "BichosAdocao",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CestaId",
                table: "BichosAdocao");
        }
    }
}
