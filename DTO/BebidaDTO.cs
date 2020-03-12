using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class BebidaDTO
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public virtual ICollection<PedidoDTO> PedidoCollection { get; set; }

        public BebidaDTO()
        {
            this.PedidoCollection = new List<PedidoDTO>();
        }
    }
}
