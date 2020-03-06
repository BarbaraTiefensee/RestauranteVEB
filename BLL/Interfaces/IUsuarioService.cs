using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    interface IUsuarioService
    {
        Task Insert(UsuarioDTO usuario);
        Task<List<UsuarioDTO>> GetData();
        Task<UsuarioDTO> Autententicar(string email, string password);
    }
}
