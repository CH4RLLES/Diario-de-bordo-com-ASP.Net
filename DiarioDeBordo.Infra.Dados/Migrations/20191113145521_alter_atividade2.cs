using Microsoft.EntityFrameworkCore.Migrations;

namespace DiarioDeBordo.Infra.Dados.Migrations
{
    public partial class alter_atividade2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atividades_Atividades_IdPai",
                table: "Atividades");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Atividades_IdPai",
                table: "Atividades",
                column: "IdPai",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Atividades_Atividades_IdPai",
                table: "Atividades",
                column: "IdPai",
                principalTable: "Atividades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
