using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class demonioCS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_INGREDIENTES_Nome",
                table: "INGREDIENTES",
                column: "Nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_INGREDIENTES_Nome",
                table: "INGREDIENTES");
        }
    }
}
