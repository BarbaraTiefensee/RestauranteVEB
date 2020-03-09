using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUsuarioService
    {
        Task Insert(UsuarioDTO usuario);
        Task<DataResponse<UsuarioDTO>> GetData();
        Task<DataResponse<UsuarioDTO>> Autententicar(string email, string password);
    }
}
