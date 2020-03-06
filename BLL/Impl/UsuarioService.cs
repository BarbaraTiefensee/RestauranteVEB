using BLL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class UsuarioService : IUsuarioService
    {
        public async Task Insert(UsuarioDTO usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UsuarioDTO>> GetData()
        {
            throw new NotImplementedException();
        }

        public async Task<UsuarioDTO> Autententicar(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
