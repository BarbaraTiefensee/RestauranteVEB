using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace DAO.Mappings
{
    class UsuarioMapConfig : EntityTypeConfiguration<UsuarioDTO>
    {
        public UsuarioMapConfig()
        {
            this.ToTable("USUARIOS");

            this.Property(u => u.Nome).IsRequired().IsUnicode(false).HasMaxLength(50);
            this.Property(u => u.CPF).IsRequired().IsUnicode(false).IsFixedLength().HasMaxLength(14);
            this.HasIndex(u => u.CPF).IsUnique(true);
            this.Property(u => u.Email).IsRequired().IsUnicode(false).HasMaxLength(50);
            this.HasIndex(u => u.Email).IsUnique(true);
            
        }
    }
}
