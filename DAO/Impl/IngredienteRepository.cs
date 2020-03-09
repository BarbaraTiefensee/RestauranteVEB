using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

            this._context.Ingredientes.Add(ingrediente);
            await this._context.SaveChangesAsync();
            return response;
        }

        public async Task<DataResponse<IngredienteDTO>> GetData()
        {
            DataResponse<IngredienteDTO> response = new DataResponse<IngredienteDTO>();

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            await this._context.Ingredientes.ToListAsync();
            return response;
        }
    }
}
