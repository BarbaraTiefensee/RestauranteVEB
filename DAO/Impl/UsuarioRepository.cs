using DAO.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Response> Insert(UsuarioDTO usuario)
        {
            Response response = new Response();

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            this._context.Usuarios.Add(usuario);
            await this._context.SaveChangesAsync();

            return response;
        }

        public async Task<DataResponse<UsuarioDTO>> GetData()
        {
            DataResponse<UsuarioDTO> response = new DataResponse<UsuarioDTO>();

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }
            try
            {
                var teste = await this._context.Usuarios.ToListAsync();
                response.Data = teste;
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<UsuarioDTO> Autententicar(string email, string password)
        {
            UsuarioDTO usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email.Equals(email) && u.Senha.Equals(password)).ConfigureAwait(false);

            if (usuario == null)
            {
                throw new Exception("Email e/ou senhas inválidos.");
            }

            return usuario;
        }
    }
}
