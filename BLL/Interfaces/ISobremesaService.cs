using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISobremesaService
    {
        Task<Response> Insert(SobremesaDTO sobremesa);
        Task<DataResponse<SobremesaDTO>> GetData();
    }
}
