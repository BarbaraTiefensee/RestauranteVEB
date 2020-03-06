using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    interface IUserRepository
    {
        Task Insert(UsuarioDTO usuario);
    }
}
