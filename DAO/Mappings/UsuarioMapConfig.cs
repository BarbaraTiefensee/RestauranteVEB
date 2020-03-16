using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Mappings
{
    class UsuarioMapConfig : IEntityTypeConfiguration<UsuarioDTO>
    {
        public void Configure(EntityTypeBuilder<UsuarioDTO> builder)
        {
            builder.ToTable("USUARIOS");

            builder.Property(c => c.Nome).HasMaxLength(50);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(60).IsUnicode(false);
            builder.HasIndex(c => c.Email).IsUnique(true);
            builder.Property(c => c.CPF).IsRequired().IsFixedLength().HasMaxLength(14).IsUnicode(false);
            builder.HasIndex(c => c.CPF).IsUnique(true);
            builder.Property(c => c.Senha).HasMaxLength(15).IsRequired().IsUnicode(false);
        }
    }
}
