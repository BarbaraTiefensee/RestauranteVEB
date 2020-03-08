using DTO.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace DAO.Mappings
{
    class EnderecoMapConfig : ComplexTypeConfiguration<Endereco>
    {
        public EnderecoMapConfig()
        {
            this.Property(e => e.Bairro).IsRequired().IsUnicode(false).HasMaxLength(50);
            this.Property(e => e.CEP).IsRequired().IsUnicode(false).IsFixedLength().HasMaxLength(9);
            this.Property(e => e.Cidade).IsRequired().IsUnicode(false).HasMaxLength(50);
            this.Property(e => e.Cidade).IsRequired().IsUnicode(false).HasMaxLength(50);
            this.Property(e => e.Complemento).IsRequired().IsUnicode(false).HasMaxLength(100);
        }
    }
}
