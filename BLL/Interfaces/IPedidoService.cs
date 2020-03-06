using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    interface IPedidoService
    {
        Task Insert(PedidoDTO pedido);
        Task<List<PedidoDTO>> GetData();
    }
}
