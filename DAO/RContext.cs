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
        public RContext() : base()
        {

        }

        
        public DbSet<IngredienteDTO> Ingredientes { get; set; }
        public DbSet<PedidoDTO> Pedidos { get; set; }
        public DbSet<UsuarioDTO> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<string>().Property(s => s.IsNormalized()).IsRequired().IsUnicode(false).HasColumnType("varchar");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
