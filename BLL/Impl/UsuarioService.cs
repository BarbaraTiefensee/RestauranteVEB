using BLL.Interfaces;
using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this._usuarioRepository = usuarioRepository;
        }

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
