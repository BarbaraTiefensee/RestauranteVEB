﻿// <auto-generated />
using DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAO.Migrations
{
    [DbContext(typeof(RContext))]
    [Migration("20200312191812_satanas.cs")]
    partial class satanascs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DTO.BebidaDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<double>("Preco")
                        .HasColumnType("float")
                        .IsUnicode(true);

                    b.HasKey("ID");

                    b.ToTable("BEBIDAS");
                });

            modelBuilder.Entity("DTO.IngredienteDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("Quantidade")
                        .HasColumnName("float")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("INGREDIENTES");
                });

            modelBuilder.Entity("DTO.PedidoBebida", b =>
                {
                    b.Property<int>("PedidoID")
                        .HasColumnType("int");

                    b.Property<int>("BebidaID")
                        .HasColumnType("int");

                    b.Property<int>("BebidaID1")
                        .HasColumnType("int");

                    b.HasKey("PedidoID", "BebidaID");

                    b.HasIndex("BebidaID");

                    b.HasIndex("BebidaID1");

                    b.ToTable("PedidoBebida");
                });

            modelBuilder.Entity("DTO.PedidoDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeNoPedido")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("ID");

                    b.ToTable("PEDIDOS");
                });

            modelBuilder.Entity("DTO.PedidoRefeicao", b =>
                {
                    b.Property<int>("PedidoID")
                        .HasColumnType("int");

                    b.Property<int>("RefeicaoID")
                        .HasColumnType("int");

                    b.Property<int>("RefeicaoID1")
                        .HasColumnType("int");

                    b.HasKey("PedidoID", "RefeicaoID");

                    b.HasIndex("RefeicaoID");

                    b.HasIndex("RefeicaoID1");

                    b.ToTable("PedidoRefeicao");
                });

            modelBuilder.Entity("DTO.RefeicaoDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<double>("Preco")
                        .HasColumnType("float")
                        .IsUnicode(false);

                    b.HasKey("ID");

                    b.ToTable("REFEICOES");
                });

            modelBuilder.Entity("DTO.RefeicaoIngrediente", b =>
                {
                    b.Property<int>("RefeicaoID")
                        .HasColumnType("int");

                    b.Property<int>("IngredienteID")
                        .HasColumnType("int");

                    b.Property<int>("IngredienteID1")
                        .HasColumnType("int");

                    b.HasKey("RefeicaoID", "IngredienteID");

                    b.HasIndex("IngredienteID");

                    b.HasIndex("IngredienteID1");

                    b.ToTable("RefeicaoIngrediente");
                });

            modelBuilder.Entity("DTO.UsuarioDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("char(14)")
                        .IsFixedLength(true)
                        .HasMaxLength(14)
                        .IsUnicode(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasMaxLength(60)
                        .IsUnicode(false);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Permissao")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("USUARIOS");
                });

            modelBuilder.Entity("DTO.PedidoBebida", b =>
                {
                    b.HasOne("DTO.PedidoDTO", "Pedido")
                        .WithMany("Bebidas")
                        .HasForeignKey("BebidaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DTO.BebidaDTO", "Bebida")
                        .WithMany("Pedidos")
                        .HasForeignKey("BebidaID1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DTO.PedidoRefeicao", b =>
                {
                    b.HasOne("DTO.PedidoDTO", "Pedido")
                        .WithMany("Refeicoes")
                        .HasForeignKey("RefeicaoID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DTO.RefeicaoDTO", "Refeicao")
                        .WithMany("Pedidos")
                        .HasForeignKey("RefeicaoID1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DTO.RefeicaoIngrediente", b =>
                {
                    b.HasOne("DTO.RefeicaoDTO", "Refeicao")
                        .WithMany("Ingredientes")
                        .HasForeignKey("IngredienteID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DTO.IngredienteDTO", "Ingrediente")
                        .WithMany("Refeicoes")
                        .HasForeignKey("IngredienteID1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
