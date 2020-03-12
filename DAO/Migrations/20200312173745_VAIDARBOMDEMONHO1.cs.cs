using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class VAIDARBOMDEMONHO1cs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RefeicaoDTOID",
                table: "INGREDIENTES",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_INGREDIENTES_RefeicaoDTOID",
                table: "INGREDIENTES",
                column: "RefeicaoDTOID");

            migrationBuilder.AddForeignKey(
                name: "FK_INGREDIENTES_REFEICOES_RefeicaoDTOID",
                table: "INGREDIENTES",
                column: "RefeicaoDTOID",
                principalTable: "REFEICOES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_INGREDIENTES_REFEICOES_RefeicaoDTOID",
                table: "INGREDIENTES");

            migrationBuilder.DropIndex(
                name: "IX_INGREDIENTES_RefeicaoDTOID",
                table: "INGREDIENTES");

            migrationBuilder.DropColumn(
                name: "RefeicaoDTOID",
                table: "INGREDIENTES");
        }
    }
}
