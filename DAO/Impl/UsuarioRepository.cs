using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Impl
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private RContext _context;
        public UsuarioRepository(RContext context)
        {
            this._context = context;
        }

        public async Task Insert(UsuarioDTO usuario)
        {
            this._context.Usuarios.Add(usuario);
            await this._context.SaveChangesAsync();
        }
    }
}
