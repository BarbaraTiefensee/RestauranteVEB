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
    public class SobremesaController : Controller
    {
        private ISobremesaService _sobremesaService;
        public SobremesaController(ISobremesaService sobremesaService)
        {
            this._sobremesaService = sobremesaService;
        }

        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(SobremesaViewModel sobremesaViewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SobremesaViewModel, SobremesaDTO>();
            });
            IMapper mapper = configuration.CreateMapper();

            SobremesaDTO dto = mapper.Map<SobremesaDTO>(sobremesaViewModel);

            try
            {
                Response response = await _sobremesaService.Insert(dto);

                if (response.Sucesso)
                {
                    return RedirectToAction("Index", "Sobremesa");
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
                DataResponse<SobremesaDTO> sobremesas = await _sobremesaService.GetData();

                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<SobremesaDTO, SobremesaQueryViewModel>();
                });
                IMapper mapper = configuration.CreateMapper();

                List<SobremesaQueryViewModel> dados = mapper.Map<List<SobremesaQueryViewModel>>(sobremesas.Data);

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