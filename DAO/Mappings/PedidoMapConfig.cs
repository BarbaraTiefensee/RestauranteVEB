using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace DAO.Mappings
{
    class PedidoMapConfig : EntityTypeConfiguration<PedidoDTO>
    {
        public PedidoMapConfig()
        {
            this.ToTable("PEDIDOS");

            this.Property(p => p.Preco).HasColumnName("float").IsRequired();
        }
    }
}
