using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Impl;
using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using RestauranteVEB.Models;

namespace RestauranteVEB.Controllers
{
    public class PedidoController : Controller
    {
        private IPedidoService _pedidoService;
        private IRefeicaoService _refeicaoService;
        private IBebidaService _BebidaService;


        public PedidoController(IPedidoService pedidoService, IRefeicaoService refeicaoService, IBebidaService bebidaService)
        {
            this._pedidoService = pedidoService;
            this._refeicaoService = refeicaoService;
            this._BebidaService = bebidaService;
        }

        public async Task<IActionResult> Cadastrar()
        {
            DataResponse<RefeicaoDTO> refeicoes = _refeicaoService.GetData().Result;
            DataResponse<BebidaDTO> bebidas =  _BebidaService.GetData().Result;

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RefeicaoDTO, RefeicaoQueryViewModel>();
                cfg.CreateMap<BebidaDTO, BebidaQueryViewModel>();
            });
            IMapper mapper = configuration.CreateMapper();

            List<RefeicaoQueryViewModel> dadosRefeiceos = mapper.Map<List<RefeicaoQueryViewModel>>(refeicoes);
            List<BebidaQueryViewModel> dadosBebidas = mapper.Map<List<BebidaQueryViewModel>>(bebidas);

            ViewBag.Refeicoes = dadosRefeiceos;
            ViewBag.Bebidas = dadosBebidas;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(PedidoViewModel pedidoViewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PedidoViewModel, PedidoDTO>();
            });
            IMapper mapper = configuration.CreateMapper();

            PedidoDTO dto = mapper.Map<PedidoDTO>(pedidoViewModel);

            try
            {
                await _pedidoService.Insert(dto);

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