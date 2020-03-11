using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class TESTECS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Preco",
                table: "BEBIDAS",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Preco",
                table: "BEBIDAS",
                type: "float",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
