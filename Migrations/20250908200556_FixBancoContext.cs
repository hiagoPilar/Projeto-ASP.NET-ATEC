using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_ASP.NET_Core_ATEC.Migrations
{
    /// <inheritdoc />
    public partial class FixBancoContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projetos_Clientes_ClienteId",
                table: "Projetos");

            migrationBuilder.AddForeignKey(
                name: "FK_Projetos_Clientes_ClienteId",
                table: "Projetos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projetos_Clientes_ClienteId",
                table: "Projetos");

            migrationBuilder.AddForeignKey(
                name: "FK_Projetos_Clientes_ClienteId",
                table: "Projetos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
