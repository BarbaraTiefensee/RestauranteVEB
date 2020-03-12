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

            builder.Property(p => p.NomeNoPedido)
                .IsRequired().
                IsUnicode(false)
                .HasMaxLength(50);

           // builder.HasOne(p => p.BebidaID).WithMany().OnDelete(DeleteBehavior.Cascade);

           // builder.HasOne(p => p.Refeicao).
            //    WithMany(P => P.ID).OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(e => e.Refeicao.WithMany().Metadata.DeleteBehavior = DeleteBehavior.Restrict;
            //TODO: PESQUISAR SOBRE O DELETE
        }
    }
}
