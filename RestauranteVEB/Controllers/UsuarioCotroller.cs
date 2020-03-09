using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BLL.Impl;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestauranteVEB.Models;

namespace RestauranteVEB.Controllers
{
    public class UsuarioController : Controller
    { 
        private IUsuarioService _userService;

        public UsuarioController(IUsuarioService userService)
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
            _userService.Insert(new DTO.UsuarioDTO());

            return View();
        }
    }
}
