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
       
        public virtual ICollection<RefeicaoDTO> RefeicoesCollection { get; set; }
        public virtual ICollection<PedidoBebida> Bebidas { get; set; }

        public PedidoDTO()
        {
            this.RefeicoesCollection = new List<RefeicaoDTO>();
            this.Bebidas = new List<PedidoBebida>();
        }
    }
}
