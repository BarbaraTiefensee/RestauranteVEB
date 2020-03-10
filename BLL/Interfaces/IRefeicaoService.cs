using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRefeicaoService
    {
        Task<Response> Insert(RefeicaoDTO refeicao);
        Task<DataResponse<RefeicaoDTO>> GetData();
    }
}
