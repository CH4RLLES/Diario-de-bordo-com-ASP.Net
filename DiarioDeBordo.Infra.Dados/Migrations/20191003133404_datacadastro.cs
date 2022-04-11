using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiarioDeBordo.Infra.Dados.Migrations
{
    public partial class datacadastro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraCadastro",
                table: "AtividadesEfetuadas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataHoraCadastro",
                table: "AtividadesEfetuadas");
        }
    }
}
