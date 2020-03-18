using System;
using System.Collections.Generic;
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
                Response response = await _ingredienteService.Insert(dto);

                if (response.Sucesso)
                {
                    return RedirectToAction("Index", "Ingrediente");
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
                DataResponse<IngredienteDTO> ingredientes = await _ingredienteService.GetData();

                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<IngredienteDTO, IngredienteQueryViewModel>();
                });
                IMapper mapper = configuration.CreateMapper();

                List<IngredienteQueryViewModel> dados = mapper.Map<List<IngredienteQueryViewModel>>(ingredientes.Data);

                return View(dados);
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}