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
        public RefeicaoDTO Refeicao { get; set; }
        public BebidaDTO Bebida { get; set; }
    }
}
