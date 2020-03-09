﻿using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUsuarioService
    {
        Task<Response> Insert(UsuarioDTO usuario);
        Task<DataResponse<UsuarioDTO>> GetData();
        Task<Response> Autententicar(string email, string password);
    }
}
