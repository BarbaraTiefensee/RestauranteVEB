using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class qualquermerdacs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BEBIDAS_PEDIDOS_PedidoDTOID",
                table: "BEBIDAS");

            migrationBuilder.DropForeignKey(
                name: "FK_INGREDIENTES_INGREDIENTES_IngredienteDTOID",
                table: "INGREDIENTES");

            migrationBuilder.DropForeignKey(
                name: "FK_INGREDIENTES_REFEICOES_RefeicaoDTOID",
                table: "INGREDIENTES");

            migrationBuilder.DropForeignKey(
                name: "FK_PEDIDOS_BEBIDAS_BebidaID",
                table: "PEDIDOS");

            migrationBuilder.DropForeignKey(
                name: "FK_PEDIDOS_REFEICOES_RefeicaoID",
                table: "PEDIDOS");

            migrationBuilder.DropForeignKey(
                name: "FK_REFEICOES_PEDIDOS_PedidoDTOID",
                table: "REFEICOES");

            migrationBuilder.DropIndex(
                name: "IX_REFEICOES_PedidoDTOID",
                table: "REFEICOES");

            migrationBuilder.DropIndex(
                name: "IX_PEDIDOS_BebidaID",
                table: "PEDIDOS");

            migrationBuilder.DropIndex(
                name: "IX_PEDIDOS_RefeicaoID",
                table: "PEDIDOS");

            migrationBuilder.DropIndex(
                name: "IX_INGREDIENTES_IngredienteDTOID",
                table: "INGREDIENTES");

            migrationBuilder.DropIndex(
                name: "IX_INGREDIENTES_RefeicaoDTOID",
                table: "INGREDIENTES");

            migrationBuilder.DropIndex(
                name: "IX_BEBIDAS_PedidoDTOID",
                table: "BEBIDAS");

            migrationBuilder.DropColumn(
                name: "PedidoDTOID",
                table: "REFEICOES");

            migrationBuilder.DropColumn(
                name: "BebidaID",
                table: "PEDIDOS");

            migrationBuilder.DropColumn(
                name: "RefeicaoID",
                table: "PEDIDOS");

            migrationBuilder.DropColumn(
                name: "IngredienteDTOID",
                table: "INGREDIENTES");

            migrationBuilder.DropColumn(
                name: "RefeicaoDTOID",
                table: "INGREDIENTES");

            migrationBuilder.DropColumn(
                name: "PedidoDTOID",
                table: "BEBIDAS");

            migrationBuilder.CreateTable(
                name: "PedidoBebida",
                columns: table => new
                {
                    PedidoID = table.Column<int>(nullable: false),
                    BebidaID = table.Column<int>(nullable: false),
                    BebidaID1 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoBebida", x => new { x.PedidoID, x.BebidaID });
                    table.ForeignKey(
                        name: "FK_PedidoBebida_PEDIDOS_BebidaID",
                        column: x => x.BebidaID,
                        principalTable: "PEDIDOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PedidoBebida_BEBIDAS_BebidaID1",
                        column: x => x.BebidaID1,
                        principalTable: "BEBIDAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoRefeicao",
                columns: table => new
                {
                    PedidoID = table.Column<int>(nullable: false),
                    RefeicaoID = table.Column<int>(nullable: false),
                    RefeicaoID1 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoRefeicao", x => new { x.PedidoID, x.RefeicaoID });
                    table.ForeignKey(
                        name: "FK_PedidoRefeicao_PEDIDOS_RefeicaoID",
                        column: x => x.RefeicaoID,
                        principalTable: "PEDIDOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PedidoRefeicao_REFEICOES_RefeicaoID1",
                        column: x => x.RefeicaoID1,
                        principalTable: "REFEICOES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefeicaoIngrediente",
                columns: table => new
                {
                    RefeicaoID = table.Column<int>(nullable: false),
                    IngredienteID = table.Column<int>(nullable: false),
                    IngredienteID1 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefeicaoIngrediente", x => new { x.RefeicaoID, x.IngredienteID });
                    table.ForeignKey(
                        name: "FK_RefeicaoIngrediente_REFEICOES_IngredienteID",
                        column: x => x.IngredienteID,
                        principalTable: "REFEICOES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RefeicaoIngrediente_INGREDIENTES_IngredienteID1",
                        column: x => x.IngredienteID1,
                        principalTable: "INGREDIENTES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoBebida_BebidaID",
                table: "PedidoBebida",
                column: "BebidaID");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoBebida_BebidaID1",
                table: "PedidoBebida",
                column: "BebidaID1");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoRefeicao_RefeicaoID",
                table: "PedidoRefeicao",
                column: "RefeicaoID");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoRefeicao_RefeicaoID1",
                table: "PedidoRefeicao",
                column: "RefeicaoID1");

            migrationBuilder.CreateIndex(
                name: "IX_RefeicaoIngrediente_IngredienteID",
                table: "RefeicaoIngrediente",
                column: "IngredienteID");

            migrationBuilder.CreateIndex(
                name: "IX_RefeicaoIngrediente_IngredienteID1",
                table: "RefeicaoIngrediente",
                column: "IngredienteID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoBebida");

            migrationBuilder.DropTable(
                name: "PedidoRefeicao");

            migrationBuilder.DropTable(
                name: "RefeicaoIngrediente");

            migrationBuilder.AddColumn<int>(
                name: "PedidoDTOID",
                table: "REFEICOES",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BebidaID",
                table: "PEDIDOS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RefeicaoID",
                table: "PEDIDOS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IngredienteDTOID",
                table: "INGREDIENTES",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RefeicaoDTOID",
                table: "INGREDIENTES",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PedidoDTOID",
                table: "BEBIDAS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_REFEICOES_PedidoDTOID",
                table: "REFEICOES",
                column: "PedidoDTOID");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDOS_BebidaID",
                table: "PEDIDOS",
                column: "BebidaID");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDOS_RefeicaoID",
                table: "PEDIDOS",
                column: "RefeicaoID");

            migrationBuilder.CreateIndex(
                name: "IX_INGREDIENTES_IngredienteDTOID",
                table: "INGREDIENTES",
                column: "IngredienteDTOID");

            migrationBuilder.CreateIndex(
                name: "IX_INGREDIENTES_RefeicaoDTOID",
                table: "INGREDIENTES",
                column: "RefeicaoDTOID");

            migrationBuilder.CreateIndex(
                name: "IX_BEBIDAS_PedidoDTOID",
                table: "BEBIDAS",
                column: "PedidoDTOID");

            migrationBuilder.AddForeignKey(
                name: "FK_BEBIDAS_PEDIDOS_PedidoDTOID",
                table: "BEBIDAS",
                column: "PedidoDTOID",
                principalTable: "PEDIDOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_INGREDIENTES_INGREDIENTES_IngredienteDTOID",
                table: "INGREDIENTES",
                column: "IngredienteDTOID",
                principalTable: "INGREDIENTES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_INGREDIENTES_REFEICOES_RefeicaoDTOID",
                table: "INGREDIENTES",
                column: "RefeicaoDTOID",
                principalTable: "REFEICOES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_REFEICOES_PEDIDOS_PedidoDTOID",
                table: "REFEICOES",
                column: "PedidoDTOID",
                principalTable: "PEDIDOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
