using DTO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO
{
    public class PedidoDTO
    {
        public int ID { get; set; }
        public string NomeNoPedido { get; set; }
       
        public virtual ICollection<PedidoRefeicao> Refeicoes { get; set; }
        public virtual ICollection<PedidoBebida> Bebidas { get; set; }
        public virtual ICollection<PedidoSobremesa> Sobremesas { get; set; }

        public PedidoDTO()
        {
            this.Refeicoes = new List<PedidoRefeicao>();
            this.Bebidas = new List<PedidoBebida>();
            this.Sobremesas = new List<PedidoSobremesa>();
        }
    }
}
