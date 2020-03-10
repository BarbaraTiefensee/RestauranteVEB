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
    public class PedidoController : Controller
    {
        private IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            this._pedidoService = pedidoService;
        }

        public async Task<IActionResult> Cadastrar()
        {
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