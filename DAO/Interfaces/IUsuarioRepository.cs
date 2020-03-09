using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Response> Insert(UsuarioDTO usuario);
        Task<DataResponse<UsuarioDTO>> GetData();
        Task<UsuarioDTO> Autententicar(string email, string password);
    }
}
