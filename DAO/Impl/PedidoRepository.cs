using DAO.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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

            try
            {
                this._context.Pedidos.Add(pedido);
                await this._context.SaveChangesAsync();
                response.Sucesso = true;
                return response;
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                response.Erros.Add("Erro no banco de dados, contate o administrador.");

                response.Sucesso = false;
                return response;
            }
        }

        public async Task<DataResponse<PedidoDTO>> GetData()
        {
            DataResponse<PedidoDTO> response = new DataResponse<PedidoDTO>();

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            try
            {
                var teste = await this._context.Pedidos.ToListAsync();
                response.Sucesso = true;
                response.Data = teste;
                return response;
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador.");
            }
        }
    }
}
