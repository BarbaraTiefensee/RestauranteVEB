using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Mappings
{
    public class SobremesaMapConfig : IEntityTypeConfiguration<SobremesaDTO>
    {
        public void Configure(EntityTypeBuilder<SobremesaDTO> builder)
        {
            builder.ToTable("SOBREMESAS");

            builder.Property(s => s.Nome).HasMaxLength(50).IsRequired().IsUnicode();
            builder.Property(s => s.Preco).IsRequired().IsUnicode(false);
        }
    }
}
