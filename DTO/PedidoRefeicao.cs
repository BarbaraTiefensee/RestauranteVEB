using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class PedidoRefeicao
    {
        public int PedidoID { get; set; }
        public virtual PedidoDTO Pedido { get; set; }

        public int RefeicaoID { get; set; }
        public virtual RefeicaoDTO Refeicao { get; set; }
    }
}
