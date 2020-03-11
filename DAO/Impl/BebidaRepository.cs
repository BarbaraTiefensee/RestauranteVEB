using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

            this._context.Bebidas.Add(bebida);
            await this._context.SaveChangesAsync();
            return response;
        }
        public async Task<DataResponse<BebidaDTO>> GetData()
        {
            DataResponse<BebidaDTO> response = new DataResponse<BebidaDTO>();

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            await this._context.Bebidas.ToListAsync();
            return response;
        }

    }
}
