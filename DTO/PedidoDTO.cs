using DTO.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class PedidoDTO
    {
        public int ID { get; set; }
        public string NomeNoPedido { get; set; }
        
        public virtual ICollection<PedidoRefeicao> Refeicoes { get; set; }
        public virtual ICollection<PedidoRefeicao> Bebidas { get; set; }

        public PedidoDTO()
        {
            this.Refeicoes = new List<PedidoRefeicao>();
        }
    }
}
