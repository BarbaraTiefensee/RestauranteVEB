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
    public class IngredienteController : Controller
    {
        private IIngredienteService _ingredienteService;

        public IngredienteController(IIngredienteService ingredienteService)
        {
            this._ingredienteService = ingredienteService;
        }

        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(IngredienteViewModel ingredienteViewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<IngredienteViewModel, IngredienteDTO>();
            });
            IMapper mapper = configuration.CreateMapper();

            IngredienteDTO dto = mapper.Map<IngredienteDTO>(ingredienteViewModel);

            try
            {
                await _ingredienteService.Insert(dto);

                return RedirectToAction("Index", "Ingrediente");
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