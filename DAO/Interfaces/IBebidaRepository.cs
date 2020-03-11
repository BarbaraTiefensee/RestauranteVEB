using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IBebidaRepository
    {
        Task<Response> Insert(BebidaDTO bebida);
        Task<DataResponse<BebidaDTO>> GetData();
    }
}
