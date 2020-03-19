using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class SobremesaDTO
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }

        public virtual ICollection<PedidoSobremesa> Pedidos { get; set; }

        public SobremesaDTO()
        {
            this.Pedidos = new List<PedidoSobremesa>();
        }
    }
}
