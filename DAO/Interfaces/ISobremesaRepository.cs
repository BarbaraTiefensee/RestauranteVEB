using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface ISobremesaRepository
    {
        Task<Response> Insert(SobremesaDTO sobremesa);
        Task<DataResponse<SobremesaDTO>> GetData();
    }
}
