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
                Response response = await _refeicaoService.Insert(dto);

                if (response.Sucesso)
                {
                    return RedirectToAction("Index", "Refeicao");
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
                DataResponse<RefeicaoDTO> refeicoes = await _refeicaoService.GetData();

                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RefeicaoDTO, RefeicaoQueryViewModel>();
                });
                IMapper mapper = configuration.CreateMapper();

                List<RefeicaoQueryViewModel> dados = mapper.Map<List<RefeicaoQueryViewModel>>(refeicoes.Data);

                return View(dados);
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}