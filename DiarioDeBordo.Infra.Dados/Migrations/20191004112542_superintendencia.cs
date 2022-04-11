using Microsoft.EntityFrameworkCore.Migrations;

namespace DiarioDeBordo.Infra.Dados.Migrations
{
    public partial class superintendencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Superintendencia",
                table: "Usuarios",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Superintendencia",
                table: "Usuarios");
        }
    }
}
