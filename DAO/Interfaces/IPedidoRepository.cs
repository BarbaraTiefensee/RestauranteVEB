using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IPedidoRepository
    {
        Task<Response> Insert(PedidoDTO pedido);
    }
}
