using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Impl
{
    public class PedidoRepository : IPedidoRepository
    {
        private RContext _context;
        public PedidoRepository(RContext context)
        {
            this._context = context;
        }

        public async Task<Response> Insert(PedidoDTO pedido)
        {
            Response response = new Response();

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            this._context.Pedidos.Add(pedido);
            await this._context.SaveChangesAsync();
            return response;
        }

        public async Task<DataResponse<PedidoDTO>> GetData()
        {
            DataResponse<PedidoDTO> response = new DataResponse<PedidoDTO>();

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            await this._context.Pedidos.ToListAsync();
            return response;
        }
    }
}
