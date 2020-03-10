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
    public class RefeicaoController : Controller
    {
        private IRefeicaoService _refeicaoService;

        public RefeicaoController(IRefeicaoService refeicaoService)
        {
            this._refeicaoService = refeicaoService;
        }

        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(RefeicaoViewModel refeicaoViewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RefeicaoViewModel, RefeicaoDTO>();
            });
            IMapper mapper = configuration.CreateMapper();

            RefeicaoDTO dto = mapper.Map<RefeicaoDTO>(refeicaoViewModel);

            try
            {
                await _refeicaoService.Insert(dto);

                return RedirectToAction("Index", "Pedido");
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