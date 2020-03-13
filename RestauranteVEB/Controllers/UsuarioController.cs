using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Impl;
using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestauranteVEB.Models;
using RestSharp;

namespace RestauranteVEB.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioService _userService;

        public UsuarioController(IUsuarioService userService)
        {
            this._userService = userService;
        }

        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(UsuarioViewModel usuarioViewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UsuarioViewModel, UsuarioDTO>();
            });
            IMapper mapper = configuration.CreateMapper();

            UsuarioDTO dto = mapper.Map<UsuarioDTO>(usuarioViewModel);

            try
            {
                await _userService.Insert(dto);

                return RedirectToAction("Index", "Usuario");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View();
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                DataResponse<UsuarioDTO> usuarios = await _userService.GetData();

                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<UsuarioDTO, UsuarioQueryViewModel>();
                });
                IMapper mapper = configuration.CreateMapper();

                List<UsuarioQueryViewModel> dados = mapper.Map<List<UsuarioQueryViewModel>>(usuarios.Data);

                return View(dados);
            }
            catch (Exception)
            {
                return View();
            }
        }

        public async Task<ActionResult> Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Login(string email, string senha)
        {

            try
            {
                await _userService.Autententicar(email, senha);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, email)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties();
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
                ViewBag.UsuarioLogado = true;

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
    }
}
