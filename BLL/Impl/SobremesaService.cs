using BLL.Interfaces;
using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class SobremesaService : ISobremesaService
    {
        private ISobremesaRepository _sobremesaRepository;
        public SobremesaService(ISobremesaRepository sobremesaRepository)
        {
            this._sobremesaRepository = sobremesaRepository;
        }

        public async Task<Response> Insert(SobremesaDTO sobremesa)
        {
            Response response = Validate(sobremesa);

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            return await _sobremesaRepository.Insert(sobremesa);
        }

        public async Task<DataResponse<SobremesaDTO>> GetData()
        {
            return await _sobremesaRepository.GetData();
        }

        private Response Validate(SobremesaDTO item)
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
