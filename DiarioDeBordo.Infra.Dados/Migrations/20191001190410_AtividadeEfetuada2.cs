using Microsoft.EntityFrameworkCore.Migrations;

namespace DiarioDeBordo.Infra.Dados.Migrations
{
    public partial class AtividadeEfetuada2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtividadesEfetuadas_Atividades_AtividadeFeitaId",
                table: "AtividadesEfetuadas");

            migrationBuilder.DropForeignKey(
                name: "FK_AtividadesEfetuadas_TiposAtividades_TipoAtividadeFeitaId",
                table: "AtividadesEfetuadas");

            migrationBuilder.DropForeignKey(
                name: "FK_AtividadesEfetuadas_Usuarios_UsuarioAtividadeId",
                table: "AtividadesEfetuadas");

            migrationBuilder.RenameColumn(
                name: "UsuarioAtividadeId",
                table: "AtividadesEfetuadas",
                newName: "UsuarioAtividade");

            migrationBuilder.RenameColumn(
                name: "TipoAtividadeFeitaId",
                table: "AtividadesEfetuadas",
                newName: "IdTipoAtividade");

            migrationBuilder.RenameColumn(
                name: "AtividadeFeitaId",
                table: "AtividadesEfetuadas",
                newName: "IdAtividade");

            migrationBuilder.AddForeignKey(
                name: "FK_AtividadesEfetuadas_Atividades_IdAtividade",
                table: "AtividadesEfetuadas",
                column: "IdAtividade",
                principalTable: "Atividades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtividadesEfetuadas_TiposAtividades_IdTipoAtividade",
                table: "AtividadesEfetuadas",
                column: "IdTipoAtividade",
                principalTable: "TiposAtividades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtividadesEfetuadas_Usuarios_UsuarioAtividade",
                table: "AtividadesEfetuadas",
                column: "UsuarioAtividade",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtividadesEfetuadas_Atividades_IdAtividade",
                table: "AtividadesEfetuadas");

            migrationBuilder.DropForeignKey(
                name: "FK_AtividadesEfetuadas_TiposAtividades_IdTipoAtividade",
                table: "AtividadesEfetuadas");

            migrationBuilder.DropForeignKey(
                name: "FK_AtividadesEfetuadas_Usuarios_UsuarioAtividade",
                table: "AtividadesEfetuadas");

            migrationBuilder.RenameColumn(
                name: "UsuarioAtividade",
                table: "AtividadesEfetuadas",
                newName: "UsuarioAtividadeId");

            migrationBuilder.RenameColumn(
                name: "IdTipoAtividade",
                table: "AtividadesEfetuadas",
                newName: "TipoAtividadeFeitaId");

            migrationBuilder.RenameColumn(
                name: "IdAtividade",
                table: "AtividadesEfetuadas",
                newName: "AtividadeFeitaId");

            migrationBuilder.RenameIndex(
                name: "IX_AtividadesEfetuadas_UsuarioAtividade",
                table: "AtividadesEfetuadas",
                newName: "IX_AtividadesEfetuadas_UsuarioAtividadeId");

            migrationBuilder.RenameIndex(
                name: "IX_AtividadesEfetuadas_IdTipoAtividade",
                table: "AtividadesEfetuadas",
                newName: "IX_AtividadesEfetuadas_TipoAtividadeFeitaId");

            migrationBuilder.RenameIndex(
                name: "IX_AtividadesEfetuadas_IdAtividade",
                table: "AtividadesEfetuadas",
                newName: "IX_AtividadesEfetuadas_AtividadeFeitaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtividadesEfetuadas_Atividades_AtividadeFeitaId",
                table: "AtividadesEfetuadas",
                column: "AtividadeFeitaId",
                principalTable: "Atividades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtividadesEfetuadas_TiposAtividades_TipoAtividadeFeitaId",
                table: "AtividadesEfetuadas",
                column: "TipoAtividadeFeitaId",
                principalTable: "TiposAtividades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtividadesEfetuadas_Usuarios_UsuarioAtividadeId",
                table: "AtividadesEfetuadas",
                column: "UsuarioAtividadeId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
