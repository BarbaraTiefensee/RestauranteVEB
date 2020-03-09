using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer3.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestauranteVEB.Models;

namespace RestauranteVEB.Controllers
{
    public class UsuarioController : Controller
    {
        public class UserController : Controller
        {
            private IUserService _userService;

            public UserController(IUserService userService)
            {
                this._userService = userService;
            }

            public IActionResult Index()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Create()
            {
                _userService.Create(new DTO.UsuarioDTO());

                return View();
            }
        }
    }
}
