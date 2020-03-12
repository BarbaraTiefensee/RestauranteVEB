using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class RefeicaoDTO
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public virtual ICollection<PedidoDTO> PedidoCollection { get; set; }
        public virtual ICollection<RefeicaoIngrediente> Ingredientes { get; set; }

        public RefeicaoDTO()
        {
            this.PedidoCollection = new List<PedidoDTO>();
            this.Ingredientes = new List<RefeicaoIngrediente>();
        }
    }
}
