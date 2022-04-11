using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiarioDeBordo.Infra.Dados.Migrations
{
    public partial class alter_atividade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdPai",
                table: "Atividades",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "NumProcesso",
                table: "Atividades",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Quantidade",
                table: "Atividades",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Sistema",
                table: "Atividades",
                nullable: false,
                defaultValue: 0);

            

            migrationBuilder.AddForeignKey(
                name: "FK_Atividades_Atividades_IdPai",
                table: "Atividades",
                column: "IdPai",
                principalTable: "Atividades",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atividades_Atividades_IdPai",
                table: "Atividades");

            migrationBuilder.DropIndex(
                name: "IX_Atividades_IdPai",
                table: "Atividades");

            migrationBuilder.DropColumn(
                name: "IdPai",
                table: "Atividades");

            migrationBuilder.DropColumn(
                name: "NumProcesso",
                table: "Atividades");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Atividades");

            migrationBuilder.DropColumn(
                name: "Sistema",
                table: "Atividades");
        }
    }
}
