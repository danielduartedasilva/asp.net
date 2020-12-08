using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdocaoWeb.Migrations
{
    public partial class AddTableBichoAdocao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BichosAdocao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    AnimalId = table.Column<int>(nullable: true),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BichosAdocao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BichosAdocao_Animais_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BichosAdocao_AnimalId",
                table: "BichosAdocao",
                column: "AnimalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BichosAdocao");
        }
    }
}
