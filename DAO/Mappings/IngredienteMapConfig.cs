using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Mappings
{
    internal class IngredienteMapConfig : IEntityTypeConfiguration<IngredienteDTO>
    {
        public void Configure(EntityTypeBuilder<IngredienteDTO> builder)
        {
            builder.ToTable("INGREDIENTES");

            builder.Property(i => i.Nome).HasMaxLength(50).IsRequired().IsUnicode(false);
            builder.Property(i => i.Quantidade).HasColumnName("float").IsRequired();

        }
    }
}
