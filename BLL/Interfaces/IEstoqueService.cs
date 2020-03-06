using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    interface IEstoqueService
    {
        Task Insert(EstoqueDTO estoque);
        Task<List<EstoqueDTO>> GetData();
    }
}
