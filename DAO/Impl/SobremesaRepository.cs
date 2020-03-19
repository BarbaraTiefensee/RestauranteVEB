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
    public class SobremesaRepository : ISobremesaRepository
    {
        private RContext _context;
        public SobremesaRepository(RContext context)
        {
            this._context = context;
        }

        public async Task<Response> Insert(SobremesaDTO sobremesa)
        {
            Response response = new Response();

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            try
            {
                SobremesaDTO sobremesaJaCadastrada = await _context.Sobremesas.FirstOrDefaultAsync(c => c.Nome.Equals(sobremesa.Nome));
                if (sobremesaJaCadastrada != null)
                {
                    response.Erros.Add("Sobremesa já cadastrada!");
                    response.Sucesso = false;
                    return response;
                }

                this._context.Sobremesas.Add(sobremesa);
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

        public async Task<DataResponse<SobremesaDTO>> GetData()
        {
            DataResponse<SobremesaDTO> response = new DataResponse<SobremesaDTO>();

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            try
            {
                var teste = await this._context.Sobremesas.ToListAsync();
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
