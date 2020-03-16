using DAO.Interfaces;
using DTO;
using DTO.Enums;
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

            try
            {
                this._context.Usuarios.Add(usuario);
                await this._context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Erros.Add("se vira pco" + ex.Message);
            }

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

        public async Task<UsuarioDTO> Autententicar(UsuarioDTO usuario)
        {
            usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email.Equals(usuario.Email) && u.Senha.Equals(usuario.Senha)).ConfigureAwait(false);

            if (usuario == null)
            {
                throw new Exception("Email e/ou senhas inválidos.");
            }

            return usuario;
        }
    }
}
