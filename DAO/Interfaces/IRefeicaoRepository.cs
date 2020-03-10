using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IRefeicaoRepository
    {
        Task<Response> Insert(RefeicaoDTO refeicao);
        Task<DataResponse<RefeicaoDTO>> GetData();
    }
}
