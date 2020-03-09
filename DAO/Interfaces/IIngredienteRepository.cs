using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IIngredienteRepository
    {
        Task<Response> Insert(IngredienteDTO ingrediente);
    }
}
