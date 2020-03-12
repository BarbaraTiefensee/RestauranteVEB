using DTO.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class UsuarioDTO
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Permissao Permissao { get; set; }
    }
}
