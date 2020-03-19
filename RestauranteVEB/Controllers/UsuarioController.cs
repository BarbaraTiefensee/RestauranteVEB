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
using DTO.Enums;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "ADM")]
        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "ADM")]
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
                Response response = await _userService.Insert(dto);

                if (response.Sucesso)
                {
                    return RedirectToAction("Index", "Usuario");
                }

                ViewBag.ErrorMessage = response.GetErrorMessage();
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        [Authorize(Roles = "ADM")]
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
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
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
                UsuarioDTO usuarioDTO = await _userService.Autententicar(email, senha);

                List<Claim> claims = new List<Claim>();
                if (usuarioDTO.Permissao == Permissao.Adiministrador)
                {
                    claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Role, "ADM"),
                        new Claim(ClaimTypes.Name, usuarioDTO.Email)
                    };
                }
                else
                {
                    claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Role, "FUNCIONARIO"),
                        new Claim(ClaimTypes.Name, usuarioDTO.Email)
                    };
                }

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties();
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
                ViewBag.UsuarioLogado = claims;

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
