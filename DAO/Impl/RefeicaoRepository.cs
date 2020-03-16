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

            try
            {
                RefeicaoDTO refeicaoJaCadastrada = await _context.Refeicoes.FirstOrDefaultAsync(c => c.Nome.Equals(refeicao.Nome));
                if (refeicaoJaCadastrada != null)
                {
                    response.Erros.Add("Refeição já cadastrada!");
                    response.Sucesso = false;
                    return response;
                }

                this._context.Refeicoes.Add(refeicao);
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
