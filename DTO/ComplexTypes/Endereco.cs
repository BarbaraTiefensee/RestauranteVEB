using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.ComplexTypes
{
    public class Endereco
    {
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
    }
}
