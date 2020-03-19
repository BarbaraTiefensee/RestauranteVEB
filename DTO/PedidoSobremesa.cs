using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class PedidoSobremesa
    {
        public int PedidoID { get; set; }
        public virtual PedidoDTO Pedido { get; set; }

        public int SobremesaID { get; set; }
        public virtual SobremesaDTO Sobremesa { get; set; }
    }
}
