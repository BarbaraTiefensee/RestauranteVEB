using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BEBIDAS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Preco = table.Column<double>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BEBIDAS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "INGREDIENTES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    @float = table.Column<int>(name: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INGREDIENTES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PEDIDOS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeNoPedido = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDIDOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "REFEICOES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Preco = table.Column<double>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REFEICOES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SOBREMESAS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Preco = table.Column<double>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SOBREMESAS", x => x.ID);
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
                    Senha = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    Permissao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.ID);
                });

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

            migrationBuilder.CreateTable(
                name: "PedidoSobremesa",
                columns: table => new
                {
                    PedidoID = table.Column<int>(nullable: false),
                    SobremesaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoSobremesa", x => new { x.PedidoID, x.SobremesaID });
                    table.ForeignKey(
                        name: "FK_PedidoSobremesa_PEDIDOS_PedidoID",
                        column: x => x.PedidoID,
                        principalTable: "PEDIDOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoSobremesa_SOBREMESAS_SobremesaID",
                        column: x => x.SobremesaID,
                        principalTable: "SOBREMESAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_INGREDIENTES_Nome",
                table: "INGREDIENTES",
                column: "Nome",
                unique: true);

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
                name: "IX_PedidoSobremesa_SobremesaID",
                table: "PedidoSobremesa",
                column: "SobremesaID");

            migrationBuilder.CreateIndex(
                name: "IX_RefeicaoIngrediente_IngredienteID",
                table: "RefeicaoIngrediente",
                column: "IngredienteID");

            migrationBuilder.CreateIndex(
                name: "IX_RefeicaoIngrediente_IngredienteID1",
                table: "RefeicaoIngrediente",
                column: "IngredienteID1");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoBebida");

            migrationBuilder.DropTable(
                name: "PedidoRefeicao");

            migrationBuilder.DropTable(
                name: "PedidoSobremesa");

            migrationBuilder.DropTable(
                name: "RefeicaoIngrediente");

            migrationBuilder.DropTable(
                name: "USUARIOS");

            migrationBuilder.DropTable(
                name: "BEBIDAS");

            migrationBuilder.DropTable(
                name: "PEDIDOS");

            migrationBuilder.DropTable(
                name: "SOBREMESAS");

            migrationBuilder.DropTable(
                name: "REFEICOES");

            migrationBuilder.DropTable(
                name: "INGREDIENTES");
        }
    }
}
