using DAO.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Impl
{
    public class RefeicaoRepository : IRefeicaoRepository
    {
        private RContext _context;
        public RefeicaoRepository(RContext context)
        {
            this._context = context;
        }
        public async Task<Response> Insert(RefeicaoDTO refeicao)
        {
            Response response = new Response();

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            this._context.Refeicoes.Add(refeicao);
            await this._context.SaveChangesAsync();
            return response;
        }
        public async Task<DataResponse<RefeicaoDTO>> GetData()
        {
            DataResponse<RefeicaoDTO> response = new DataResponse<RefeicaoDTO>();

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }
            try
            {
                var teste = await this._context.Refeicoes.ToListAsync();
                response.Data = teste;
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
