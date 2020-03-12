using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Mappings
{
    class PedidoMapConfig : IEntityTypeConfiguration<PedidoDTO>
    {
        public void Configure(EntityTypeBuilder<PedidoDTO> builder)
        {
            builder.ToTable("PEDIDOS");
            //builder.HasNoKey();

            builder.Property(p => p.NomeNoPedido)
                .IsRequired().
                IsUnicode(false)
                .HasMaxLength(50);

            builder.HasMany(p => p.Refeicoes).WithOne(p => p.Pedido).HasForeignKey(p => p.RefeicaoID).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.Bebidas).WithOne(p => p.Pedido).HasForeignKey(p => p.BebidaID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
