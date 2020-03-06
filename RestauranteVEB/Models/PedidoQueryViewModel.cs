using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteVEB.Models
{
    public class PedidoQueryViewModel
    {
        public int ID { get; set; }
        public double Preco { get; set; }
        public Refeicao Refeicao { get; set; }
        public Bebida Bebida { get; set; }
    }
}
