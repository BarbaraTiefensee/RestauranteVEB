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
        public int RefeicaoID { get; set; }
        public virtual RefeicaoDTO Refeicao { get; set; }
        public int BebidaID { get; set; }
        public virtual BebidaDTO Bebida { get; set; }

        public virtual ICollection<RefeicaoDTO> RefeicoesCollection { get; set; }
        public virtual ICollection<BebidaDTO> BebidasCollection { get; set; }

        public PedidoDTO()
        {
            this.RefeicoesCollection = new List<RefeicaoDTO>();
            this.BebidasCollection = new List<BebidaDTO>();
        }
    }
}
