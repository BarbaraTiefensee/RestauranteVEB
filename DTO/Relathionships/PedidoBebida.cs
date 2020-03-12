using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class PedidoBebida
    {
        public int PedidoID { get; set; }
        public virtual PedidoDTO Pedido { get; set; }

        public int BebidaID { get; set; }
        public virtual BebidaDTO Bebida{ get; set; }
    }
}
