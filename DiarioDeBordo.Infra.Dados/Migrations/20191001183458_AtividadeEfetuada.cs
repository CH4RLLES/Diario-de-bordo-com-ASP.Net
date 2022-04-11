using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiarioDeBordo.Infra.Dados.Migrations
{
    public partial class AtividadeEfetuada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AtividadesEfetuadas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UsuarioAtividadeId = table.Column<Guid>(nullable: false),
                    TipoAtendimento = table.Column<int>(nullable: false),
                    DataAtividade = table.Column<DateTime>(nullable: false),
                    AtividadeFeitaId = table.Column<Guid>(nullable: false),
                    TipoAtividadeFeitaId = table.Column<Guid>(nullable: false),
                    ProcessoSEI = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtividadesEfetuadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtividadesEfetuadas_Atividades_AtividadeFeitaId",
                        column: x => x.AtividadeFeitaId,
                        principalTable: "Atividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtividadesEfetuadas_TiposAtividades_TipoAtividadeFeitaId",
                        column: x => x.TipoAtividadeFeitaId,
                        principalTable: "TiposAtividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtividadesEfetuadas_Usuarios_UsuarioAtividadeId",
                        column: x => x.UsuarioAtividadeId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_AtividadesEfetuadas_AtividadeFeitaId",
            //    table: "AtividadesEfetuadas",
            //    column: "AtividadeFeitaId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AtividadesEfetuadas_TipoAtividadeFeitaId",
            //    table: "AtividadesEfetuadas",
            //    column: "TipoAtividadeFeitaId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AtividadesEfetuadas_UsuarioAtividadeId",
            //    table: "AtividadesEfetuadas",
            //    column: "UsuarioAtividadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtividadesEfetuadas");
        }
    }
}
