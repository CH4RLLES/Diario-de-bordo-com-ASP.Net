using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiarioDeBordo.Infra.Dados.Migrations
{
    public partial class correcoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtividadesEfetuadas_TiposAtividades_IdTipoAtividade",
                table: "AtividadesEfetuadas");

            migrationBuilder.DropTable(
                name: "TiposAtividades");


            migrationBuilder.DropColumn(
                name: "IdTipoAtividade",
                table: "AtividadesEfetuadas");

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "AtividadesEfetuadas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "AtividadesEfetuadas");

            migrationBuilder.AddColumn<Guid>(
                name: "IdTipoAtividade",
                table: "AtividadesEfetuadas",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TiposAtividades",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposAtividades", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtividadesEfetuadas_IdTipoAtividade",
                table: "AtividadesEfetuadas",
                column: "IdTipoAtividade");

            migrationBuilder.AddForeignKey(
                name: "FK_AtividadesEfetuadas_TiposAtividades_IdTipoAtividade",
                table: "AtividadesEfetuadas",
                column: "IdTipoAtividade",
                principalTable: "TiposAtividades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
