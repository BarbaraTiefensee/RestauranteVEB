using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class TDSJADSJDSACS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Preco",
                table: "BEBIDAS",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Preco",
                table: "BEBIDAS",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
