using Microsoft.EntityFrameworkCore.Migrations;

namespace DiarioDeBordo.Infra.Dados.Migrations
{
    public partial class usuario3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ControleAcesso",
                table: "Usuarios",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ControleAcesso",
                table: "Usuarios");
        }
    }
}
