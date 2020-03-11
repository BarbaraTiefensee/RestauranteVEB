using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBebidaService
    {
        Task<Response> Insert(BebidaDTO bebida);
        Task<DataResponse<BebidaDTO>> GetData();
    }
}
