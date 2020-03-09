using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPedidoService
    {
        Task<Response> Insert(PedidoDTO pedido);
        Task<DataResponse<PedidoDTO>> GetData();
    }
}
