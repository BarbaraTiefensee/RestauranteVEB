using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IEstoqueService
    {
        Task<Response> Insert(EstoqueDTO estoque);
        Task<DataResponse<EstoqueDTO>> GetData();
    }
}
