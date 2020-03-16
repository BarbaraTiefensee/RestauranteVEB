using DAO.Interfaces;
using DTO;
using DTO.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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
                UsuarioDTO usuarioJaCadastrado = await _context.Usuarios.FirstOrDefaultAsync(c => c.Nome.Equals(usuario.Nome));
                if (usuarioJaCadastrado != null)
                {
                    response.Erros.Add("Usuário já cadastrado!");
                    response.Sucesso = false;
                    return response;
                }

                this._context.Usuarios.Add(usuario);
                await this._context.SaveChangesAsync();
                response.Sucesso = true;
                return response;
            }
            catch (Exception ex)
            {
                if(ex.Message.Contains("IX_USUARIOS_CPF"))
                {
                    response.Erros.Add("CPF já Cadastrado");
                }
                else if (ex.Message.Contains("IX_USUARIOS_Email"))
                {
                    response.Erros.Add("Email já Cadastrado");
                }
                else
                {
                    File.WriteAllText("log.txt", ex.Message);
                    response.Erros.Add("Erro no banco de dados, contate o administrador.");
                }

                response.Sucesso = false;
                return response;
            }
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
                response.Sucesso = true;
                response.Data = teste;
                return response;
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador.");
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
