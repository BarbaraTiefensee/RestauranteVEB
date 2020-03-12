using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DAO
{
    public class RContext : DbContext
    {
        //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\900208\Documents\SSLocadora.mdf;Integrated Security=True;Connect Timeout=30"
        public RContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<IngredienteDTO> Ingredientes { get; set; }
        public DbSet<PedidoDTO> Pedidos { get; set; }
        public DbSet<UsuarioDTO> Usuarios { get; set; }
        public DbSet<RefeicaoDTO> Refeicoes { get; set; }
        public DbSet<BebidaDTO> Bebidas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<string>().Property(s => s.IsNormalized()).IsRequired().IsUnicode(false).HasColumnType("varchar");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //MANY TO MANY
            modelBuilder.Entity<PedidoDTO>()
           .HasOne(pt => pt.Bebida)
           .WithMany(pt => pt.PedidoCollection)
           .HasForeignKey(pt => pt.BebidaID)
           .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PedidoDTO>()
           .HasOne(pt => pt.Refeicao)
           .WithMany(pt => pt.PedidoCollection)
           .HasForeignKey(pt => pt.RefeicaoID)
           .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
