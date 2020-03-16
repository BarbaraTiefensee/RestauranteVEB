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
    public class IngredienteRepository : IIngredienteRepository
    {
        private RContext _context;
        public IngredienteRepository(RContext context)
        {
            this._context = context;
        }

        public async Task<Response> Insert(IngredienteDTO ingrediente)
        {
            Response response = new Response();

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            try
            {
                IngredienteDTO ingredienteJaCadastrado = await _context.Ingredientes.FirstOrDefaultAsync(c => c.Nome.Equals(ingrediente.Nome));
                if (ingredienteJaCadastrado != null)
                {
                    response.Erros.Add("Ingrediente já cadastrado!");
                    response.Sucesso = false;
                    return response;
                }

                this._context.Ingredientes.Add(ingrediente);
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

        public async Task<DataResponse<IngredienteDTO>> GetData()
        {
            DataResponse<IngredienteDTO> response = new DataResponse<IngredienteDTO>();

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            try
            {
                var teste = await this._context.Ingredientes.ToListAsync();
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
