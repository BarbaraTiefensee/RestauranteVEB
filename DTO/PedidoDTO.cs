using DTO.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class PedidoDTO
    {
        public int ID { get; set; }
        public double Preco { get; set; }
        public Refeicao Refeicao { get; set; }
        public Bebidas Bebebida { get; set; }
    }
}
