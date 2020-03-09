using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Impl
{
    public class EstoqueRepository
    {
        private RContext _context;
        public EstoqueRepository(RContext context)
        {
            this._context = context;
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
