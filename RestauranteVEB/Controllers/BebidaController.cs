using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestauranteVEB.Models;

namespace RestauranteVEB.Controllers
{
    [Authorize(Roles = "ADM")]
    public class BebidaController : Controller
    {
        private IBebidaService _bebidaService;

        public BebidaController(IBebidaService BebidaService)
        {
            this._bebidaService = BebidaService;
        }

        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(BebidaViewModel bebidaViewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BebidaViewModel, BebidaDTO>();
            });
            IMapper mapper = configuration.CreateMapper();

            BebidaDTO dto = mapper.Map<BebidaDTO>(bebidaViewModel);

            try
            {
                Response response = await _bebidaService.Insert(dto);

                if(response.Sucesso)
                {
                    return RedirectToAction("Index", "Bebida");
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

        public async Task<IActionResult> Index()
        {
            try
            {
                DataResponse<BebidaDTO> bebidas = await _bebidaService.GetData();

                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<BebidaDTO, BebidaQueryViewModel>();
                });
                IMapper mapper = configuration.CreateMapper();

                List<BebidaQueryViewModel> dados = mapper.Map<List<BebidaQueryViewModel>>(bebidas.Data);

                return View(dados);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
    }
}