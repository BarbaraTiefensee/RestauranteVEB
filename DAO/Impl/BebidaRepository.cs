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
    public class BebidaRepository :IBebidaRepository
    {
        private RContext _context;
        public BebidaRepository(RContext context)
        {
            this._context = context;
        }
        public async Task<Response> Insert(BebidaDTO bebida)
        {
            Response response = new Response();

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            try
            {
                BebidaDTO bebidaJaCadastrada = await _context.Bebidas.FirstOrDefaultAsync(c => c.Nome.Equals(bebida.Nome));
                if (bebidaJaCadastrada != null)
                {
                    response.Erros.Add("Bebida já cadastrada!");
                    response.Sucesso = false;
                    return response;
                }

                this._context.Bebidas.Add(bebida);
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

        public async Task<DataResponse<BebidaDTO>> GetData()
        {
            DataResponse<BebidaDTO> response = new DataResponse<BebidaDTO>();

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            try
            {
                var teste = await this._context.Bebidas.ToListAsync();
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
