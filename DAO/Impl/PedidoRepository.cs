using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
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

        public async Task Insert(PedidoDTO pedido)
        {
            this._context.Pedidos.Add(pedido);
            await this._context.SaveChangesAsync();
        }

       
    }
}
