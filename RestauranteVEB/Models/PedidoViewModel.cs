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
        public double ValorTotal { get; set; }
        public List<RefeicaoDTO> Refeicao { get; set; }
        public List<BebidaDTO> Bebida { get; set; }
        public List<SobremesaDTO> Sobremesa { get; set; }
    }
}
