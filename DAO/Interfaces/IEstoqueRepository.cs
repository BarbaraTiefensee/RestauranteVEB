using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IEstoqueRepository
    {
        Task<Response> Insert(EstoqueDTO estoque);
        Task<DataResponse<EstoqueDTO>> GetData();
    }
}
