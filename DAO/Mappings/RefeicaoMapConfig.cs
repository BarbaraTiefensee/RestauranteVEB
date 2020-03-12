using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Mappings
{
    internal class RefeicaoMapConfig : IEntityTypeConfiguration<RefeicaoDTO>
    {
        public void Configure(EntityTypeBuilder<RefeicaoDTO> builder)
        {
            builder.ToTable("REFEICOES");

           // builder.HasNoKey();

            builder.Property(r => r.Nome).IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(r => r.Preco).IsRequired().IsUnicode(false);

            builder.HasMany(r => r.Ingredientes).WithOne(r => r.Refeicao).HasForeignKey(r => r.IngredienteID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
