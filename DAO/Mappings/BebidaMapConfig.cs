using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Mappings
{
    public class BebidaMapConfig : IEntityTypeConfiguration<BebidaDTO>
    {
        public void Configure(EntityTypeBuilder<BebidaDTO> builder)
        {
            builder.ToTable("BEBIDAS");

            builder.Property(b => b.Nome).HasMaxLength(50).IsRequired().IsUnicode();
            builder.Property(b => b.Preco).IsRequired().IsUnicode();
        }
    }
}
