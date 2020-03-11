using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using RestauranteVEB.Models;

namespace RestauranteVEB.Controllers
{
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
                await _bebidaService.Insert(dto);

                return RedirectToAction("Index", "Bebida");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}