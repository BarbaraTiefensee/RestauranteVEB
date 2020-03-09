using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Impl
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private RContext _context;
        public EstoqueRepository(RContext context)
        {
            this._context = context;
        }

        public Task<DataResponse<EstoqueDTO>> GetData()
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Insert(EstoqueDTO estoque)
        {
            Response response = new Response();

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            this._context.EstoqueProdutos.Add(estoque);
            await this._context.SaveChangesAsync();
            return response;
        }
    }
}
