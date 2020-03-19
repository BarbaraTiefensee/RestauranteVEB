using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

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
        public DbSet<SobremesaDTO> Sobremesas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PedidoBebida>().HasKey(t => new { t.PedidoID, t.BebidaID });
            modelBuilder.Entity<PedidoRefeicao>().HasKey(t => new { t.PedidoID, t.RefeicaoID });
            modelBuilder.Entity<PedidoSobremesa>().HasKey(t => new { t.PedidoID, t.SobremesaID });
            modelBuilder.Entity<RefeicaoIngrediente>().HasKey(t => new { t.RefeicaoID, t.IngredienteID });
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
