using BLL.Interfaces;
using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class BebidaService : IBebidaService
    {
        private IBebidaRepository _bebidaRepository;
        public BebidaService(IBebidaRepository bebidaRepository)
        {
            this._bebidaRepository = bebidaRepository;
        }

        public async Task<Response> Insert(BebidaDTO bebida)
        {
            Response response = Validate(bebida);

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            return await _bebidaRepository.Insert(bebida);
        }

        public async Task<DataResponse<BebidaDTO>> GetData()
        {
            return await _bebidaRepository.GetData();
        }

        private Response Validate(BebidaDTO item)
        {
            Response response = new Response();

            if (string.IsNullOrWhiteSpace(item.Nome))
            {
                response.Erros.Add("Informe o seu nome.");
            }
            else
            {
                item.Nome = EXT.NormatizarNome(item.Nome);
                if (item.Nome.Length < 2 || item.Nome.Length > 50)
                {
                    response.Erros.Add("O nome deve conter entre 2 e 50 caracteres.");
                }
                else if (!EXT.CorrectName(item.Nome))
                {
                    response.Erros.Add("O nome está no formato incorreto.");
                }
            }

            return response;
        }

    }
}
