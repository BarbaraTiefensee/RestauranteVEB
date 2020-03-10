using BLL.Interfaces;
using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class PedidoService : IPedidoService
    {
        private IPedidoRepository _pedidoRepository;
        public PedidoService(IPedidoRepository pedidoRepository)
        {
            this._pedidoRepository = pedidoRepository;
        }

        public async Task<Response> Insert(PedidoDTO pedido)
        {
            Response response = Validate(pedido);

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            await _pedidoRepository.Insert(pedido);
            return response;
        }

        public async Task<DataResponse<PedidoDTO>> GetData()
        {
            return await _pedidoRepository.GetData();
        }
        private Response Validate(PedidoDTO item)
        {
            Response response = new Response();

            if (item.NomeNoPedido.Equals(""))
            {
                response.Erros.Add("O nome deve ser informado.");
            }

            return response;
        }


    }
}
