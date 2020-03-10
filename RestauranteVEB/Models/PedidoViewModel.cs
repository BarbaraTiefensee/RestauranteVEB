using DTO;
using DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteVEB.Models
{
    public class PedidoViewModel
    {
        public string NomeNoPedido { get; set; }
        public RefeicaoDTO Refeicao { get; set; }
        public BebidaDTO Bebida { get; set; }
    }
}
