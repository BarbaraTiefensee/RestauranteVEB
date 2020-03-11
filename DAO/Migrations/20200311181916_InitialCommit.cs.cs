using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class InitialCommitcs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "INGREDIENTES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    @float = table.Column<int>(name: "float", nullable: false),
                    IngredienteDTOID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INGREDIENTES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_INGREDIENTES_INGREDIENTES_IngredienteDTOID",
                        column: x => x.IngredienteDTOID,
                        principalTable: "INGREDIENTES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: true),
                    CPF = table.Column<string>(unicode: false, fixedLength: true, maxLength: 14, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    Senha = table.Column<string>(nullable: true),
                    Permissao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PEDIDOS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeNoPedido = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    RefeicaoID = table.Column<int>(nullable: false),
                    BebidaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDIDOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BEBIDAS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Preco = table.Column<double>(nullable: false),
                    PedidoDTOID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BEBIDAS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BEBIDAS_PEDIDOS_PedidoDTOID",
                        column: x => x.PedidoDTOID,
                        principalTable: "PEDIDOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "REFEICOES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Preco = table.Column<double>(unicode: false, nullable: false),
                    PedidoDTOID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REFEICOES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_REFEICOES_PEDIDOS_PedidoDTOID",
                        column: x => x.PedidoDTOID,
                        principalTable: "PEDIDOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BEBIDAS_PedidoDTOID",
                table: "BEBIDAS",
                column: "PedidoDTOID");

            migrationBuilder.CreateIndex(
                name: "IX_INGREDIENTES_IngredienteDTOID",
                table: "INGREDIENTES",
                column: "IngredienteDTOID");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDOS_BebidaID",
                table: "PEDIDOS",
                column: "BebidaID");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDOS_RefeicaoID",
                table: "PEDIDOS",
                column: "RefeicaoID");

            migrationBuilder.CreateIndex(
                name: "IX_REFEICOES_PedidoDTOID",
                table: "REFEICOES",
                column: "PedidoDTOID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_CPF",
                table: "USUARIOS",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_Email",
                table: "USUARIOS",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PEDIDOS_BEBIDAS_BebidaID",
                table: "PEDIDOS",
                column: "BebidaID",
                principalTable: "BEBIDAS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PEDIDOS_REFEICOES_RefeicaoID",
                table: "PEDIDOS",
                column: "RefeicaoID",
                principalTable: "REFEICOES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BEBIDAS_PEDIDOS_PedidoDTOID",
                table: "BEBIDAS");

            migrationBuilder.DropForeignKey(
                name: "FK_REFEICOES_PEDIDOS_PedidoDTOID",
                table: "REFEICOES");

            migrationBuilder.DropTable(
                name: "INGREDIENTES");

            migrationBuilder.DropTable(
                name: "USUARIOS");

            migrationBuilder.DropTable(
                name: "PEDIDOS");

            migrationBuilder.DropTable(
                name: "BEBIDAS");

            migrationBuilder.DropTable(
                name: "REFEICOES");
        }
    }
}
