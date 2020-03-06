using DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteVEB.Models
{
    public class PedidoViewModel
    {
        public double Preco { get; set; }
        public Refeicao Refeicao { get; set; }
        public Bebida Bebida { get; set; }
    }
}
